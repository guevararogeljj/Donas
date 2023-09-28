using System;
using DonoutsCore.Common.Models;
using MediatR;

namespace Donouts.Application.Activities.Commands.Update
{
	public class UpdateActivitiesCommand : IRequest<ResponseDto<Boolean>>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool? Visible { get; set; }
	}
}

