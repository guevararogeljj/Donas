using System;
using Donouts.Application.Dto.Activities;
using Donouts.Application.Dto.Calendar;
using DonoutsCore.Common.Models;
using MediatR;

namespace Donouts.Application.Calendar.Queries.GetAll
{
	public class GetAllCalendar : IRequest<ResponseDto<List<CalendarioActividadesDTO>>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public GetAllCalendar(int pageNumber, int pageSize)
		{
            this.PageNumber = pageNumber;
            this.PageSize = pageSize;
        }
        public GetAllCalendar()
        {

        }
	}
}

