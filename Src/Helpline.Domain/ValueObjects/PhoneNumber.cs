using Helpline.Domain.Errors;
using Helpline.Domain.Models.CoreElements;
using Helpline.Domain.Shared;

namespace Helpline.Domain.ValueObjects
{
    public sealed class PhoneNumber : ValueObject
    {
        private PhoneNumber(string value) => Value = value;
        public string Value { get; }

        public static Result<PhoneNumber> Create(string phonenumber)
        {
            if (string.IsNullOrWhiteSpace(phonenumber))
            {
                return Result.Failure<PhoneNumber>(DomainErrors.PhoneNumber.Empty);
            }
            if (phonenumber.Length < 10 || phonenumber.Length > 10)
            {
                return Result.Failure<PhoneNumber>(DomainErrors.PhoneNumber.InvalidFormat);
            }

            return new PhoneNumber(phonenumber);
        }

        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}
