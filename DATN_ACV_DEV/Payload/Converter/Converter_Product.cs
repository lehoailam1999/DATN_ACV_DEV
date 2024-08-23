using DATN_ACV_DEV.Entity_ALB;
using DATN_ACV_DEV.Payload.DataResponse;

namespace DATN_ACV_DEV.Payload.Converter
{
    public class Converter_Product
    {
        public List<Response_Product> EntityToListDTO(List<TbProduct> tbProduct)
        {

            return tbProduct.Select(item=>new Response_Product
            {

                Id = item.Id,
                Name = item.Name,
                Price = item.Price,
                Quantity = item.Quantity,
                Status = item.Status,
                Description = item.Description,
                PriceNet = item.PriceNet,
                UpdateBy = item.UpdateBy,
                IsDelete = item.IsDelete,
                CreateDate = item.CreateDate,
                CreateBy = item.CreateBy,
                UpdateDate = item.UpdateDate,
                ImageId = item.ImageId,
                CategoryId = item.CategoryId,
                Code = item.Code,
                ExpirationDate = item.ExpirationDate,
            }).ToList();
           
        }
        public Response_Product EntityToDTO(TbProduct tbProduct)
        {
            Response_Product response = new Response_Product()
            {
                Id = tbProduct.Id,
                Name = tbProduct.Name,
                Price = tbProduct.Price,
                Quantity = tbProduct.Quantity,
                Status = tbProduct.Status,
                Description = tbProduct.Description,
                PriceNet = tbProduct.PriceNet,
                UpdateBy = tbProduct.UpdateBy,
                IsDelete = tbProduct.IsDelete,
                CreateDate = tbProduct.CreateDate,
                CreateBy = tbProduct.CreateBy,
                UpdateDate = tbProduct.UpdateDate,
                ImageId = tbProduct.ImageId,
                CategoryId = tbProduct.CategoryId,
                Code = tbProduct.Code,
                ExpirationDate = tbProduct.ExpirationDate,
            };
            return response;
        }
    }
}
