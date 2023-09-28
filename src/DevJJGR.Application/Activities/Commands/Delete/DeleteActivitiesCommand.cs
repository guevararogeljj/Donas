using System;
using DonoutsCore.Common.Models;
using MediatR;

namespace Donouts.Application.Activities.Commands.Delete
{
	public class DeleteActivitiesCommand : IRequest<ResponseDto<Boolean>>
    {
		public Guid Id { get; set; }
	}
}

