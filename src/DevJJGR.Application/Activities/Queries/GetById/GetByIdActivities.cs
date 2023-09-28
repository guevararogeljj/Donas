using System;
using Donouts.Application.Dto.Activities;
using DonoutsCore.Common.Models;
using MediatR;

namespace Donouts.Application.Activities.Queries.GetById
{
	public class GetByIdActivities : IRequest<ResponseDto<ActivitiesDTO>>
    {
        public Guid Id { get; set; }
        public GetByIdActivities(Guid id)
        {
            this.Id = id;
        }
    }
}

