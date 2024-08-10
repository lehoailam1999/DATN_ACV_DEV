namespace DATN_ACV_DEV.Payload.DataRequest
{
    public class Request_Product
    {
        public string Name { get; set; } = null!;

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public int? Status { get; set; }

        public string? Description { get; set; }

        public decimal? PriceNet { get; set; }

        public Guid? UpdateBy { get; set; }

        public Guid CreateBy { get; set; }


        public Guid CategoryId { get; set; }

        public string? Code { get; set; }

    }
}
