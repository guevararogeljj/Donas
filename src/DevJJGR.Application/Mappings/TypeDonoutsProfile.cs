using AutoMapper;
using Donouts.Application.Dto.Donouts;
using Donouts.Domain.Entities.Donouts;


namespace Donouts.Application.Mappings
{
    public class TypeDonoutsProfile : Profile
    {
        public TypeDonoutsProfile()
        {
            CreateMap<TypeDonouts, TypeDonoutsDTO>()
           .ForMember(dto => dto.Id, ent => ent.MapFrom(prop => prop.Id))
           .ForMember(dto => dto.Name, ent => ent.MapFrom(prop => prop.Name));
        }
    }
}


