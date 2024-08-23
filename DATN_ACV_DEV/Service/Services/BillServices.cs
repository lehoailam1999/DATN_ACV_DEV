using Azure;
using DATN_ACV_DEV.Entity;
using DATN_ACV_DEV.Entity_ALB;
using DATN_ACV_DEV.Payload.Converter;
using DATN_ACV_DEV.Payload.DataResponse;
using DATN_ACV_DEV.Payload.Response;
using DATN_ACV_DEV.Repository.Interface;
using DATN_ACV_DEV.Service.IServices;
using System;

namespace DATN_ACV_DEV.Service.Services
{
    public class BillServices : IBillServices
    {
        private readonly IBaseRepositories<TbOrder> _baseRepositories;
        private readonly IBaseRepositories<TbAccount> _baseUserRepositories;
        private readonly IEmailServices _emailServices;
        private readonly IConfiguration _configuration;
        private readonly ResponseObject<ResponseBill> _response;
        private readonly Converter_Order _converter;
        private readonly IBaseRepositories<ConfirmEmail> _baseConfirmRepositories;
        private readonly IAccountRepositories _accountRepositories;

        public BillServices(IBaseRepositories<TbOrder> baseRepositories, IBaseRepositories<TbAccount> baseUserRepositories, IEmailServices emailServices, IConfiguration configuration, ResponseObject<ResponseBill> response, Converter_Order converter, IBaseRepositories<ConfirmEmail> baseConfirmRepositories, IAccountRepositories accountRepositories)
        {
            _baseRepositories = baseRepositories;
            _baseUserRepositories = baseUserRepositories;
            _emailServices = emailServices;
            _configuration = configuration;
            _response = response;
            _converter = converter;
            _baseConfirmRepositories = baseConfirmRepositories;
            _accountRepositories = accountRepositories;
        }

        public async Task<ResponseObject<ResponseBill>> ThanhToan(int orderId)
        {
            var order = await _baseRepositories.FindAsync(orderId);
            var account = await _baseUserRepositories.SingleOrDefaultAsync(x => x.Id == order.AcountId);

            var cofirmithUserId = await _accountRepositories.GetConfirmEmailByAccountId(account.Id);
            bool delete = await _baseConfirmRepositories.DeleteAsync(cofirmithUserId.Id);
            if (delete == true)
            {
                Random rand = new Random();
                int randomNumber = rand.Next(1000, 10000);

                string confirmationToken = randomNumber.ToString();
                ConfirmEmail confirm = new ConfirmEmail
                {
                    AccountId = account.Id,
                    CodeActive = confirmationToken,
                    ExpiredTime = DateTime.UtcNow.AddHours(24),
                    IsConfirm = false
                };
                await _baseConfirmRepositories.AddAsync(confirm);
                string subject = "Thanh toán thành công";
                string body = "Thanh toán thành công";

                string emailResult = _emailServices.SendEmail(account.Email, subject, body);
                order.BillStatusId = 2;
                await _baseRepositories.UpdateAsync(order);

                return _response.ResponseSuccess($"Thanh toán thành công!{emailResult}", _converter.EntityToDTO(order));
            }
            else
            {
                return _response.ResponseSuccess("Thanh toán không thành công thành công!CHưa gửi được email", null);
            }
        }
    }
}
