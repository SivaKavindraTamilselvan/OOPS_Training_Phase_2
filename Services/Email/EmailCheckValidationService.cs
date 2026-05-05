using System.Net;
using System.Net.Mail;
using NotificationApp.Interfaces;
using NotificationApp.Models;
using NotificationApp.Validation;

namespace NotificationApp.Services;

internal partial class EmailService : INotification
{
    private bool CheckValidation(User user)
    {
        return EmailValidation.isValidEmail(user.Email??"");
    }
}