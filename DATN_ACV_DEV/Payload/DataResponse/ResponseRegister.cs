namespace DATN_ACV_DEV.Payload.DataResponse
{
    public class ResponseRegister
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public Guid? CustomerId { get; set; }
        public Guid? AddressDeliveryId { get; set; }
    }
}
