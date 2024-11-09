using System.Text.RegularExpressions;

namespace Helpline.Common.Constants
{
    public static class CharacterValidationRegEx
    {
        // Only letters (uppercase and lowercase)
        public static readonly Regex LettersOnly = new Regex(@"^[A-Za-z]+$", RegexOptions.Compiled);

        // Email validation
        public static readonly Regex Email = new Regex(@"^[A-Za-z0-9]{3,}@[A-Za-z0-9]{3,}\.[A-Za-z]+$", RegexOptions.Compiled);

        // Password validation
        public static readonly Regex Password = new Regex(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)[A-Za-z\d\W]{8,20}$", RegexOptions.Compiled);
    }
}
