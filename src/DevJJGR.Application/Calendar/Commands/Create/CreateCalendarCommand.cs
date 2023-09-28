using System;
using Donouts.Domain.Entities;
using DonoutsCore.Common.Models;
using MediatR;

namespace Donouts.Application.Calendar.Commands.Create
{
	public class CreateCalendarCommand : IRequest<ResponseDto<Boolean>>
    {
        public Guid ActivityId { get; set; }
        public DateTime EventDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public DateTime ClosedDate { get; set; }
        public String Comments { get; set; } = string.Empty;
        public CreateCalendarCommand()
		{
		}
	}
}

