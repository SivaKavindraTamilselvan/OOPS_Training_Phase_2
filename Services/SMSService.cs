using NotificationApp.Interfaces;
using NotificationApp.Models;
using NotificationApp.Validation;

namespace NotificationApp.Services;

internal class SMSService : INotification
{
    private string status = "pending";
    private DateTime? dateTime= null;
    public void Send(string message,User user)
    {
        if(!CheckValidation(user))
        {
            Console.WriteLine("Invalid User Details");
            return;
        }
       dateTime = DateTime.Now;
       Console.WriteLine("MessageService");
       Console.WriteLine("From - 944237XXXX");
       Console.WriteLine($"To - {user.PhoneNumber}");
       Console.WriteLine($"Date - {dateTime}");
       Console.WriteLine($"Message - {message}");
       status = "sent";
       Log(message,user);
    }
    private bool CheckValidation(User user)
    {
        UserService userService = new UserService();
        if(!userService.CheckUser(user))
        {
            Console.WriteLine("User Not Found");
            return false;
        }
        return PhoneNumberValidation.isValidPhoneNumber(user.PhoneNumber??"");
    }

    private void Log(string message,User user)
    {
        Console.WriteLine("---------------------------------------------");
        Console.WriteLine("Logging the Information - SMS Service");
        Console.WriteLine($"The SMS Services\nFrom : sivakavindra@gmail.com\nTo : {user.Email}\nStatus : {status}\nDate & Time : {dateTime}\nMessage : {message}");
        Console.WriteLine("---------------------------------------------");
    }
}