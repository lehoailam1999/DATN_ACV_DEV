using DATN_ACV_DEV.Entity_ALB;
using DATN_ACV_DEV.Payload.Converter;
using DATN_ACV_DEV.Payload.DataResponse;
using DATN_ACV_DEV.Payload.Response;
using DATN_ACV_DEV.Repository.Interface;
using DATN_ACV_DEV.Service.IServices;

namespace DATN_ACV_DEV.Service.Services
{
    public class ProductServices : IProductServices
    {
        private readonly Converter_Product _converter;
        private readonly IBaseRepositories<TbProduct> _baseRepositories;

        public ProductServices(Converter_Product converter, IBaseRepositories<TbProduct> baseRepositories)
        {
            _converter = converter;
            _baseRepositories = baseRepositories;
        }

        public async Task<ResponseObject<Response_Product>> GetProductById(Guid id)
        {
            ResponseObject<Response_Product> responseObject = new ResponseObject<Response_Product>();

            var product = await _baseRepositories.GetByGuidIdAsync(id);
            if (product == null)
            {
                return responseObject.ResponseError(StatusCodes.Status404NotFound, "Khong co san pham", null);
            }
            return responseObject.ResponseSuccess("San pham", _converter.EntityToDTO(product));
        }

        public async Task<Response_Pagination<Response_Product>> ListProduct(int pageNumber, int pageSize)
        {
            Response_Pagination<Response_Product> responseObject = new Response_Pagination<Response_Product>();
            var listProduct = await _baseRepositories.GetAll();
            if (listProduct == null)
            {
                return responseObject.ResponseError(StatusCodes.Status404NotFound, "Khong co san pham");
            }
            return responseObject.ResponseSuccess("Danh sach san pham", pageNumber, pageSize, _converter.EntityToListDTO(listProduct));
        }

    }
}
