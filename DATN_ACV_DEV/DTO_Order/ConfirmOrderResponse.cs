using DATN_ACV_DEV.FileBase;

namespace DATN_ACV_DEV.DTO_Order
{
    public class ConfirmOrderResponse 
    {
        public Guid id { get; set; }
        public string? orderCode { get; set; }
        public decimal totalAmount { get; set; }
        public string? voucherCode { get; set; }
        public string? accountCode { get; set; }
        public string? nameCustomer { get; set; }
        public string? phoneNumber { get; set; }
        public DateTime createdDate { get; set; }
        public string? PaymentMethodName { get; set; }

    }  
}
