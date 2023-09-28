using System;
using DonoutsCore.Common.Models;
using MediatR;

namespace Donouts.Application.Activities.Commands.Create
{
	public class CreateActivitiesCommand : IRequest<ResponseDto<Boolean>>
	{
		public string Name { get; set; } = String.Empty;
		public string Code { get; set; } = String.Empty;
		
	}
}

