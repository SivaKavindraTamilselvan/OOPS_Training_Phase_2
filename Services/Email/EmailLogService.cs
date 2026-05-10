using System.Net;
using System.Net.Mail;
using NotificationApp.Interfaces;
using NotificationApp.Models;
using NotificationApp.Validation;

namespace NotificationApp.Services;

internal partial class EmailService : INotification
{
    //log the message in the console
    private void Log(string message,User user)
    {
        string email = Environment.GetEnvironmentVariable("CompanyEmail") ?? "";
        Console.WriteLine("---------------------------------------------");
        Console.WriteLine("Logging the Information - Email Service");
        Console.WriteLine($"The Email Services\nFrom : {email}\nTo : {user.Email}\nStatus : {status}\nDate & Time : {dateTime}\nMessage : {message}");
        Console.WriteLine("---------------------------------------------");
    }
}