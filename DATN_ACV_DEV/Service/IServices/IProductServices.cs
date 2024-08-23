using DATN_ACV_DEV.Payload.DataResponse;
using DATN_ACV_DEV.Payload.Response;

namespace DATN_ACV_DEV.Service.IServices
{
    public interface IProductServices
    {
        Task<Response_Pagination<Response_Product>> ListProduct(int pageNumber, int pageSize);
        Task<ResponseObject<Response_Product>> GetProductById(Guid id);

    }
}
