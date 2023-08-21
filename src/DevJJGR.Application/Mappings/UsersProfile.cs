using System;
using AutoMapper;
using Donouts.Application.Dto;
using Donouts.Application.Dto.Security;

namespace Donouts.Application.Mappings
{
	public class UsersProfile : Profile
    {
		public UsersProfile()
		{
            CreateMap<Donouts.Domain.Entities.ApplicationUser, UsersDTO>()
                .ForMember(dto => dto.Id, ent => ent.MapFrom(prop => prop.Id))
                .ForMember(dto => dto.Direction, ent => ent.MapFrom(prop => prop.Direction))
                .ForMember(dto => dto.Email, ent => ent.MapFrom(prop => prop.Email))
                .ForMember(dto => dto.Name, ent => ent.MapFrom(prop => prop.Name))
                .ForMember(dto => dto.PasswordHash, ent => ent.MapFrom(prop => prop.PasswordHash))
                .ForMember(dto => dto.PhoneNumber, ent => ent.MapFrom(prop => prop.PhoneNumber))
                .ForMember(dto => dto.CreatedAt, ent => ent.MapFrom(prop => prop.CreatedAt));
        }
	}
}

