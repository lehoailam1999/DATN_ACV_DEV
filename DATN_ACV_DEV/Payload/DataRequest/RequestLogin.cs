using System.ComponentModel.DataAnnotations;

namespace DATN_ACV_DEV.Payload.DataRequest
{
    public class RequestLogin
    {
        [Required(ErrorMessage = "UserName is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "PassWord is required")]
        public string Password { get; set; }
    }
}
