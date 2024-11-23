using Helpline.Domain.Errors;
using Helpline.Domain.Models.CoreElements;
using Helpline.Domain.Shared;

namespace Helpline.Domain.ValueObjects
{
    public sealed class Email : ValueObject
    {
        private Email(string value) => Value = value;

        public string Value { get; }

        public static Result<Email> Create(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return Result.Failure<Email>(CommonErrors.Email.Empty);
            }

            if (email.Split('@').Length != 2)
            {
                return Result.Failure<Email>(CommonErrors.Email.InvalidFormat);
            }

            return new Email(email);
        }
        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}
