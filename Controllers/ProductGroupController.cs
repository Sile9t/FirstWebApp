using FirstWebApp.Abstractions;
using FirstWebApp.Data;
using FirstWebApp.Dto;
using FirstWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstWebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductGroupController : ControllerBase
    {
        private readonly IProductGroupRepository _repository;

        public ProductGroupController(IProductGroupRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("add_product_group")]
        public ActionResult<int> AddProductGroup(ProductGroupDto group)
        {
            try
            {
                return Ok(_repository.AddProductGroup(group));
            }
            catch (Exception ex) { return StatusCode(409, ex.Message); }
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

        [HttpDelete]
        public ActionResult<ProductGroup> DeleteProductGroup(int id)
        {
            using (var context = new StorageContext())
            {
                var group = context.ProductGroups.FirstOrDefault(x => x.Id == id);

                if (group == null)
                    return StatusCode(409);

                context.ProductGroups.Remove(group);
                context.SaveChanges();

                return Ok(group);
            }
        }
    }
}
