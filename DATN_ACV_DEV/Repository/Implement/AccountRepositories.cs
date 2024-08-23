using DATN_ACV_DEV.Entity;
using DATN_ACV_DEV.Entity_ALB;
using DATN_ACV_DEV.Payload.DataRequest;
using DATN_ACV_DEV.Payload.DataResponse;
using DATN_ACV_DEV.Payload.Response;
using DATN_ACV_DEV.Repository.Interface;
using DATN_ACV_DEV.Service.IServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;

namespace DATN_ACV_DEV.Repository.Implement
{
    public class AccountRepositories : IAccountRepositories
    {
        private readonly DBContext _context;

        public AccountRepositories(DBContext context)
        {
            _context = context;
        }

       

        public async Task<TbAccount> GetAccountByUsername(string name)
        {
            var account = await _context.TbAccounts.SingleOrDefaultAsync(x => x.Name.ToLower().Equals(name.ToLower()));
            return account;

        }

        public async Task<ConfirmEmail> GetConfirmEmailByCode(string code)
        {
            var confirmEmail = await _context.ConfirmEmails.SingleOrDefaultAsync(x => x.CodeActive.ToLower().Equals(code.ToLower()));
            return confirmEmail;
        }

        public async Task<ConfirmEmail> GetConfirmEmailByAccountId(Guid accountId)
        {
            var confirmEmail = await _context.ConfirmEmails.SingleOrDefaultAsync(x => x.AccountId.Equals(accountId));
            return confirmEmail;
        }

        public async Task<TbAccount> GetEmailByUsername(string email)
        {
            var account = await _context.TbAccounts.SingleOrDefaultAsync(x => x.Email.ToLower().Equals(email.ToLower()));
            return account;
        }

        public async Task<TbAccount> GetPhoneByUsername(string phoneNumber)
        {
            var account = await _context.TbAccounts.SingleOrDefaultAsync(x => x.PhoneNumber.ToLower().Equals(phoneNumber.ToLower()));
            return account;
        }

        public async Task<ConfirmEmail> GetConfirmEmailByConFirmCode(string code)
        {
            var confirmEmail = await _context.ConfirmEmails.SingleOrDefaultAsync(x => x.CodeActive.Equals(code));
            return confirmEmail;
        }
    }
}
