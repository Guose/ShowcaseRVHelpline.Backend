using Helpline.Domain.Errors;
using Helpline.Domain.Models.CoreElements;
using Helpline.Domain.Shared;

namespace Helpline.Domain.ValueObjects
{
    public sealed class UserName : ValueObject
    {
        private UserName(string value) => Value = value;

        public string Value { get; }

        public static Result<UserName> Create(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                return Result.Failure<UserName>(DomainErrors.UserName.Empty);
            }
            if (username.Length > 25)
            {
                return Result.Failure<UserName>(DomainErrors.UserName.TooLong);
            }

            return new UserName(username);
        }

        public override IEnumerable<object> GetAtomicValues()
        {
            throw new NotImplementedException();
        }
    }
}
