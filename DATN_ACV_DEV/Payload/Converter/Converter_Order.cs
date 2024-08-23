using DATN_ACV_DEV.Entity_ALB;
using DATN_ACV_DEV.Payload.DataResponse;

namespace DATN_ACV_DEV.Payload.Converter
{
    public class Converter_Order
    {
        private readonly DBContext _context;

        public Converter_Order(DBContext context)
        {
            _context = context;
        }
        public ResponseBill EntityToDTO(TbOrder tbOrder)
        {
            ResponseBill response = new ResponseBill()
            {
                TotalAmount = tbOrder.TotalAmount,
                Description = tbOrder.Description,
            };
            return response;
        }
    }
}
