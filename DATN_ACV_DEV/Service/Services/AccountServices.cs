using DATN_ACV_DEV.Entity;
using DATN_ACV_DEV.Entity_ALB;
using DATN_ACV_DEV.Payload.Converter;
using DATN_ACV_DEV.Payload.DataRequest;
using DATN_ACV_DEV.Payload.DataResponse;
using DATN_ACV_DEV.Payload.Response;
using DATN_ACV_DEV.Repository.Interface;
using DATN_ACV_DEV.Service.IServices;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using BcryptNet = BCrypt.Net.BCrypt;

namespace DATN_ACV_DEV.Service.Services
{
    public class AccountServices : IAccountServices
    {
        private readonly ResponseObject<ResponseRegister> _response;
        private readonly ConverterAccount _converter;
        private readonly IBaseRepositories<TbAccount> _baseRepositories;
        private readonly IBaseRepositories<Role> _baseRolesRepositories;
        private readonly IAccountRepositories _accountRepositories;
        private readonly IConfiguration _configuration;
        private readonly IBaseRepositories<RefreshToken> _baseRefreshRepositories;
        private readonly IEmailServices _emailServices;
        private readonly IBaseRepositories<ConfirmEmail> _baseConfirmRepositories;

        public AccountServices(ResponseObject<ResponseRegister> response, ConverterAccount converter, IBaseRepositories<TbAccount> baseRepositories, IBaseRepositories<Role> baseRolesRepositories, IAccountRepositories accountRepositories, IConfiguration configuration, IBaseRepositories<RefreshToken> baseRefreshRepositories, IEmailServices emailServices, IBaseRepositories<ConfirmEmail> baseConfirmRepositories)
        {
            _response = response;
            _converter = converter;
            _baseRepositories = baseRepositories;
            _baseRolesRepositories = baseRolesRepositories;
            _accountRepositories = accountRepositories;
            _configuration = configuration;
            _baseRefreshRepositories = baseRefreshRepositories;
            _emailServices = emailServices;
            _baseConfirmRepositories = baseConfirmRepositories;
        }

