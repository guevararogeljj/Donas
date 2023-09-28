using System;
using DonoutsCore.Common.Models;
using MediatR;

namespace Donouts.Application.Calendar.Commands.Update
{
	public class UpdateCalendarCommand : IRequest<ResponseDto<Boolean>>
    {
        public Guid Id { get; set; }
        public Guid ActivityId { get; set; }
        public DateTime EventDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public DateTime? ClosedDate { get; set; }
        public String Comments { get; set; } = string.Empty;
        public bool? IsDeleted { get; set; }
        public UpdateCalendarCommand()
		{
		}
	}
}

