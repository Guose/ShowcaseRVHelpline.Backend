﻿using Helpline.Common.Constants;
using Helpline.Common.Errors;
using Helpline.Common.Essentials;
using Helpline.Common.Shared;

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
                return Result.Failure<LastName>(CommonErrors.LastName.Empty);
            }

            if (lastName.Length > MaxLength)
            {
                return Result.Failure<LastName>(CommonErrors.LastName.TooLong);
            }

            if (!CharacterValidationRegEx.LettersOnly.IsMatch(lastName))
            {
                return Result.Failure<LastName>(CommonErrors.LastName.LettersOnly);
            }

            return new LastName(lastName);
        }

        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}
