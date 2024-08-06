using DATN_ACV_DEV.Payload.DataResponse;
using DATN_ACV_DEV.Payload.Response;

namespace DATN_ACV_DEV.Service.IServices
{
    public interface IBillServices
    {
        Task<ResponseObject<ResponseBill>> ThanhToan(int orderId);

    }
}
