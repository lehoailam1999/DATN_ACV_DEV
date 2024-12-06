using Azure.Core;
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
    [Route("api/ConfirmOrder")]
    [ApiController]
    public class ConfirmOrderController : ControllerBase, IBaseController<ConfirmOrderRequest, ConfirmOrderResponse>
    {
        private readonly DBContext _context;
        private ConfirmOrderRequest _request;
        private BaseResponse<DTO_Order.ConfirmOrderResponse> _res;
        private DTO_Order.ConfirmOrderResponse _response;
        private string _apiCode = "ConfirmOrder";

        private TbAccount account;
        private TbCustomer customer;
        private TbAdressDelivery addressDelivery;
        private TbVoucher voucher;
        private TbOrder _order;
        private TbOderDetail _orderDetail;
        private decimal? _amountShip = 0;
        private decimal? _amountDiscount = 0;
        private decimal? _totalAmount = 0;
        private string _conC01 = "C02";
        private string _conC02 = "C02";
        private string _conC02Field = "ProductID";
        private string _conC01Field = "ProductID";
        private string _conC03Field = "VoucherID";

        private List<OrderProduct> _listProduct;
        private List<TbOderDetail> _lstOrderDetail;
        public ConfirmOrderController(DBContext context)
        {
            _context = context;
            _res = new BaseResponse<DTO_Order.ConfirmOrderResponse>()
            {
                Status = StatusCodes.Status200OK.ToString(),
                Data = null
            };
            _response = new DTO_Order.ConfirmOrderResponse();
            _listProduct = new List<OrderProduct>();
            _lstOrderDetail = new List<TbOderDetail>();
        }
        public void AccessDatabase()
        {
            //_response.orderCode = _order.code;
           // _response.voucherCode = voucher;
            _response.accountCode = account.Name;
            _response.totalAmount = _order.TotalAmount;
            //_response.addressDelivery = addressDelivery.WardName + " " + addressDelivery.DistrictName + " " + addressDelivery.ProvinceName;
            //_response.PaymentMethodName ="";
            //_response.voucherCodes = voucher.Code;
            //_response.description = _request.description;
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
            addressDelivery = _context.TbAdressDeliveries.Where(a => a.Id == _request.addressDeliveryId && a.IsDelete == false).FirstOrDefault();
            _order = new TbOrder()
            {
                Id = Guid.NewGuid(),
                //Code = "ACV_" + DateTime.Now.Millisecond,
                TotalAmount = _request.totalAmount,
                AcountId = _request.UserId,
                //PaymentMethodId = _request.paymentMethodId,
                //VoucherCode = _request.voucherCode != null ? string.Join(",", _request.voucherCode) : null,
                VoucherId = _request.voucherId,
                //AmountShip = _request.amountShip,
                //CustomerId = customer.Id,
               // PhoneNumberCustomer = account.PhoneNumber,
                //AddressDeliveryId = _request.addressDeliveryId,
                //OrderCounter = false,
                //Defautl
                CreateBy = _request.AdminId ?? _request.UserId,
                CreateDate = DateTime.Now,
                Status = Utility.Utility.ORDER_STATUS_PREPARE_GOODS
            };
            foreach (var i in _listProduct)
            {
                _orderDetail = new TbOderDetail()
                {
                    Id = Guid.NewGuid(),
                    OrderId = _order.Id,
                    ProductId = i.productId,
                    Quantity = i.quantity
                };
                _lstOrderDetail.Add(_orderDetail);
                //_response.products.Add(i);
            }
        }

        public void PreValidation()
        {
            ACV_Exception ACV_Exception;
            if (_request.product != null)
            {
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
                            //price = model.Price,
                            //weight = model.Weight,
                            quantity = item.quantity.Value,
                            url = image != null ? image.Url : ""
                        };
                        _listProduct.Add(product);
                    }
                    if (model == null)
                    {
                        ACV_Exception = new ACV_Exception();
                        //To-do: Lay thong message text tu message code
                        ACV_Exception.Messages.Add(Message.CreateErrorMessage(_apiCode, _conC02, "Sản phẩm có mã :" + model.Code ?? "" + Utility.Utility.PRODUCT_NOTFOUND, _conC02Field));
                        throw ACV_Exception;
                    }
                }
            }
            else
            {
                ACV_Exception = new ACV_Exception();
                //To-do: Lay thong message text tu message code
                ACV_Exception.Messages.Add(Message.CreateErrorMessage(_apiCode, _conC01, Utility.Utility.ORDER_CARTDETAIL_NOTFOUND, _conC01Field));
                throw ACV_Exception;
            }
        }

        public BaseResponse<DTO_Order.ConfirmOrderResponse> Process(DTO_Order.ConfirmOrderRequest request)
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
