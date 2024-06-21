using FirstWebApp.Dto;

namespace FirstWebApp.Repositories
{
    public interface IProductGroupRepository
    {
        int AddProductGroup(ProductGroupDto group);
        List<ProductGroupDto> GetAllProductGroups();
        ProductGroupDto DeleteProductGroup(string name);
    }
}
