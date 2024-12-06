using DATN_ACV_DEV.FileBase;

namespace DATN_ACV_DEV.DTO_Order
{
    public class CreateOrderRequest : BaseRequest
    {
        public List<Cart> product { get; set; }
        public string? description { get; set; }
        public Guid? voucherID { get; set; }
        public Guid? paymentMenthodID { get; set; }
        public Guid? AddressDeliveryId { get; set; }

    }  
    public class Cart
    {
        public Guid productId { get; set; }
        public int ? quantity { get; set; } 
    }
}
