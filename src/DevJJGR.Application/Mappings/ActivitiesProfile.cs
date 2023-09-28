using System;
using AutoMapper;
using Donouts.Application.Dto.Activities;

namespace Donouts.Application.Mappings
{
	public class ActivitiesProfile: Profile
    {
		public ActivitiesProfile()
		{
            CreateMap<Donouts.Domain.Entities.Activities.Activities, ActivitiesDTO>()
           .ForMember(dto => dto.Id, ent => ent.MapFrom(prop => prop.Id))
           .ForMember(dto => dto.Name, ent => ent.MapFrom(prop => prop.Name))
           .ForMember(dto => dto.Visible, ent => ent.MapFrom(prop => prop.Visible));
        }
	}
}

