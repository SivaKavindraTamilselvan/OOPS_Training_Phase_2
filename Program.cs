using NotificationApp.Validation;
using NotificationApp.Models;
using NotificationApp.Services;
using NotificationApp.Inputs;
using DotNetEnv;
using System.Collections;
using System.Reflection.Metadata;

internal class Program
{
    static void Main(string[] args)
    {
        Env.Load();

        Company company = new Company();
        Console.WriteLine(company);

        var userService = new UserService();
        var inputCheck = new InputsCheck();

        while (true)
        {
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("Enter 1 To Add User");
            Console.WriteLine("Enter 2 To Get The User By Email");
            Console.WriteLine("Enter 3 To Get The User By PhoneNumber");
            Console.WriteLine("Enter 4 To Display All The Users");
            Console.WriteLine("Enter 5 To Delete The User By Email");
            Console.WriteLine("Enter 6 To Delete The User By PhoneNumber");
            Console.WriteLine("Enter 7 To Deliver The Message To A User By Email");
            Console.WriteLine("Enter 8 To Deliver The Message To A User By Phone Number");
            Console.WriteLine("Enter 9 To Get User By Id");
            Console.WriteLine("Enter 10 To Update User By Id");
            Console.WriteLine("Enter 0 To Quit The Loop");
            Console.WriteLine("------------------------------------------------");

            int typechoice;

            while (!int.TryParse(Console.ReadLine(), out typechoice) || typechoice > 10 || typechoice < 0)
            {
                Console.WriteLine("Enter Vaild Input");
            }

            switch (typechoice)
            {
                case 1:
                {
                    User user = userService.AddUser();
                    break;
                }

                case 2:
                {
                    Console.WriteLine("Enter the Email To Get The User");
                    string email = inputCheck.EmailInputs();
                    var user = userService.GetUserByEmail(email);
                    if (user == null)
                    {
                        Console.WriteLine($"No User Found With Email Address {email}");
                        break;
                    }
                    Console.WriteLine(user);
                    break;
                }

                case 3:
                {
                    Console.WriteLine("Enter the PhoneNumber To Get The User");
                    string phone  = inputCheck.PhoneNumberInputs();
                    var user = userService.GetUserByPhoneNumber(phone);
                    if (user == null)
                    {
                        Console.WriteLine($"No User Found With Phone Number {phone}");
                        break;
                    }
                    Console.WriteLine(user);
                    break;
                }

                case 4:
                {
                    userService.PrintAllUsers();
                    break;
                }

                case 5:
                {
                    Console.WriteLine("Enter the Email To Delete The User");
                    string email = inputCheck.EmailInputs();
                    var user = userService.DeleteUserByEmail(email);
                    if (user == null)
                    {
                        Console.WriteLine($"No User Found With Email Address {email}");
                        break;
                    }
                    Console.WriteLine(user);
                    break;
                }

                case 6:
                {
                    Console.WriteLine("Enter the PhoneNumber To Delete The User");
                    string phone  = inputCheck.PhoneNumberInputs();
                    var user = userService.DeleteUserByPhoneNumber(phone);
                    if (user == null)
                    {
                        Console.WriteLine($"No User Found With Phone Number {phone}");
                        break;
                    }
                    Console.WriteLine(user);
                    break;
                }

                case 7:
                {
                    Console.WriteLine("Enter Email To Send Message To The User");
                    string email = inputCheck.EmailInputs();
                    var user = userService.GetUserByEmail(email);
                    if (user == null)
                    {
                        Console.WriteLine($"No User Found With Email Address {email}");
                        break;
                    }
                    string message = inputCheck.MessageInputs(email);
                    EmailService emailService = new EmailService();
                    emailService.Send(message, user);
                    break;
                }

                case 8:
                {
                    Console.WriteLine("Enter PhoneNumber To Send Message To The User");
                    string phone  = inputCheck.PhoneNumberInputs();
                    var user = userService.GetUserByPhoneNumber(phone);
                    if (user == null)
                    {
                        Console.WriteLine($"No User Found With Phone Number {phone}");
                        break;
                    }
                    string message = inputCheck.MessageInputs(phone);
                    SMSService smsService = new SMSService();
                    smsService.Send(message, user);
                    break;
                }
                case 9:
                {
                    int userid = inputCheck.UserIdInputs();
                    var user = userService.GetUserById(userid);
                    Console.WriteLine(user);
                    break;
                }
                case 10:
                {
                    int userid = inputCheck.UserIdInputs();
                    var user = userService.UpdateUserById(userid);
                    Console.WriteLine(user);
                    break;
                }
                case 0:
                {
                    return;
                }
            }
        }
    }
}