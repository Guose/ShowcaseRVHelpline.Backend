using FluentValidation;
using Helpline.Services.Users.Technicians.Commands;

namespace Helpline.Services.Users.Validators
{
    public class UserServiceValidator : AbstractValidator<TechnicianUpdateCommand>
    {
        public UserServiceValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty()
                .WithMessage("UserId must not be empty.");
        }
    }
}
