using FirstWebApp.Data;
using FirstWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstWebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductGroupController : ControllerBase
    {
        [HttpPost]
        public ActionResult AddProductGroup(string name, string description)
        {
            using (var context = new StorageContext())
            {
                if (context.ProductGroups.Any(x => x.Name == name))
                    return StatusCode(409);

                var group = new ProductGroup { Name = name, Description = description };

                context.ProductGroups.Add(group);
                context.SaveChanges();

                return Ok(group.Id);
            }
        }

        [HttpGet]
        public ActionResult<List<ProductGroup>> GetAllProductGroups()
        {
            using (var context = new StorageContext())
            {
                var list = context.ProductGroups.Select(x 
                    => new ProductGroup { Id = x.Id, Name = x.Name, 
                        Description = x.Description}).ToList();

                return Ok(list);
            }
        }
    }
}
