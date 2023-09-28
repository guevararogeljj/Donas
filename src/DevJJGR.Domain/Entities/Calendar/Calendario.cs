using System;
using Donouts.Domain.Common;

namespace Donouts.Domain.Entities.Calendario
{
	public class CalendarioActividades : Entity
	{
		public Guid Id { get; set; }
		public Guid ActivityId { get; set; }
		public DateTime EventDate { get; set; }
		public TimeSpan StartTime { get; set; }
		public TimeSpan EndTime { get; set; }
        public String? Comments { get; set; } = string.Empty;
        public DateTime? ClosedDate { get; set; }  
        public DateTime? ConfirmDate { get; set; }
        public Guid UserCreatedId { get; set; }
        public ApplicationUser UserCreated { get; set; } = new ApplicationUser();
        public Guid? UserModifiedId { get; set; }
        public ApplicationUser UserModified { get; set; } = new ApplicationUser();
        public bool? IsDeleted { get; set; }
        public bool Visible { get; set; }
    }
}

