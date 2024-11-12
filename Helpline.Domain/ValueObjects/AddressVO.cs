using Helpline.Common.Errors;
using Helpline.Common.Essentials;
using Helpline.Common.Models;
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

        private AddressVO(Address address)
        {
            Address = address;
        }

        public string Street { get; } = string.Empty;
        public string City { get; } = string.Empty;
        public string State { get; } = string.Empty;
        public string PostalCode { get; } = string.Empty;
        public Address Address { get; set; } = new();

        public static Result<AddressVO> Create(Address address)
        {
            if (string.IsNullOrWhiteSpace(address.Address1))
            {
                return Result.Failure<AddressVO>(CommonErrors.Address.StreetEmpty);
            }
            else if (string.IsNullOrWhiteSpace(address.City))
            {
                return Result.Failure<AddressVO>(CommonErrors.Address.CityEmpty);
            }
            else if (string.IsNullOrWhiteSpace(address.State))
            {
                return Result.Failure<AddressVO>(CommonErrors.Address.StateEmpty);
            }
            else if (string.IsNullOrWhiteSpace(address.PostalCode) || address.PostalCode.Length < 5)
            {
                return Result.Failure<AddressVO>(CommonErrors.Address.InvalidPostalCode);
            }

            return new AddressVO(address);
        }

        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Street;
            yield return City;
            yield return State;
            yield return PostalCode;
            yield return Address;
        }
    }
}
