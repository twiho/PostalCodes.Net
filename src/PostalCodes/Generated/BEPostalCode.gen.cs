using System.Text.RegularExpressions;
using PostalCodes.GenericPostalCodes;

namespace PostalCodes
{
    internal partial class BEPostalCode : AlphaNumericPostalCode
    {
        public BEPostalCode(string postalCode) : this(postalCode, true) {}

        public BEPostalCode(string postalCode, bool allowConvertToShort) : base(_formats, postalCode, allowConvertToShort) 
        {
            _countryName = "BE";
        }
        
        protected override PostalCode CreatePostalCode(string code, bool allowConvertToShort)
        {
            return new BEPostalCode(code, allowConvertToShort);
        }
        
        public override bool Equals (object obj)
        {
            var other = obj as BEPostalCode;
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
                Name = "4-Digits - 9999",
                RegexDefault = new Regex("^[0-9]{4}$", RegexOptions.Compiled),
                OutputDefault = "xxxx",
                AutoConvertToShort = false,
                ShortExpansionAsLowestInRange = "0",
                ShortExpansionAsHighestInRange = "9",
                LeftPaddingCharacter = "0",
            }
        };
    }
}
