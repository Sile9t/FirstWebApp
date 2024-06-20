using FirstWebApp.Data;
using FirstWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstWebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        [HttpPost("add_product")]
        public ActionResult<int> AddProduct(string name, string description, decimal price)
        {
            using (var context = new StorageContext())
            {
                if (context.Products.Any(x => x.Name == name))
                    return StatusCode(409);

                var product = new Product() {Name = name, Desctiption = description, Price = price };

                context.Products.Add(product);
                context.SaveChanges();
                return Ok(product.Id);
            }
        }

        [HttpGet("get_all_products")]
        public ActionResult<IEnumerable<Product>> GetAllProducts()
        {
            List<Product> list;
            using (var context = new StorageContext())
            {
                list = context.Products.Select(x 
                    => new Product{ Id = x.Id, Name = x.Name, 
                        Desctiption = x.Desctiption, Price = x.Price}).ToList();
            }
            return Ok(list);
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
