using System;
using Donouts.Domain.Common;

namespace Donouts.Domain.Entities.Activities
{
	public class Activities: Entity
	{
        public Guid Id { get; set; }
        public Guid CreatedBy { get; set; }
        public string LastUpdatedBy { get; set; } = String.Empty;
    }
}

