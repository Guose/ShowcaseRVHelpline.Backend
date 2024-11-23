using Helpline.Domain.Constants;
using Helpline.Domain.Errors;
using Helpline.Domain.Models.CoreElements;
using Helpline.Domain.Shared;

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
                return Result.Failure<FirstName>(DomainErrors.FirstName.Empty);
            }

            if (firstName.Length > MaxLength)
            {
                return Result.Failure<FirstName>(DomainErrors.FirstName.TooLong);
            }

            if (!CharacterValidationRegEx.LettersOnly.IsMatch(firstName))
            {
                return Result.Failure<FirstName>(DomainErrors.LastName.LettersOnly);
            }

            return new FirstName(firstName);
        }

        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}
