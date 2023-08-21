using Donouts.Domain.Entities;

namespace Donouts.Application.Dto.Security
{
	public class UsersDTO : EntityDTO
	{
		public string Id { get; set; } = string.Empty;
		public string Direction { get; set; } = string.Empty;
		public string Email { get; set; } = string.Empty;
		public string PasswordHash { get; set; } = string.Empty;
		public string PhoneNumber { get; set; } = string.Empty;
        public UsersDTO()
		{
        }
	}
}

