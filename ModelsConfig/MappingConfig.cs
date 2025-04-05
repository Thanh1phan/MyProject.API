using AutoMapper;
using MyProject.API.Data.Entities;
using MyProject.API.Models.Dto;

namespace MyProject.API.Config
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<ProductCreateDto, M01C>();
            CreateMap<ProductUpdateDto, M01C>();
            CreateMap<ProductDto, M01C>().ReverseMap();
            CreateMap<K01T, UserDto>().ReverseMap();
            CreateMap<RegisterationDto, K01T>();
        }
    }
}
