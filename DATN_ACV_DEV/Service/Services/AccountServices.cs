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

        public AccountServices(ResponseObject<ResponseRegister> response, ConverterAccount converter, IBaseRepositories<TbAccount> baseRepositories, IBaseRepositories<Role> baseRolesRepositories, IAccountRepositories accountRepositories, IConfiguration configuration, IBaseRepositories<RefreshToken> baseRefreshRepositories)
        {
            _response = response;
            _converter = converter;
            _baseRepositories = baseRepositories;
            _baseRolesRepositories = baseRolesRepositories;
            _accountRepositories = accountRepositories;
            _configuration = configuration;
            _baseRefreshRepositories = baseRefreshRepositories;
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
            account.UpdateDate= DateTime.Now;
            account.CreateDate = DateTime.Now;
            account.IsDelete = "1";
            await _baseRepositories.AddAsync(account);
            return _response.ResponseSuccess("Register successfully", await _converter.EntityToDTO(account));
        }
    }
}
