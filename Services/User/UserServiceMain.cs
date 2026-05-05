using NotificationApp.Models;
using NotificationApp.Validation;
using NotificationApp.Interfaces;
using NotificationApp.Repository;

namespace NotificationApp.Services;

internal partial class UserService : IUserService
{
    EmailService emailService = new EmailService();
    SMSService smsService = new SMSService();
    IRepository<int, User> userRepo = new UserRepository();
    public User AddUser()
    {
        User user = new User();
        Console.WriteLine("Enter Your Name");

        string name = Console.ReadLine() ?? "";
        while (name.Trim() == "")
        {
            Console.WriteLine("Inavlid Name.Name Should Not be Empty.Enter Valid Name");
            name = Console.ReadLine() ?? "";
        }

        Console.WriteLine("Enter Your Email");

        string email = Console.ReadLine() ?? "";
        while (!EmailValidation.isValidEmail(email))
        {
            Console.WriteLine("Invalid Email Entered.Enter Vaild Email Address");
            email = Console.ReadLine() ?? "";
        }

        Console.WriteLine("Enter Your PhoneNumber");

        string phone = Console.ReadLine() ?? "";
        while (!PhoneNumberValidation.isValidPhoneNumber(phone))
        {
            Console.WriteLine("Invalid Phone Number Entered.Enter Valid PhoneNumber");
            phone = Console.ReadLine() ?? "";
        }
        user.Name = name;
        user.Email = email;
        user.PhoneNumber = phone;

        User createdUser = userRepo.Create(user);

        Console.WriteLine("User Added Successfully");

        string message = $"Successfully created an account with the details\n\nUserId : {createdUser.userId}\nName : {createdUser.Name}\nPhoneNumber : {createdUser.PhoneNumber}\nEmail : {createdUser.Email}\n\nThank You!";
        emailService.Send(message, createdUser);
        smsService.Send(message, createdUser);

        return user;
    }
    public void PrintAllUsers()
    {
        var UserList = userRepo.GetAll();
        if(UserList == null)
        {
            Console.WriteLine("No User Found");
            return;
        }
        foreach (var item in UserList)
        {
            Console.WriteLine(item);
        }
    }
}
