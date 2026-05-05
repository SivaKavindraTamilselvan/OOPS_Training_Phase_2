using NotificationApp.Validation;
using NotificationApp.Models;

namespace NotificationApp.Inputs;

internal class InputsCheck
{
    public string EmailInputs()
    {
        string email = Console.ReadLine() ?? string.Empty;

        while (!EmailValidation.isValidEmail(email))
        {
            Console.WriteLine("Invalid Email Entered.Enter Vaild Email Address");
            email = Console.ReadLine() ?? string.Empty;
        }
        return email;
    }
    public string PhoneNumberInputs()
    {
        string phone = Console.ReadLine() ?? string.Empty;

        while (!PhoneNumberValidation.isValidPhoneNumber(phone))
        {
            Console.WriteLine("Invalid Phone Number Entered.Enter Valid PhoneNumber");
            phone = Console.ReadLine() ?? string.Empty;
        }
        return phone;
    }

    public string MessageInputs(string value)
    {
        Console.WriteLine($"Enter The Message That needed to be sent {value}");
        string message = Console.ReadLine() ?? string.Empty;
        while (message == "")
        {
            message = Console.ReadLine() ?? string.Empty;
        }
        return message;
    }

    public int UserIdInputs()
    {
        Console.WriteLine("Enter UserId");
        int userid;
        while(!int.TryParse(Console.ReadLine(),out userid) || userid < 0)
        {
            Console.WriteLine("Enter Vaild Input");
        }
        return userid;
    }
}