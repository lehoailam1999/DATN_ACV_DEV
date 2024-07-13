using DATN_ACV_DEV.Entity;
using DATN_ACV_DEV.Payload.DataRequest;
using DATN_ACV_DEV.Payload.DataResponse;
using DATN_ACV_DEV.Payload.Response;

namespace DATN_ACV_DEV.Service.IServices
{
    public interface IAccountServices
    {
        Task<ResponseObject<ResponseRegister>> Register(RequestRegister request);
        Task<ResponseObject<ResponseToken>> Login(RequestLogin request);
        Task<ResponseObject<ConfirmEmail>> ConfirmEmail(string code);
        Task<ResponseObject<string>> ConfirmCreateNewPasWord(Request_NewPassWord request);
        Task<string> ChangePassWord(int id, Request_ChangePassword request);
        Task<ResponseObject<string>> ForgotPassword(string email);
        Task<string> ReNewCode(string email);
    }
}
