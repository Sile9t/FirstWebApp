using FirstWebApp.Abstractions;
using FirstWebApp.Data;
using FirstWebApp.Dto;
using FirstWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstWebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _repository;

        public ProductController(IProductRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("add_product")]
        public ActionResult<int> AddProduct(ProductDto product)
        {
            try
            {
                return Ok(_repository.AddProduct(product));
            }
            catch (Exception ex) { return StatusCode(409); }
        }

        [HttpGet("get_all_products")]
        public ActionResult<IEnumerable<Product>> GetAllProducts()
        {
            return Ok(_repository.GetAllProducts());
        }

        [HttpDelete("delete_product")]
        public ActionResult<Product> DeleteProduct(int id)
        {
            using (var context = new StorageContext())
            {
                var product = context.Products.FirstOrDefault(x => x.Id == id);

                if (product == null) 
                    return StatusCode(409);

                context.Products.Remove(product);
                context.SaveChanges();

                return Ok(product);
            }
        }
    }
}
