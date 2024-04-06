using Auth;
using AutoMapper;
using PI.Domain.Entities;
using PI.Domain.Request;

namespace PI.Domain.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserRequest, UserEntity>().ReverseMap();
            CreateMap<UserLoginRequest, LoginRequest>().ReverseMap();
        }
    }
}