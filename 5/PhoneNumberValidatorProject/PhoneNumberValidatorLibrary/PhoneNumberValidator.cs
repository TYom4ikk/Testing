using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneNumberValidatorLibrary
{
    public class PhoneNumberValidator
    {
        public static bool IsValidPhoneNumber(string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber))
                return false;

            // формат: +7XXXXXXXXXX или 8XXXXXXXXXX (11 цифр)
            var regex = new System.Text.RegularExpressions.Regex(@"^(\+7|8)\d{10}$");
            return regex.IsMatch(phoneNumber);
        }
    }
}
