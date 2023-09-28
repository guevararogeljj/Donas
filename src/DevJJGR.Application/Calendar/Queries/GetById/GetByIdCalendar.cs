using System;
using Donouts.Application.Dto.Activities;
using Donouts.Application.Dto.Calendar;
using DonoutsCore.Common.Models;
using MediatR;

namespace Donouts.Application.Calendar.Queries.GetById
{
	public class GetByIdCalendar : IRequest<ResponseDto<CalendarioActividadesDTO>>
    {
        public Guid Id { get; set; }
        public GetByIdCalendar(Guid id)
		{
			this.Id = id;
		}
	}
}

