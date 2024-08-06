using DATN_ACV_DEV.Payload.DataRequest;
using DATN_ACV_DEV.Payload.DataResponse;
using DATN_ACV_DEV.Service.IServices;

namespace DATN_ACV_DEV.Service.Services
{
    public class VnPayServices : IVnPayServices
    {
        public Task<string> CreatePaymentUrl(HttpContext context, VnPaymentRequestModel model, int billId)
        {
            throw new NotImplementedException();
        }

        public VnPaymentResponseModel PaymentExecute(IQueryCollection collections)
        {
            throw new NotImplementedException();
        }
    }
}
