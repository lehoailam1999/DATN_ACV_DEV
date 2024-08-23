﻿using System.ComponentModel.DataAnnotations;

namespace DATN_ACV_DEV.Payload.DataRequest
{
    public class Request_NewPassWord
    {

        [Required(ErrorMessage = "ConfirmCode is required")]
        public string ConfirmCode { get; set; }
        [RegularExpression(@"^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[^\da-zA-Z]).{8,15}$", ErrorMessage = "Password must be between 6 and 20 characters and contain one uppercase letter, one lowercase letter, one digit, and one special character.")]
        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "ConfirmPassword is required")]
        public string ConfirmPassword { get; set; }
    }
}
