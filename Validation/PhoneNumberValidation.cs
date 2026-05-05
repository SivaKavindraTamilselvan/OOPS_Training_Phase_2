using System.Text.RegularExpressions;

namespace NotificationApp.Validation;

internal class PhoneNumberValidation
{
    public static bool isValidPhoneNumber(string phonenumber)
    {
        string checkPhoneNumber = phonenumber.Trim();
        if(checkPhoneNumber == null || checkPhoneNumber == "")
        {
            return false;
        }
        string pattern = @"^[0-9]{10}$";

        return Regex.IsMatch(checkPhoneNumber,pattern);

    }
}