using Azure.Core;
using DATN_ACV_DEV.Controllers.Condition;
using DATN_ACV_DEV.DTO_Order;
using DATN_ACV_DEV.Entity_ALB;
using DATN_ACV_DEV.FileBase;
using DATN_ACV_DEV.Model_DTO.GHN_DTO;
using DATN_ACV_DEV.Model_DTO.Order_DTO;
using DATN_ACV_DEV.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DATN_ACV_DEV.Controllers.Order
{
    [Route("api/CreateOrder")]
    [ApiController]
    public class CreateOrderController : ControllerBase, IBaseController<CreateOrderRequest, DTO_Order.CreateOrderResponse>
    {
        private readonly DBContext _context;
        private CreateOrderRequest _request;
        private BaseResponse<DTO_Order.CreateOrderResponse> _res;
        private DTO_Order.CreateOrderResponse _response;
        private string _apiCode = "CreateOrder";

        private TbAccount account;
        private TbCustomer customer;
        private TbAdressDelivery addressDelivery;
        private TbVoucher voucher;
        private decimal? _amountShip = 0;
        private decimal? _amountDiscount = 0;
        private decimal? _totalAmount = 0;
        private string _conC02 = "C02";
        private string _conC03 = "C03";
        private string _conC01 = "C01";
        private string _conC02Field = "ProductID";
        private string _conC03Field = "VoucherID";

        private List<OrderProduct> _listProduct;
        public CreateOrderController(DBContext context)
        {
            _context = context;
            _res = new BaseResponse<DTO_Order.CreateOrderResponse>()
            {
                Status = StatusCodes.Status200OK.ToString(),
                Data = null
            };
            _response = new DTO_Order.CreateOrderResponse();
            _listProduct = new List<OrderProduct>();
        }
        public void AccessDatabase()
        {
            _response.amountShip = _amountShip;
            _response.products = _listProduct;
            _response.totalAmount = _totalAmount;
            _response.totalAmountDiscount = _amountDiscount;
            _response.addressDelivery = addressDelivery.WardName + " " + addressDelivery.DistrictName + " " + addressDelivery.ProvinceName;
            _response.paymentMethod ="";
            _response.voucherCodes = voucher.Code;
            _response.description = _request.description;
            _res.Data = _response;
        }

        public void CheckAuthorization()
        {
            throw new NotImplementedException();
        }

        public void GenerateObjects()
        {
            account = _context.TbAccounts.Where(a => a.Id == _request.UserId).FirstOrDefault();
            customer = _context.TbCustomers.Where(c => c.Id == account.CustomerId).FirstOrDefault();
            addressDelivery = _context.TbAdressDeliveries.Where(a => a.Id == _request.AddressDeliveryId && a.IsDelete == false).FirstOrDefault();
            GHNFeeRequest requesFee = new GHNFeeRequest()
            {
                service_type_id = Utility.Utility.SERVICE_TYPE_DEFAULT,
                insurance_value = Convert.ToInt32(_listProduct.Sum(p => p.price)),
                to_ward_code = addressDelivery.WardCode,
                to_district_id = addressDelivery.DistrictId,
                from_district_id = Utility.Utility.FORM_DISTRICT_ID_DEFAULT,
                weight = _listProduct.Sum(c => c.weight ?? 2000),
                //tạm thời fix cứng
                lenght = 20,
                width = 20,
                height = 20,
            };
            _amountShip = Common.GetFee("", requesFee);
            if (_request.voucherID != null)
            {
                voucher = _context.TbVouchers.Where(c => c.Id == _request.voucherID && c.EndDate <= DateTime.Now).FirstOrDefault();
            }
            foreach (var product in _listProduct)
            {
                var totalAmountPromotionApplyProduct = product.price * product.quantity;               
                _totalAmount += totalAmountPromotionApplyProduct;
            }
            _amountDiscount = Common.CalculateDiscount(_totalAmount, voucher).DiscountVoucher;
        }

        public void PreValidation()
        {
            ACV_Exception ACV_Exception;
            foreach (var item in _request.product)
            {
                var model = _context.TbProducts.Where(product => product.Id == item.productId && product.IsDelete == false && product.Quantity >= item.quantity).FirstOrDefault();
                if (model != null)
                {
                    var image = _context.TbImages.Where(i => i.Id == model.ImageId).FirstOrDefault();
                    OrderProduct product = new OrderProduct()
                    {
                        productId = model.Id,
                        productName = model.Name,
                        productCode = model.Code,
                        price = model.Price,
                        url = image != null ? image.Url : ""


                        //productId = model.Id,
                        //categoryId = model.CategoryId,
                        //weight = model.Weight,
                        //quantity = item.Quantity.Value,

                    };
                    _listProduct.Add(product);
                }
                if (model == null)
                {
                    ACV_Exception = new ACV_Exception();
                    //To-do: Lay thong message text tu message code
                    ACV_Exception.Messages.Add(Message.CreateErrorMessage(_apiCode, _conC02, Utility.Utility.PRODUCT_NOTFOUND, _conC02Field));
                    throw ACV_Exception;
                }
            }
            #region Voucher không tồn tại
            ConditionOrder.CreateOrder_C02(_context, _request.voucherID, _apiCode, _conC03, _conC03Field);
            #endregion
        }

        public BaseResponse<DTO_Order.CreateOrderResponse> Process(DTO_Order.CreateOrderRequest request)
        {
            try
            {
                _request = request;
                //CheckAuthorization();
                PreValidation();
                GenerateObjects();
                //PostValidation();
                AccessDatabase();
            }
            catch (ACV_Exception ex0)
            {
                _res.Status = StatusCodes.Status400BadRequest.ToString();
                _res.Messages = ex0.Messages;
            }
            catch (Exception ex)
            {
                _res.Status = StatusCodes.Status500InternalServerError.ToString();
                _res.Messages.Add(Message.CreateErrorMessage(_apiCode, _res.Status, ex.Message, string.Empty));
            }
            return _res;
        }
    }
}
