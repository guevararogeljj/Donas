using Donouts.Application.Dto.Calendar;
using DonoutsCore.Common.Models;
using MediatR;

namespace Donouts.Application.Calendar.Queries.GetByPredicate
{
	public class GetByCalendarPredicate : IRequest<ResponseDto<List<CalendarioActividadesDTO>>>
    {
        public DateTime? EventDate { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
        public DateTime? ClosedDate { get; set; }
        public String? CreatedBy { get; set; }
        public GetByCalendarPredicate()
        {
        }
        public bool HasFilter()
        {
            return this.EventDate.HasValue
                || this.StartTime.HasValue
                || this.EndTime.HasValue
                || this.ClosedDate.HasValue
                || !string.IsNullOrEmpty(this.CreatedBy?.Trim());
        }

	}
}

