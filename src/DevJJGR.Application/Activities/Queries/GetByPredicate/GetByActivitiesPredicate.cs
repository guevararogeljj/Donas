using System;
using Donouts.Application.Dto.Activities;
using Donouts.Application.Dto.Donouts;
using DonoutsCore.Common.Models;
using MediatR;

namespace Donouts.Application.Activities.Queries.GetByPredicate
{
	public class GetByActivitiesPredicate : IRequest<ResponseDto<List<ActivitiesDTO>>>
    {
        public Guid? Id { get; set; }
        public string Name { get; set; } = String.Empty;

        public bool HasFilter()
        {
            return this.Id.HasValue
                ||!string.IsNullOrEmpty(this.Name?.Trim());
        }
    }
}

