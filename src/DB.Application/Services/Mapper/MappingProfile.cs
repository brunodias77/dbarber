using System;
using AutoMapper;
using DB.Application.Communications.Requests.Users;
using DB.Domain.Entities;

namespace DB.Application.Services.Mapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Exemplo: Mapeamento entre uma entidade e um DTO
        CreateMap<User, CreateUserRequestJson>();
    }

    private void RequestToDomain()
    {
        // Mapeamento de CreateUserRequestJson para User
        // CreateMap<CreateUserRequestJson, User>()
        //     .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
        //     .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
        //     .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
        //     .ForMember(dest => dest.password, opt => opt.MapFrom(src => src.Password))
        //     .ForMember(dest => dest.avatar, opt => opt.MapFrom(src => src.Avatar));
    }
}


