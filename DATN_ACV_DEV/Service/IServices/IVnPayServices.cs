using DATN_ACV_DEV.Payload.DataRequest;
using DATN_ACV_DEV.Payload.DataResponse;

namespace DATN_ACV_DEV.Service.IServices
{
    public interface IVnPayServices
    {
        Task<string> CreatePaymentUrl(HttpContext context, VnPaymentRequestModel model, int billId);
        VnPaymentResponseModel PaymentExecute(IQueryCollection collections);
    }
}
