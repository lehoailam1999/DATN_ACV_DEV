using DATN_ACV_DEV.Payload.DataRequest;
using DATN_ACV_DEV.Payload.DataResponse;
using DATN_ACV_DEV.Payload.Response;

namespace DATN_ACV_DEV.Service.IServices
{
    public interface IAccountServices
    {
        Task<ResponseObject<ResponseRegister>> Register(RequestRegister request);
        Task<ResponseObject<ResponseToken>> Login(RequestLogin request);


    }
}
