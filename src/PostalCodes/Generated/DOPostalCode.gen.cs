using System.Text.RegularExpressions;
using PostalCodes.GenericPostalCodes;

namespace PostalCodes
{
    internal partial class DOPostalCode : AlphaNumericPostalCode
    {
        public DOPostalCode(string postalCode) : this(postalCode, " -", true) {}

        public DOPostalCode(string postalCode, string redundantCharacters, bool allowConvertToShort) : base(_formats, redundantCharacters, postalCode, allowConvertToShort) 
        {
            _countryName = "DO";
        }
        
        protected override PostalCode CreatePostalCode(string code, bool allowConvertToShort)
        {
            return new DOPostalCode(code, " -", allowConvertToShort);
        }
        
        public override bool Equals (object obj)
        {
            var other = obj as DOPostalCode;
            if (other == null) 
            {
                return false;
            }

            return PostalCodeString.Equals (other.PostalCodeString);
        }

        public override int GetHashCode ()
        {
            return PostalCodeString.GetHashCode ();
        }

        private static PostalCodeFormat[] _formats = {
            new PostalCodeFormat {
                Name = "5-Digits - 99999",
                RegexDefault = new Regex("^[0-9]{5}$", RegexOptions.Compiled),
                OutputDefault = "xxxxx",
                AutoConvertToShort = false,
                ShortExpansionAsLowestInRange = "0",
                ShortExpansionAsHighestInRange = "9",
                LeftPaddingCharacter = "0",
            }
        };
    }
}
