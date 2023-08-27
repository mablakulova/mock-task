using AutoMapper;
using DAL.Entities;
using Shortener.Api.Dtos;

namespace Shortener.Api;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<LinkEntity, LinkDto>();
    }
}
