using AutoMapper;
using FirstWebApp.Abstractions;
using FirstWebApp.Data;
using FirstWebApp.Dto;
using FirstWebApp.Models;

namespace FirstWebApp.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly StorageContext _context;
        private readonly IMapper _mapper;

        public ProductRepository(StorageContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int AddProduct(ProductDto product)
        {
            if (_context.Products.Any(x => x.Name == product.Name))
                throw new Exception("Product is already axist!");

            var entity = _mapper.Map<Product>(product);
            _context.Add(entity);
            _context.SaveChanges();

            return entity.Id;
        }

        public ProductDto DeleteProduct(int id)
        {
            throw new NotImplementedException;
        }

        public IEnumerable<ProductDto> GetAllProducts()
        {
            var listDto = _context.Products.Select(_mapper.Map<ProductDto>).ToList();

            return listDto;
        }
    }
}
