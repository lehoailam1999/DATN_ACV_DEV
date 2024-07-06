using DATN_ACV_DEV.Entity_ALB;

namespace DATN_ACV_DEV.Repository.Interface
{
    public interface IAccountRepositories
    {
        Task<TbAccount> GetAccountByUsername(string name);
        Task<TbAccount> GetPhoneByUsername(string phoneNumber);
        Task<TbAccount> GetEmailByUsername(string email);

    }
}
