using FirstWebApp.Models;

namespace FirstWebApp.Abstractions
{
    public interface IProductGroupRepository
    {
        int AddProductGroup();
        List<ProductGroup> GetAllProductGroups();
        ProductGroup DeleteProductGroup(int id);
    }
}
