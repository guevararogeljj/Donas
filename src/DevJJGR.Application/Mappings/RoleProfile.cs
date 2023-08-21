using AutoMapper;
using Donouts.Application.Dto.Security;
using Microsoft.AspNetCore.Identity;
namespace Donouts.Application.Mappings
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<IdentityRole, RoleDTO>()
            .ForMember(dto => dto.Id, ent => ent.MapFrom(prop => prop.Id))
            .ForMember(dto => dto.Name, ent => ent.MapFrom(prop => prop.Name));
        }
    }
}
