using NotificationApp.Models;
using NotificationApp.Validation;
using NotificationApp.Interfaces;
using NotificationApp.Repository;

namespace NotificationApp.Services;
internal partial class UserService : IUserService
{
    public User? GetUserByEmail(string email)
    {
        var UserList = userRepo.GetAll();
        if(UserList == null) return null;
        foreach (var item in UserList)
        {
            if (item.Email == email)
            {
                return item;
            }
        }
        return null;
    }
    public User? DeleteUserByEmail(string email)
    {
        var UserList = userRepo.GetAll();
        if(UserList == null) return null;
        foreach (var item in UserList)
        {
            if (item.Email == email)
            {
                userRepo.Delete(item.userId);
                Console.WriteLine("User Deleted Successfully ! Wait for the Email to be sent");
                string message = $"Successfully deleted your account with the details\nName : {item.Name}\nPhoneNumber : {item.PhoneNumber}\nEmail : {item.Email}\n\nThank You!";
                emailService.Send(message, item);
                smsService.Send(message, item);
                return item;
            }
        }
        return null;
    }
}
