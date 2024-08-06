using DATN_ACV_DEV.Constant;
using DATN_ACV_DEV.Entity_ALB;
using DATN_ACV_DEV.Payload.Converter;
using DATN_ACV_DEV.Payload.DataRequest;
using DATN_ACV_DEV.Repository.Interface;
using DATN_ACV_DEV.Service.IServices;
using Microsoft.AspNetCore.Mvc;

namespace DATN_ACV_DEV.Controllers.Bill
{
    [Route(Constants.AppSettings.DEFAULT_CONTROLLER_ROUTE)]
    [ApiController]
    public class BillController : Controller
    {
        private readonly IBillServices _billServices;
        private readonly IBaseRepositories<TbOrder> _baseBillRepositories;
        private readonly IVnPayServices _vnPayService;

        public BillController(IBillServices billServices, IBaseRepositories<TbOrder> baseBillRepositories, IVnPayServices vnPayService, Converter_Order converter)
        {
            _billServices = billServices;
            _baseBillRepositories = baseBillRepositories;
            _vnPayService = vnPayService;
            _converter = converter;
        }

        private readonly Converter_Order _converter;
        [HttpPost("VNPay")]
        public async Task<IActionResult> ThanhToanVNpay(Guid id)
        {
            var bill = await _baseBillRepositories.FindAsync(id);
            if (bill.BillStatusId == 2)
            {
                return NotFound(new { message = "This bill has already been paid." });
            }
            var vnPayModel = new VnPaymentRequestModel
            {
                Amount = bill.TotalAmount,
                CreatedDate = DateTime.Now,
                Description = $"{bill.Description}",
                FullName = bill.NameCustomer,
                OrderId = bill.Id.ToString()
            };
            return Ok(new { status = StatusCodes.Status200OK, message = "Moi ban thanh toan online", url = await _vnPayService.CreatePaymentUrl(HttpContext, vnPayModel, id) });
        }
        [HttpGet("PaymentCallBack")]
        public async Task<IActionResult> PaymentCallBack()
        {
            var response = _vnPayService.PaymentExecute(Request.Query);

            if (response == null || response.VnPayResponseCode != "00")
            {
                return BadRequest(new { status = StatusCodes.Status400BadRequest, message = $"Lỗi thanh toán VN Pay: {response.VnPayResponseCode}" });

            }
            var order = await _baseBillRepositories.SingleOrDefaultAsync(x => x.Id.ToString() ==response.OrderId);
            if (order == null)
            {
                return NotFound(new { message = "Bill not found" });
            }

            order.BillStatusId = 2;
            await _baseBillRepositories.UpdateAsync(order);
            return Ok(new { status = StatusCodes.Status200OK, message = "Thanh toán VNPay thành công", data = _converter.EntityToDTO(order) });
        }
    }
}
