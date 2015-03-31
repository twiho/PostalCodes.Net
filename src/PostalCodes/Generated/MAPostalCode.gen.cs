using System.Text.RegularExpressions;
using PostalCodes.GenericPostalCodes;

namespace PostalCodes
{
    internal partial class MAPostalCode : AlphaNumericPostalCode
    {
        public MAPostalCode(string postalCode) : this(postalCode, true) {}

        public MAPostalCode(string postalCode, bool allowConvertToShort) : base(_formats, postalCode, allowConvertToShort) 
        {
            _countryName = "MA";
        }
        
        protected override PostalCode CreatePostalCode(string code, bool allowConvertToShort)
        {
            return new MAPostalCode(code, allowConvertToShort);
        }
        
        public override bool Equals (object obj)
        {
            var other = obj as MAPostalCode;
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
