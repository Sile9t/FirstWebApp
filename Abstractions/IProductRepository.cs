using FirstWebApp.Dto;

namespace FirstWebApp.Abstractions
{
    public interface IProductRepository
    {
        int AddProduct(ProductDto product);
        IEnumerable<ProductDto> GetAllProducts();
        ProductDto DeleteProduct(int id);
    }
}
