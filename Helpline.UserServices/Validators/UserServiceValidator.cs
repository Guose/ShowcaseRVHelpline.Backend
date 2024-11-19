using FluentValidation;
using Helpline.UserServices.Technicians.Commands;

namespace Helpline.UserServices.Validators
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
