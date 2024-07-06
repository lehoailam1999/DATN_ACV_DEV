using DATN_ACV_DEV.Entity_ALB;
using DATN_ACV_DEV.Payload.DataResponse;

namespace DATN_ACV_DEV.Payload.Converter
{
    public class ConverterAccount
    {
        public async Task<ResponseRegister> EntityToDTO(TbAccount tbAccount)
        {
            ResponseRegister response = new ResponseRegister()
            {
                Name = tbAccount.Name,
                Email = tbAccount.Email,
                PhoneNumber = tbAccount.PhoneNumber,
                Password = tbAccount.Password,
                CustomerId =tbAccount.CustomerId ,
                AddressDeliveryId = tbAccount.AddressDeliveryId,
            };
            return response;
        }
    }
}
