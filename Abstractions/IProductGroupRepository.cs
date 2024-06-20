using FirstWebApp.Dto;

namespace FirstWebApp.Abstractions
{
    public interface IProductGroupRepository
    {
        int AddProductGroup(ProductGroupDto group);
        List<ProductGroupDto> GetAllProductGroups();
        ProductGroupDto DeleteProductGroup(int id);
    }
}
