using Helpline.Domain.Constants;
using Helpline.Domain.Errors;
using Helpline.Domain.Models.CoreElements;
using Helpline.Domain.Shared;

namespace Helpline.Domain.ValueObjects
{
    public sealed class LastName : ValueObject
    {
        public const int MaxLength = 50;

        private LastName(string value)
        {
            Value = value;
        }

        public string Value { get; }

        public static Result<LastName> Create(string lastName)
        {
            if (string.IsNullOrWhiteSpace(lastName))
            {
                return Result.Failure<LastName>(DomainErrors.LastName.Empty);
            }

            if (lastName.Length > MaxLength)
            {
                return Result.Failure<LastName>(DomainErrors.LastName.TooLong);
            }

            if (!CharacterValidationRegEx.LettersOnly.IsMatch(lastName))
            {
                return Result.Failure<LastName>(DomainErrors.LastName.LettersOnly);
            }

            return new LastName(lastName);
        }

        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}
