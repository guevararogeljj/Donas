
using Donouts.Application.Dto.Calendar;
using DonoutsCore.Common.Models;
using MediatR;


namespace Donouts.Application.Calendar.Queries.GetAssigned
{
	public class GetCalendarAssigned : IRequest<ResponseDto<List<CalendarioActividadesDTO>>>
    {
        public GetCalendarAssigned()
		{
		}
	}
}

