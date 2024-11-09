using Helpline.Common.Shared;

namespace Helpline.Common.Errors
{
    public class CommonErrors
    {
        public static class Email
        {
            public static readonly Error Empty = new(
                "Email.Empty",
                "Email is empty");

            public static readonly Error InvalidFormat = new(
                "Email.InvalidFormat",
                "Email format is invalid");
        }

        public static class FirstName
        {
            public static readonly Error Empty = new(
                "FirstName.Empty",
                "First name is empty");

            public static readonly Error TooLong = new(
                "LastName.TooLong",
                "FirstName name is too long");
        }

        public static class LastName
        {
            public static readonly Error Empty = new(
                "LastName.Empty",
                "Last name is empty");

            public static readonly Error TooLong = new(
                "LastName.TooLong",
                "Last name is too long");
        }
    }
}
