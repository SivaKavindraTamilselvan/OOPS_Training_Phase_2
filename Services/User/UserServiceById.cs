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
    public User? DeleteUserById(int id)
    {
        var user = userRepo.Delete(id);
        //if no user found
        if(user==null) return null;
        Console.WriteLine("User Deleted Successfully ! Wait for the Email && SMS to be sent");
        //notification services sent for deletion
        string message = $"Successfully deleted your account with the details\nName : {user.Name}\nPhoneNumber : {user.PhoneNumber}\nEmail : {user.Email}\n\nThank You!";
        emailService.Send(message, user);
        smsService.Send(message, user);
        return user;
    }
    public User? UpdateUserById(int userId)
    {
        var user = GetUserById(userId);
        //no user found
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
        //email validation
        while (!EmailValidation.isValidEmail(email))
        {
            Console.WriteLine("Invalid Email Entered.Enter Vaild Email Address");
            email = Console.ReadLine() ?? "";
        }
        //to avoid aldready registered email to be entered
        if(GetUserByEmail(email) != null && user.Email!=email)
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
        //user detailed stored in a object
        user.Name = name;
        user.Email = email;
        user.PhoneNumber = phone;
        //call the repository for updation
        var updatedUser = userRepo.Update(userId,user);
        //if updated the user and returned the updated user notification sent to the updated one
        if(updatedUser != null)
        {
            Console.WriteLine("User Updated Successfully. Wait for the Email && SMS to be sent!!");
            //notification services sent for updation
            string message = $"Successfully updated your account with the details\nName : {updatedUser.Name}\nPhoneNumber : {updatedUser.PhoneNumber}\nEmail : {updatedUser.Email}\n\nThank You!";
            emailService.Send(message, updatedUser);
            smsService.Send(message, updatedUser);
        }
        return updatedUser;
    }
}