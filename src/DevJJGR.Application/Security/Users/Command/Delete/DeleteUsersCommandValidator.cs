using FluentValidation;

namespace Donouts.Application.Security.Users.Command.Delete
{
    public class DeleteUsersCommandValidator : AbstractValidator<DeleteUsersCommand>
    {
        public DeleteUsersCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
