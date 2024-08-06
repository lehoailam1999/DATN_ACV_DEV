using DATN_ACV_DEV.Constant;
using DATN_ACV_DEV.Payload.DataRequest;
using DATN_ACV_DEV.Service.IServices;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DATN_ACV_DEV.Controllers.Account
{
    [Route(Constants.AppSettings.DEFAULT_CONTROLLER_ROUTE)]

    [ApiController]

    public class AccountController : Controller
    {
        private readonly IAccountServices _service;
        public AccountController(IAccountServices service)
        {
            _service = service;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(RequestRegister request_Register)
        {
            var register = await _service.Register(request_Register);
            return Ok(register);
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(RequestLogin request)
        {
            return Ok(await _service.Login(request));
        }
        [HttpPost("confirmEmail")]
        public async Task<IActionResult> ConfirmEmail(string code)
        {
            return Ok(await _service.ConfirmEmail(code));
        }
        [HttpPut("ChangePassWord")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> ChagePassWord(Request_ChangePassword request)
        {
            int id = int.Parse(HttpContext.User.FindFirst("Id").Value);

            return Ok(await _service.ChangePassWord(id, request));
        }
        [HttpGet("ForgotPassword")]
        public async Task<IActionResult> ForgotPassword(string email)
        {
            return Ok(await _service.ForgotPassword(email));
        }
        [HttpGet("ReNewCodeToConfirm")]
        public async Task<IActionResult> ReNewCodeToConfirm(string email)
        {
            return Ok(await _service.ReNewCode(email));
        }
        [HttpPut("CreateNewPassWord")]
        public async Task<IActionResult> CreateNewPassWord(Request_NewPassWord request)
        {
            return Ok(await _service.ConfirmCreateNewPasWord(request));

        }
    }
}
