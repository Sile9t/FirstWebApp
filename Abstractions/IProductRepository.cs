using FirstWebApp.Models;

namespace FirstWebApp.Abstractions
{
    public interface IProductRepository
    {
        int AddProduct();
        IEnumerable<Product> GetAllProducts();
        Product DeleteProduct(int id);
    }
}
