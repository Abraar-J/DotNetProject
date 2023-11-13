using AutoMapper;
using PracticeUdemy.Dto;
using PracticeUdemy.Models;

namespace PracticeUdemy.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Catagory, CatagoryDto>().ReverseMap();
            CreateMap<ProductCreateDto,Product>().ReverseMap();
            CreateMap<Product,ProductCreateDto>().ReverseMap();
            CreateMap<Product,ProductDto>().ReverseMap();
            CreateMap<Product,ProductNavigationalDto>().ReverseMap();
            CreateMap<UpdatePoductDto, Product>().ReverseMap();
        }
    }
}
