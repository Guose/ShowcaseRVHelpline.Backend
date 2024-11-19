using Helpline.Domain.Shared;

namespace Helpline.Domain.Errors
{
    public class CommonErrors
    {
        public static class User
        {
            public static readonly Error EmailAlreadyInUse = new(
                "User.EmailAlreadyInUse",
                "The specified email is already in use.");

            public static readonly Func<Guid, Error> NotFound = id => new Error(
                "User.NotFound",
                $"The user with the identifier {id} was not found.");

            public static readonly Error CollectionNotFound = new(
                "User.NotFound",
                "The Query to 'GetAll' had an error. See log for more detail.");

            public static readonly Error AreNull = new(
                "User.Properties_AreNull",
                "The user's properties cannot be null.");

            public static readonly Func<Guid, Error> UpdateError = id => new Error(
                "User.UpdateError",
                $"The user with the identifier {id} could not update.");
        }

        public static class UserName
        {
            public static readonly Error Empty = new(
                "FirstName.Empty",
                "First name cannot be empty.");

            public static readonly Error TooLong = new(
                "FirstName.TooLong",
                "First name is too long.");

            public static readonly Error UserNameAlreadyInUse = new(
                "Member.EmailAlreadyInUse",
                "The specified email is already in use.");

            public static readonly Func<Guid, Error> NotFound = id => new Error(
                "Member.NotFound",
                $"The member with the identifier {id} was not found.");
        }

        public static class Password
        {
            public static readonly Error Empty = new(
                "Password.Empty",
                "Password cannot be empty.");

            public static readonly Error InvalidFormat = new(
                "Password.InvalidFormat",
                "Password format is invalid.");
        }

        public static class Email
        {
            public static readonly Error Empty = new(
                "Email.Empty",
                "Email cannot be empty.");

            public static readonly Error InvalidFormat = new(
                "Email.InvalidFormat",
                "Email format is invalid.");

            public static readonly Error DomainBlocked = new(
                "Email.DomainBlocked",
                "The specified email domain is not allowed.");
        }

        public static class PhoneNumber
        {
            public static readonly Error InvalidFormat = new(
                "PhoneNumber.InvalidFormat",
                "Phone number format is invalid. It must be exactly 10 digits.");

            public static readonly Error Empty = new(
                "PhoneNumber.Empty",
                "Phone number cannot be empty.");
        }

        public static class Address
        {
            public static readonly Error NotFound = new(
                "Address.NotFound",
                $"The addres was not found.");

            public static readonly Error StreetEmpty = new(
                "Address.StreetEmpty",
                "Street cannot be empty.");

            public static readonly Error CityEmpty = new(
                "Address.CityEmpty",
                "City cannot be empty.");

            public static readonly Error StateEmpty = new(
                "Address.StateEmpty",
                "State cannot be empty.");

            public static readonly Error InvalidPostalCode = new(
                "Address.InvalidPostalCode",
                "Postal code is invalid.");
        }

        public static class Money
        {
            public static readonly Error NegativeAmount = new(
                "Money.NegativeAmount",
                "Money amount cannot be negative.");

            public static readonly Error InvalidCurrencyCode = new(
                "Money.InvalidCurrencyCode",
                "Currency code must be a valid 3-letter ISO code.");
        }

        public static class DateRange
        {
            public static readonly Error InvalidRange = new(
                "DateRange.InvalidRange",
                "Start date must be before the end date.");

            public static readonly Error StartDateInPast = new(
                "DateRange.StartDateInPast",
                "Start date cannot be in the past for this action.");

            public static readonly Error EndDateTooFar = new(
                "DateRange.EndDateTooFar",
                "End date is too far in the future.");
        }

        public static class FirstName
        {
            public static readonly Error Empty = new(
                "FirstName.Empty",
                "First name is empty");

            public static readonly Error TooLong = new(
                "LastName.TooLong",
                "FirstName name is too long");

            public static readonly Error LettersOnly = new(
                "LastName.LettersOnly",
                "FirstName can only have alpha characters, no numbers.");
        }

        public static class LastName
        {
            public static readonly Error Empty = new(
                "LastName.Empty",
                "Last name is empty");

            public static readonly Error TooLong = new(
                "LastName.TooLong",
                "Last name is too long");

            public static readonly Error LettersOnly = new(
                "LastName.LettersOnly",
                "LastName can only have alpha characters, no numbers.");
        }
    }
}
