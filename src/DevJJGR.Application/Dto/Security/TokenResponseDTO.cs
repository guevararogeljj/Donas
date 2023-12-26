using System;
namespace Donouts.Application.Dto.Security
{
	public class TokenResponseDTO
	{
		public string Token { get; set; } = string.Empty;
		public string Role { get; set; } = string.Empty;
	}
}

