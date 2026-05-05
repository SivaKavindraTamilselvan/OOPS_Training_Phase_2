using NotificationApp.Interfaces;
using NotificationApp.Models;
using NotificationApp.Validation;

namespace NotificationApp.Services;

internal partial class SMSService : INotification
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
}