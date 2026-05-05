using NotificationApp.Models;
using NotificationApp.Validation;
using NotificationApp.Interfaces;
using NotificationApp.Repository;

namespace NotificationApp.Services;
internal partial class UserService : IUserService
{
    public User? GetUserByPhoneNumber(string phonenumber)
    {
        var UserList = userRepo.GetAll();
        foreach (var item in UserList)
        {
            if (item.PhoneNumber == phonenumber)
            {
                return item;
            }
        }
        return null;
    }

    public User? DeleteUserByPhoneNumber(string phonenumber)
    {
        var UserList = userRepo.GetAll();
        foreach (var item in UserList)
        {
            if (item.PhoneNumber == phonenumber)
            {
                userRepo.Delete(item.userId);
                string message = $"Successfully deleted your account with the details\nName : {item.Name}\nPhoneNumber : {item.PhoneNumber}\nEmail : {item.Email}\n\nThank You!";
                emailService.Send(message, item);
                smsService.Send(message, item);
                return item;
            }
        }
        return null;
    }
}