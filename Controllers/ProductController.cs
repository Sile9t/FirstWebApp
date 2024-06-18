using FirstWebApp.Data;
using FirstWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstWebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        [HttpPost]
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


    }
}
