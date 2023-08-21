using System;
using DonoutsCore.Common.Models;
using MediatR;

namespace Donouts.Application.Security.Users.Command.Create
{
	public class CreateUsersCommand : IRequest<ResponseDto<Boolean>>
	{
        public string Name { get; set; } = string.Empty;
        public string Direction { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public Guid RoleId { get; set; }
        public CreateUsersCommand(string name, string direccion, string email,
            string passwordHash, string phoneNumber, string userName)
        {
            this.Name = name;
            this.Direction = direccion;
            this.Email = email;
            this.PasswordHash = passwordHash;
            this.PhoneNumber = phoneNumber;
            this.UserName = userName;
        }
        public CreateUsersCommand()
        {
            
        }
    }
}

