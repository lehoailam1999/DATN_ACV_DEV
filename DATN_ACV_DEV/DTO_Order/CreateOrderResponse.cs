using DATN_ACV_DEV.Model_DTO.Order_DTO;

namespace DATN_ACV_DEV.DTO_Order
{
    public class CreateOrderResponse
    {
        public CreateOrderResponse()
        {
            products = new List<OrderProduct>();
        }
        public List<OrderProduct> products { get; set; }
        public decimal? totalAmountDiscount { get; set; }
        public decimal? amountShip { get; set; }
        public string? addressDelivery { get; set; }
        public decimal? totalAmount { get; set; }
        public string? paymentMethod { get; set; }
        public string? voucherCodes { get; set; }
        public string? description { get; set; }
    }
    public class OrderProduct
    {
        public Guid productId { get; set; }
        public string productName { get; set; }
        public string productCode { get; set; }
        public decimal? price { get; set; }
        public int? weight { get; set; }
        public string? url { get; set; }
        public int quantity { get; set; }

    }
    public class OrderDetailProduct
    {
        public Guid orderId { get; set; }
        public Guid productId { get; set; }
        public string productName { get; set; }
        public decimal price { get; set; }
        public string url { get; set; }
        public int quantity { get; set; }

    }
}
