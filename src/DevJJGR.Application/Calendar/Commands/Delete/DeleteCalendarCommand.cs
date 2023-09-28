using System;
using DonoutsCore.Common.Models;
using MediatR;

namespace Donouts.Application.Calendar.Commands.Delete
{
	public class DeleteCalendarCommand : IRequest<ResponseDto<Boolean>>
    {
		public Guid Id { get; set; }
		public DeleteCalendarCommand()
		{
		}
	}
}

