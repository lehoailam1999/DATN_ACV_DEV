using DATN_ACV_DEV.Constant;
using DATN_ACV_DEV.Payload.DataRequest;
using DATN_ACV_DEV.Service.IServices;
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
    }
}
