using Helpline.Common.Constants;
using Helpline.Common.Errors;
using Helpline.Common.Essentials;
using Helpline.Common.Shared;

namespace Helpline.Domain.ValueObjects
{
    public sealed class Password : ValueObject
    {
        public const int MaxLength = 50;

        private Password(string value)
        {
            Value = value;
        }

        public string Value { get; }

        public static Result<Password> Create(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                return Result.Failure<Password>(CommonErrors.Password.Empty);
            }

            if (!CharacterValidationRegEx.Password.IsMatch(password))
            {
                return Result.Failure<Password>(CommonErrors.Password.InvalidFormat);
            }

            return new Password(password);
        }

        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}
