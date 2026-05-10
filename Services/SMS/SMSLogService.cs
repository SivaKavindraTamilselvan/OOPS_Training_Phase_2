using NotificationApp.Interfaces;
using NotificationApp.Models;
using NotificationApp.Validation;

namespace NotificationApp.Services;

internal partial class SMSService : INotification
{
    //log the information in console
    private void Log(string message,User user)
    {
        string phone = Environment.GetEnvironmentVariable("CompanyPhoneNumber") ?? "";
        Console.WriteLine("---------------------------------------------");
        Console.WriteLine("Logging the Information - SMS Service");
        Console.WriteLine($"The SMS Services\nFrom : {phone}\nTo : {user.PhoneNumber}\nUserName : {user.Name}\nStatus : {status}\nDate & Time : {dateTime}\nMessage : {message}");
        Console.WriteLine("---------------------------------------------");
    }
}