        public string GennerateRefreshToKen()
        {
            var random = new byte[32];
            using (var item = RandomNumberGenerator.Create())
            {
                item.GetBytes(random);
                return Convert.ToBase64String(random);
            }
        }
        public async Task<ResponseToken> GenerateAccessToken(TbAccount user)
        {
            var jwtTokenHandle = new JwtSecurityTokenHandler();
            var secretKeyByte = System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:SecretKey").Value);
            var role = await _baseRolesRepositories.FindAsync(user.RoleId);
            if (role == null)
            {
                throw new Exception("Role not found for the user.");
            }
            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new[]
                {
                    new Claim("Id", user.Id.ToString()),
                    /*new Claim("Email", user.Email),
                    new Claim("RoleId", role.Id.ToString()),*/
                    new Claim(ClaimTypes.Role, role.Code)
                }),
                Expires = DateTime.Now.AddMinutes(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKeyByte), SecurityAlgorithms.HmacSha256Signature)

            };
            // Tạo jwt
            var token = jwtTokenHandle.CreateToken(tokenDescription);
            var accessToken = jwtTokenHandle.WriteToken(token);
            var refreshToken = GennerateRefreshToKen();
            RefreshToken rf = new RefreshToken()
            {
                Token = refreshToken,
                ExpiresTime = DateTime.Now.AddDays(1),
                AccountId = user.Id
            };
            await _baseRefreshRepositories.AddAsync(rf);
            ResponseToken dataResponseToken = new ResponseToken()
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken
            };
            return dataResponseToken;
        }
        public async Task<ResponseObject<ResponseToken>> Login(RequestLogin request)
        {
            ResponseObject<ResponseToken> response = new ResponseObject<ResponseToken>();
            var user = await _accountRepositories.GetAccountByUsername(request.Name);
            if (user == null)
            {
                return response.ResponseError(StatusCodes.Status404NotFound, "Mật khẩu hoặc tài khoản không đúng", null);
            }
            if (string.IsNullOrWhiteSpace(request.Name) || string.IsNullOrWhiteSpace(request.Password))
            {
                return response.ResponseError(StatusCodes.Status400BadRequest, "Vui lòng điền đầy đủ thông tin!", null);
            }
            
            
            var checkPassword = BcryptNet.Verify(request.Password, user.Password);

            if (!checkPassword)
            {
                return response.ResponseError(StatusCodes.Status404NotFound, "Mật khẩu hoặc tài khoản không đúng", null);
            }
            return response.ResponseSuccess("Đăng nhập thành công!", await GenerateAccessToken(user));
        }


        public async Task<ResponseObject<ResponseRegister>> Register(RequestRegister request)
        {

            TbAccount account = new TbAccount();
            account.Id = new Guid();
            var userWithUserName = await _accountRepositories.GetAccountByUsername(request.Name);
            if (userWithUserName != null)
            {
                return new ResponseObject<ResponseRegister>
                {
                    Status = StatusCodes.Status400BadRequest,
                    Message = "Name already exists!!!!!",
                    Data = null
                };
            }
            account.Name = request.Name;

            account.Password = BcryptNet.HashPassword(request.Password);
            var userWithPhone = await _accountRepositories.GetPhoneByUsername(request.PhoneNumber);
            if (userWithPhone != null)
            {
                return new ResponseObject<ResponseRegister>
                {
                    Status = StatusCodes.Status400BadRequest,
                    Message = "Phone Number already xists!!!!",
                    Data = null
                };
            }
            account.PhoneNumber = request.PhoneNumber;
            var userWithEmail = await _accountRepositories.GetEmailByUsername(request.Email);
            if (userWithPhone != null)
            {
                return new ResponseObject<ResponseRegister>
                {
                    Status = StatusCodes.Status400BadRequest,
                    Message = "Email already xists!!!!",
                    Data = null
                };
            }
            account.Email = request.Email;
            account.RoleId = 1;
            account.CustomerId = request.CustomerId;
            account.AddressDeliveryId = request.AddressDeliveryId;
            account.UpdateDate = DateTime.Now;
            account.CreateDate = DateTime.Now;
            account.IsDelete = "1";
            await _baseRepositories.AddAsync(account);
            Random rand = new Random();
            int randomNumber = rand.Next(1000, 10000);
            string confirmationToken = randomNumber.ToString();
            ConfirmEmail confirmEmail = new ConfirmEmail
            {
                AccountId = account.Id,
                CodeActive = confirmationToken,
                ExpiredTime = DateTime.UtcNow.AddHours(24),
                IsConfirm = false
            };
            await _baseConfirmRepositories.AddAsync(confirmEmail);
            string subject = "Test";
            string body = "Xin chào :" + confirmationToken;
            string emailResult = _emailServices.SendEmail(account.Email, subject, body);
            return _response.ResponseSuccess("Register successfully", await _converter.EntityToDTO(account));
        }
        public async Task<ResponseObject<ConfirmEmail>> ConfirmEmail(string code)
        {
            ResponseObject<ConfirmEmail> _response = new ResponseObject<ConfirmEmail>();
            var confirmEmail = await _accountRepositories.GetConfirmEmailByCode(code);

            if (confirmEmail == null)
            {
                return _response.ResponseError(StatusCodes.Status400BadRequest, "Mã xác nhận không hợp lệ ", null);
            }
            if (confirmEmail.ExpiredTime <= DateTime.UtcNow)
            {
                return _response.ResponseError(StatusCodes.Status404NotFound, "Mã xác nhận đã hết hạn hoặc người dùng không tồn tại", null);
            }

            var user = await _baseRepositories.FindAsync(confirmEmail.AccountId);
            if (user == null)
            {
                return _response.ResponseError(StatusCodes.Status404NotFound, "Mã xác nhận đã hết hạn hoặc người dùng không tồn tại", null);
            }

            await _baseRepositories.UpdateAsync(user);
            // Update ConfirmEmail
            confirmEmail.IsConfirm = true;
            await _baseConfirmRepositories.UpdateAsync(confirmEmail);

            return _response.ResponseSuccess("Xác nhận email thành công", null);
        }
        public async Task<ResponseObject<string>> ForgotPassword(string email)
        {
            var userWithEmail = await _accountRepositories.GetEmailByUsername(email);
            if (userWithEmail == null)
            {
                return new ResponseObject<string>
                {
                    Status = StatusCodes.Status404NotFound,
                    Message = "Email chưa được đăng kí!!!!",
                    Data = null
                };
            }
            var cofirmithUserId = await _accountRepositories.GetConfirmEmailByAccountId(userWithEmail.Id);
            bool delete = await _baseConfirmRepositories.DeleteAsync(cofirmithUserId.Id);
            if (delete == true)
            {
                Random rand = new Random();
                int randomNumber = rand.Next(1000, 10000);
                string confirmationToken = randomNumber.ToString();
                ConfirmEmail confirm = new ConfirmEmail
                {
                    AccountId = userWithEmail.Id,
                    CodeActive = confirmationToken,
                    ExpiredTime = DateTime.UtcNow.AddHours(24),
                    IsConfirm = false
                };
                await _baseConfirmRepositories.AddAsync(confirm);
                string subject = "Forgot Password";
                string body = "Mã xác nhận là :" + confirmationToken;
                string emailResult = _emailServices.SendEmail(email, subject, body);
                return new ResponseObject<string>
                {
                    Status = StatusCodes.Status200OK,
                    Message = $"{emailResult}!Mời bạn kiểm tra email của bạn!",
                    Data = null
                };
            }
            else
            {
                return new ResponseObject<string>
                {
                    Status = StatusCodes.Status400BadRequest,
                    Message = "Gửi mã OTP tới email của bạn đã bị gián đoạn",
                    Data = null
                };
            }
        }
        public async Task<string> ChangePassWord(int id, Request_ChangePassword request)
        {
            var user = await _baseRepositories.FindAsync(id);
            if (user == null)
            {
                return "Bạn không đăng trong phiên đăn nhập";
            }
            bool checkPassword = BcryptNet.Verify(request.OldPassword, user.Password);
            if (!checkPassword)
            {
                return "Incorrect password";
            }
            if (!request.NewPassword.Equals(request.ConfirmPassword))
            {
                return "Password do not macth";
            }
            user.Password = BcryptNet.HashPassword(request.NewPassword);
            await _baseRepositories.UpdateAsync(user);
            return "Change password success";
        }
        public async Task<ResponseObject<string>> ConfirmCreateNewPasWord(Request_NewPassWord request)
        {
            var confiremEmail = await _accountRepositories.GetConfirmEmailByConFirmCode(request.ConfirmCode);
            if (confiremEmail == null)
            {
                return new ResponseObject<string>
                {
                    Status = StatusCodes.Status404NotFound,
                    Message = "Mã xác nhận không đúng",
                    Data = null
                };
            }
            if (!request.Password.Equals(request.ConfirmPassword))
            {
                return new ResponseObject<string>
                {
                    Status = StatusCodes.Status400BadRequest,
                    Message = "Mật khẩu không trùng khớp",
                    Data = null
                };
            }
            var user = await _baseRepositories.FindAsync(confiremEmail.AccountId);
            user.Password = BcryptNet.HashPassword(request.Password);
            await _baseRepositories.UpdateAsync(user);
            confiremEmail.IsConfirm = true;
            await _baseConfirmRepositories.UpdateAsync(confiremEmail);
            return new ResponseObject<string>
            {
                Status = StatusCodes.Status200OK,
                Message = "Tạo mật khẩu mới thành công",
                Data = null
            };


        }
        public async Task<string> ReNewCode(string email)
        {
            var userWithEmail = await _accountRepositories.GetEmailByUsername(email);
            if (userWithEmail == null)
            {
                return "Email don't exists!!!!";
            }
            var cofirmithUserId = await _accountRepositories.GetConfirmEmailByAccountId(userWithEmail.Id);
            bool delete = await _baseConfirmRepositories.DeleteAsync(cofirmithUserId.Id);
            if (delete == true)
            {
                Random rand = new Random();
                int randomNumber = rand.Next(1000, 10000);

                string confirmationToken = randomNumber.ToString();
                ConfirmEmail confirm = new ConfirmEmail
                {
                    AccountId = userWithEmail.Id,
                    CodeActive = confirmationToken,
                    ExpiredTime = DateTime.UtcNow.AddHours(24),
                    IsConfirm = false
                };
                await _baseConfirmRepositories.AddAsync(confirm);
                string subject = "Renew Password";
                string body = "Mã xác nhận là :" + confirmationToken;
                string emailResult = _emailServices.SendEmail(email, subject, body);
                return $"{emailResult}! Mời bạn kiểm tra Email";
            }
            else
            {
                return "Bạn chưa gửi được mã xác nhận";
            }
        }
    }
}
