using FluentValidation;
using Helpline.Services.Users.Technicians.Commands;

namespace Helpline.Services.Users.Technicians.Validators
{
    public class TechnicianUserServiceValidator : AbstractValidator<TechnicianUpdateCommand>
    {
        public TechnicianUserServiceValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty()
                .WithMessage("UserId must not be empty.");
        }
    }
}
