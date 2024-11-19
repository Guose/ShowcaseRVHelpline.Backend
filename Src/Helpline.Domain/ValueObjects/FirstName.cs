using Helpline.Common.Constants;
using Helpline.Common.Errors;
using Helpline.Common.Essentials;
using Helpline.Common.Shared;

namespace Helpline.Domain.ValueObjects
{
    public sealed class FirstName : ValueObject
    {
        public const int MaxLength = 50;

        private FirstName(string value)
        {
            Value = value;
        }

        public string Value { get; }

        public static Result<FirstName> Create(string firstName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
            {
                return Result.Failure<FirstName>(CommonErrors.FirstName.Empty);
            }

            if (firstName.Length > MaxLength)
            {
                return Result.Failure<FirstName>(CommonErrors.FirstName.TooLong);
            }

            if (!CharacterValidationRegEx.LettersOnly.IsMatch(firstName))
            {
                return Result.Failure<FirstName>(CommonErrors.LastName.LettersOnly);
            }

            return new FirstName(firstName);
        }

        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}
