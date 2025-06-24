using AutoMapper;
using Domain.Core.Menu;
using Horeca.DTOs.Core.MenuManagement;

namespace Application.Configuration;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Menu, MenuDto>().ReverseMap();
        CreateMap<MenuGroup, MenuGroupDto>().ReverseMap();
        CreateMap<MenuGroup, UpdateMenuGroupDto>().ReverseMap();
        CreateMap<MenuItem, MenuItemDto>().ReverseMap();
    }
}