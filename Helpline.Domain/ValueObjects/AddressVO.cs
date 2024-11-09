using Helpline.Common.Errors;
using Helpline.Common.Essentials;
using Helpline.Common.Shared;

namespace Helpline.Domain.ValueObjects
{
    public sealed class AddressVO : ValueObject
    {
        private AddressVO(string street, string city, string state, string postalCode)
        {
            Street = street;
            City = city;
            State = state;
            PostalCode = postalCode;
        }

        public string Street { get; }
        public string City { get; }
        public string State { get; }
        public string PostalCode { get; }

        public static Result<AddressVO> Create(string street, string city, string state, string postalCode)
        {
            if (string.IsNullOrWhiteSpace(street))
            {
                return Result.Failure<AddressVO>(CommonErrors.Address.StreetEmpty);
            }
            else if (string.IsNullOrWhiteSpace(city))
            {
                return Result.Failure<AddressVO>(CommonErrors.Address.CityEmpty);
            }
            else if (string.IsNullOrWhiteSpace(state))
            {
                return Result.Failure<AddressVO>(CommonErrors.Address.StateEmpty);
            }
            else if (string.IsNullOrWhiteSpace(postalCode) || postalCode.Length < 5)
            {
                return Result.Failure<AddressVO>(CommonErrors.Address.InvalidPostalCode);
            }
            
            return new AddressVO(street, city, state, postalCode);
        }

        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Street;
            yield return City;
            yield return State;
            yield return PostalCode;
        }
    }
}
