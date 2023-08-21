using AutoMapper;
using Donouts.Application.Dto.Donouts;
using Donouts.Domain.Entities.Donouts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donouts.Application.Mappings
{
    public class SalesDonoutsProfile : Profile
    {
        public SalesDonoutsProfile()
        {
            CreateMap<SalesDonouts, SalesDonoutsDTO>()
            .ForMember(dto => dto.Id, ent => ent.MapFrom(prop => prop.Id))
            .ForMember(dto => dto.Name, ent => ent.MapFrom(prop => prop.Name))
            .ForMember(dto => dto.User, ent => ent.MapFrom(prop => prop.User))
            .ForMember(dto => dto.TypeDonouts, ent => ent.MapFrom(prop => prop.TypeDonouts))
            .ForMember(dto => dto.Amount, ent => ent.MapFrom(prop => prop.Amount))
            .ForMember(dto => dto.SaleDate, ent => ent.MapFrom(prop => prop.SaleDate));
        }
    }
}
