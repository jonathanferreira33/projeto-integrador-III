using Auth;
using AutoMapper;
using PI.Domain.DTOs;
using PI.Domain.Entities;
using PI.Domain.Request;

namespace PI.Domain.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserRequest, UserEntity>().ReverseMap();
            CreateMap<UserEntity, UserDto>().ReverseMap();
            CreateMap<UserLoginRequest, LoginRequest>().ReverseMap();
            CreateMap<ProductRequest, ProductEntity>().ReverseMap();
            CreateMap<ProductDto, ProductEntity>().ReverseMap();
        }
    }
}