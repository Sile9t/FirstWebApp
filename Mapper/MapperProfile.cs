using AutoMapper;
using FirstWebApp.Dto;
using FirstWebApp.Models;

namespace FirstWebApp.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<ProductGroup, ProductGroupDto>().ReverseMap();
        }
    }
}
