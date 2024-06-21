using FirstWebApp.Dto;
using Microsoft.AspNetCore.Mvc;

namespace FirstWebApp.Abstractions
{
    public interface IProductRepository
    {
        int AddProduct(ProductDto product);
        IEnumerable<ProductDto> GetAllProducts();
        ProductDto DeleteProduct(string name);
        string GetCsv();
    }
}
