using NotificationApp.Models;
using NotificationApp.Validation;
using NotificationApp.Interfaces;
using NotificationApp.Repository;

namespace NotificationApp.Services;
internal partial class UserService : IUserService
{
    public User? GetUserById(int id)
    {
        return userRepo.Get(id);
    }
    public User? UpdateUserById(int userId)
    {
        var user = GetUserById(userId);
        if (user == null)
        {
            return null;
        }
        Console.WriteLine("Enter Your Name That Needed To Be Updated");

        string name = Console.ReadLine() ?? "";
        while (name.Trim() == "")
        {
            Console.WriteLine("Inavlid Name.Name Should Not be Empty.Enter Valid Name");
            name = Console.ReadLine() ?? "";
        }

        Console.WriteLine("Enter Your Email That Needed To Be Updated");

        string email = Console.ReadLine() ?? "";
        while (!EmailValidation.isValidEmail(email))
        {
            Console.WriteLine("Invalid Email Entered.Enter Vaild Email Address");
            email = Console.ReadLine() ?? "";
        }
        if(GetUserByEmail(email) != null)
        {
            Console.WriteLine("Aldready Email is Registered with This Email");
            return null;
        }
        Console.WriteLine("Enter Your PhoneNumber That Needed To Be Updated");

        string phone = Console.ReadLine() ?? "";
        while (!PhoneNumberValidation.isValidPhoneNumber(phone))
        {
            Console.WriteLine("Invalid Phone Number Entered.Enter Valid PhoneNumber");
            phone = Console.ReadLine() ?? "";
        }
        user.Name = name;
        user.Email = email;
        user.PhoneNumber = phone;

        var updatedUser = userRepo.Update(userId,user);

        if(updatedUser != null)
        {
            Console.WriteLine("User Updated Successfully. Wait for the Email to be sent!!");
            string message = $"Successfully updated your account with the details\nName : {updatedUser.Name}\nPhoneNumber : {updatedUser.PhoneNumber}\nEmail : {updatedUser.Email}\n\nThank You!";
            emailService.Send(message, updatedUser);
            smsService.Send(message, updatedUser);
        }
        return updatedUser;
    }
}