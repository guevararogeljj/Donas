
using AutoMapper;
using Donouts.Application.Dto.Calendar;
using Donouts.Domain.Entities.Calendario;

namespace Donouts.Application.Mappings
{
	public class CalendarioActividadesProfile : Profile
	{
        public CalendarioActividadesProfile()
        {
            CreateMap<CalendarioActividades, CalendarioActividadesDTO>()
            .ForMember(dto => dto.Id, ent => ent.MapFrom(prop => prop.Id))
            .ForMember(dto => dto.ActivityId, ent => ent.MapFrom(prop => prop.ActivityId))
            .ForMember(dto => dto.EventDate, ent => ent.MapFrom(prop => prop.EventDate))
            .ForMember(dto => dto.StartTime, ent => ent.MapFrom(prop => prop.StartTime))
            .ForMember(dto => dto.EndTime, ent => ent.MapFrom(prop => prop.EndTime))
            .ForMember(dto => dto.Comments, ent => ent.MapFrom(prop => prop.Comments))
            .ForMember(dto => dto.ClosedDate, ent => ent.MapFrom(prop => prop.ClosedDate))
            .ForMember(dto => dto.ConfirmDate, ent => ent.MapFrom(prop => prop.ConfirmDate))
            .ForMember(dto => dto.UserCreatedId, ent => ent.MapFrom(prop => prop.UserCreatedId))
            .ForMember(dto => dto.UserCreated, ent => ent.MapFrom(prop => prop.UserCreated))
            .ForMember(dto => dto.ConfirmDate, ent => ent.MapFrom(prop => prop.ConfirmDate))
            .ForMember(dto => dto.UserModifiedId, ent => ent.MapFrom(prop => prop.UserModifiedId))
            .ForMember(dto => dto.UserModified, ent => ent.MapFrom(prop => prop.UserModified))
            .ForMember(dto => dto.IsDeleted, ent => ent.MapFrom(prop => prop.IsDeleted))
            .ForMember(dto => dto.Visible, ent => ent.MapFrom(prop => prop.Visible))
            .ForMember(dto => dto.Name, ent => ent.MapFrom(prop => prop.Name));
        }

    
	}
}

