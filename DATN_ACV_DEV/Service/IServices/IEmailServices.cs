namespace DATN_ACV_DEV.Service.IServices
{
    public interface IEmailServices
    {
        string SendEmail(string mailTo, string subject, string body);

    }
}
