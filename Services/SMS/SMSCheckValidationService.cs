using NotificationApp.Interfaces;
using NotificationApp.Models;
using NotificationApp.Validation;

namespace NotificationApp.Services;

internal partial class SMSService : INotification
{
    
    private bool CheckValidation(User user)
    {
        return PhoneNumberValidation.isValidPhoneNumber(user.PhoneNumber??"");
    }
}