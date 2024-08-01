using DATN_ACV_DEV.FileBase;

namespace DATN_ACV_DEV.DTO_Order
{
    public class ConfirmOrderRequest : BaseRequest
    {
        public List<Cart> product { get; set; }
        public decimal? totalAmountDiscount { get; set; }
        public decimal? amountShip { get; set; }
        public decimal totalAmount { get; set; }
        public Guid? addressDeliveryId { get; set; }
        public string? voucherCode { get; set; }
        public Guid? voucherId { get; set; }

    } 
}
