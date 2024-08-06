namespace DATN_ACV_DEV.Payload.DataRequest
{
    public class VnPaymentRequestModel
    {
        public string OrderId { get; set; }
        public string FullName { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
