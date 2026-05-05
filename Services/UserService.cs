using NotificationApp.Models;
using NotificationApp.Validation;
using NotificationApp.Interfaces;
using NotificationApp.Repository;

namespace NotificationApp.Services;

internal class UserService : IUserService
{
    static int userId = 0;

    static Dictionary<int,User> users = new Dictionary<int, User>();
    EmailService emailService = new EmailService();
    SMSService smsService = new SMSService();

    IRepository<int, User> userRepo = new UserRepository();
    public User AddUser()
    {
        User user = new User();
        Console.WriteLine("Enter Your Name");

        string name = Console.ReadLine() ?? "";
        while(name.Trim() == "")
        {
            Console.WriteLine("Inavlid Name.Name Should Not be Empty.Enter Valid Name");
            name = Console.ReadLine() ?? "";
        }

        Console.WriteLine("Enter Your Email");

        string email = Console.ReadLine() ?? "";
        while(!EmailValidation.isValidEmail(email))
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

        userRepo.Create(user);

        users.Add(user.userId,user);
        Console.WriteLine("User Added Successfully");

        string message = $"Successfully created an account with the details\nName : {name}\nPhoneNumber : {phone}\nEmail : {email}\n\nThank You!";
        emailService.Send(message,user);
        smsService.Send(message,user);

        return user;
    }

    public User? GetUserById(int id)
    {
        if(users.ContainsKey(id))
        {
            return users[id];
        }
        return null;
    }
    public User? GetUserByEmail(string email)
    {
        foreach(var item in users.Values)
        {
            if(item.Email == email)
            {
                return item;
            }
        }
        return null;
    }

    public User? GetUserByPhoneNumber(string phonenumber)
    {
        foreach(var item in users.Values)
        {
            if(item.PhoneNumber == phonenumber)
            {
                return item;
            }
        }
        return null;
    }

    public void PrintAllUsers()
    {
        foreach(var item in users.Values)
        {
            Console.WriteLine(item);
        }
    }

    public User? DeleteUserByEmail(string email)
    {
        foreach(var item in users.Values)
        {
            if(item.Email == email)
            {
                users.Remove(item.userId);
                string message = $"Successfully deleted your account with the details\nName : {item.Name}\nPhoneNumber : {item.PhoneNumber}\nEmail : {item.Email}\n\nThank You!";
                emailService.Send(message,item);
                smsService.Send(message,item);
                return item;
            }
        }
        return null;
    }

    public User? DeleteUserByPhoneNumber(string phonenumber)
    {
        foreach(var item in users.Values)
        {
            if(item.PhoneNumber == phonenumber)
            {
                users.Remove(item.userId);
                string message = $"Successfully deleted your account with the details\nName : {item.Name}\nPhoneNumber : {item.PhoneNumber}\nEmail : {item.Email}\n\nThank You!";
                emailService.Send(message,item);
                smsService.Send(message,item);
                return item;
            }
        }
        return null;
    }

    public User? UpdateUserById(int userId)
    {
        User user = GetUserById(userId);
        if(user == null)
        {
            return null;
        }
        Console.WriteLine("Enter 1 To Update the Email");
        Console.WriteLine("Enter 2 To Update the PhoneNumber");
        Console.WriteLine("Enter 3 To Update the Name");
        int choice;
        while(!int.TryParse(Console.ReadLine(),out choice) || choice<0 || choice>3)
        {
            Console.WriteLine("Enter Valid Inuput");
        }
        switch (choice)
        {
            case 1:
            {
                string email = Console.ReadLine() ?? "";
                while(!EmailValidation.isValidEmail(email))
                {
                    Console.WriteLine("Invalid Email Entered.Enter Vaild Email Address");
                    email = Console.ReadLine() ?? "";
                }
                if(GetUserByEmail(email) != null)
                {
                    Console.WriteLine("Aldready User with the Email is Registered");
                    break;
                }
                user.Email = email;
                Console.WriteLine("User updated Successfully");
                break;
            }
            case 2:
            {
                Console.WriteLine("Enter Your PhoneNumber");
                string phone = Console.ReadLine() ?? "";
                while (!PhoneNumberValidation.isValidPhoneNumber(phone))
                {
                    Console.WriteLine("Invalid Phone Number Entered.Enter Valid PhoneNumber");
                    phone = Console.ReadLine() ?? "";
                }
                user.PhoneNumber = phone;
                Console.WriteLine("User updated Successfully");
                break;
            }
            case 3:
            {
                Console.WriteLine("Enter the Name To Be Updated");
                string name = Console.ReadLine() ?? "";
                while(name.Trim() == "")
                {
                    Console.WriteLine("Inavlid Name.Name Should Not be Empty.Enter Valid Name");
                    name = Console.ReadLine() ?? "";
                }
                user.Name = name;
                Console.WriteLine("User updated Successfully");
                break;
            }
        }
        return user;
    }
    public bool CheckUser(User user)
    {
        foreach(var item in users.Values)
        {
            if(item == user)
            {
                return true;
            }
        }
        return false;
    }
}
