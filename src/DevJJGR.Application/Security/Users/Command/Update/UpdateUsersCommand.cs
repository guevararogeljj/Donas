using System;
using DonoutsCore.Common.Models;
using MediatR;

namespace Donouts.Application.Security.Users.Command.Update
{
	public class UpdateUsersCommand : IRequest<ResponseDto<Boolean>>
	{
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Direction { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string RoleId { get; set; } = string.Empty;

        public UpdateUsersCommand(string name, string direccion, string email,
            string passwordHash, string phoneNumber, string userName)
		{
            this.Name = name;
            this.Direction = direccion;
            this.Email = email;
            this.PasswordHash = passwordHash;
            this.PhoneNumber = phoneNumber;
            this.UserName = userName;
        }
	}
}

