using Helpline.Common.Shared;
using Helpline.Domain.ValueObjects;

namespace Helpline.Domain.Validation
{
    public static class UserValueObjectsValidation
    {
        // Helper Method to Validate and Create Value Objects
        public static Result<ValueObjectContainer> ValidateAndCreateValueObjects(
            string firstName, string lastName, string phoneNumber, string secondPhoneNumber)
        {
            Result<FirstName> firstNameResult = FirstName.Create(firstName);
            Result<LastName> lastNameResult = LastName.Create(lastName);
            Result<PhoneNumber> phoneResult = PhoneNumber.Create(phoneNumber);
            Result<PhoneNumber> secondPhoneResult = PhoneNumber.Create(secondPhoneNumber);

            if (firstNameResult.IsFailure)
            {
                return (ValidationResult<ValueObjectContainer>)Result.Failure(
                    new Error(
                        "FirstName.IsFailure",
                        "Error on FirstName validation."));
            }
            if (lastNameResult.IsFailure)
            {
                return (ValidationResult<ValueObjectContainer>)Result.Failure(
                    new Error(
                        "LastName.IsFailure",
                        "Error on LastName validation."));
            }
            if (phoneResult.IsFailure)
            {
                return (ValidationResult<ValueObjectContainer>)Result.Failure(
                    new Error(
                        "PhoneNumber.IsFailure",
                        "Error on PhoneNumber validation."));
            }
            if (secondPhoneResult.IsFailure)
            {
                return (ValidationResult<ValueObjectContainer>)Result.Failure(
                    new Error(
                        "SecondaryPhoneNumber.IsFailure",
                        "Error on SecondaryPhoneNumber validation."));
            }

            return Result.Success(new ValueObjectContainer(
                firstNameResult.Value, lastNameResult.Value, phoneResult.Value, secondPhoneResult.Value));
        }

        // Container class to hold validated ValueObjects for simplified handling
        public class ValueObjectContainer
        {
            public FirstName FirstName { get; }
            public LastName LastName { get; }
            public PhoneNumber PhoneNumber { get; }
            public PhoneNumber SecondPhoneNumber { get; }

            public ValueObjectContainer(FirstName firstName, LastName lastName, PhoneNumber phoneNumber, PhoneNumber secondPhoneNumber)
            {
                FirstName = firstName;
                LastName = lastName;
                PhoneNumber = phoneNumber;
                SecondPhoneNumber = secondPhoneNumber;
            }
        }
    }
}
