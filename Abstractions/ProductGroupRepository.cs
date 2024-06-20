using AutoMapper;
using FirstWebApp.Data;
using FirstWebApp.Dto;
using FirstWebApp.Models;

namespace FirstWebApp.Abstractions
{
    public class ProductGroupRepository : IProductGroupRepository
    {
        private readonly StorageContext _context;
        private readonly IMapper _mapper;

        public ProductGroupRepository(StorageContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int AddProductGroup(ProductGroupDto group)
        {
            if (_context.ProductGroups.Any(x => x.Name == group.Name))
                throw new Exception("Group is already exist!");

            var entity = _mapper.Map<ProductGroup>(group);
            _context.Add(entity);
            _context.SaveChanges();

            return entity.Id;
        }

        public ProductGroupDto DeleteProductGroup(int id)
        {
            throw new NotImplementedException();
        }

        public List<ProductGroupDto> GetAllProductGroups()
        {
            var list = _context.ProductGroups.Select(_mapper.Map<ProductGroupDto>).ToList();

            return list;
        }
    }
}
