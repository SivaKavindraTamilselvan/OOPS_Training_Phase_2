using System.Net;
using System.Net.Mail;
using NotificationApp.Interfaces;
using NotificationApp.Models;
using NotificationApp.Validation;

namespace NotificationApp.Services;

internal partial class EmailService : INotification
{
    private string status = "pending";
    private DateTime? dateTime= null;
    public void Send(string message,User user)
    {
        try
        {
            if(!CheckValidation(user))
            {
                Console.WriteLine("Invalid User Details");
                return;
            }
        
            string fromEmail = Environment.GetEnvironmentVariable("CompanyEmail") ?? "";
            string? fromName = Environment.GetEnvironmentVariable("CompanyName") ?? "";

            string? toEmail = user.Email ?? "";
            string? toName = user.Name ?? "";

            var from = new MailAddress(fromEmail, fromName);
            var to = new MailAddress(toEmail, toName);

            string? password = Environment.GetEnvironmentVariable("Password") ?? "";

            var smtp = new SmtpClient("smtp.gmail.com",587)
            {
                Credentials = new NetworkCredential(from.Address,password),
                EnableSsl = true
            };

            var mail = new MailMessage(from,to)
            {
                Subject = "Notification",
                Body = message,
                IsBodyHtml = true
            };
            smtp.Send(mail);
            dateTime = DateTime.Now;

            status = "Sent";

            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("Email Service");
            Console.WriteLine("Email Sent Successfully");
            Console.WriteLine("---------------------------------------------");

        }
        catch (Exception ex)
        {
            status = "Failed" + ex.Message;
        }
        Log(message,user);
    }
}