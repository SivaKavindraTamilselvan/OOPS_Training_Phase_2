using System.Text.RegularExpressions;

namespace NotificationApp.Validation;

internal class EmailValidation
{
    //implementation of email validation by using regex pattern
    public static bool isValidEmail(string email)
    {
        string checkEmail=email.Trim();

        if(checkEmail==null || checkEmail=="")
        {
            return false;
        }
        string pattern=@"^[^@\s]+@[^@\s]+\.[^@\s]+$";

        return Regex.IsMatch(checkEmail, pattern, RegexOptions.IgnoreCase);
        
    }
}