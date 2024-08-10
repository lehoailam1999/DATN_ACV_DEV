using DATN_ACV_DEV.Model_DTO.Product_DTO;
using DATN_ACV_DEV.Payload.DataRequest;
using DATN_ACV_DEV.Service.IServices;
using Microsoft.AspNetCore.Mvc;

namespace DATN_ACV_DEV.Controllers.Product
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductServices productServices;

        public ProductController(IProductServices productServices)
        {
            this.productServices = productServices;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllProduct(int pageNumber, int pageSize)
        {
            var listProduct = await productServices.ListProduct(pageNumber,pageSize);
            return Ok(listProduct);
        }
        [HttpGet("/:id")]
        public async Task<IActionResult> GetProductById(Guid id)
        {
            var product = await productServices.GetProductById(id);
            return Ok(product);
        }
    }
}
