using NotificationApp.Validation;
using NotificationApp.Models;
using NotificationApp.Services;
using NotificationApp.Interfaces;
using NotificationApp.Inputs;
using DotNetEnv;
using System.Collections;
using System.Reflection.Metadata;

internal class Program
{
    static void Main(string[] args)
    {
        Env.Load();

        //display the company details from the models
        Company company = new Company();
        Console.WriteLine(company);
        
        //user service object created to handle every user services
        IUserService userService = new UserService();
        //used for inputs displaying to avoid repeated code
        InputsCheck inputCheck = new InputsCheck();

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
            Console.WriteLine("Enter 11 To Delete User By Id");
            Console.WriteLine("Enter 0 To Quit The Loop");
            Console.WriteLine("------------------------------------------------");

            int typechoice;

            while (!int.TryParse(Console.ReadLine(), out typechoice) || typechoice > 11 || typechoice < 0)
            {
                Console.WriteLine("Enter Vaild Input");
            }

            switch (typechoice)
            {
                //add user
                case 1:
                    {
                        var user = userService.AddUser();

                        //this condition is applied if user registering with aldready registered email id
                        if (user == null) Console.WriteLine("User not added");
                        break;
                    }

                //get the user by email
                case 2:
                    {
                        Console.WriteLine("Enter the Email To Get The User");
                        //Inputs given and validated - check inputcheck file
                        string email = inputCheck.EmailInputs();
                        var user = userService.GetUserByEmail(email);
                        //display if no user with the email id found
                        if (user == null)
                        {
                            Console.WriteLine($"No User Found With Email Address {email}");
                            break;
                        }
                        Console.WriteLine(user);
                        break;
                    }

                //get the user by phone number
                case 3:
                    {
                        Console.WriteLine("Enter the PhoneNumber To Get The User");
                        //Inputs given and validated - check inputcheck file
                        string phone = inputCheck.PhoneNumberInputs();
                        var user = userService.GetUserByPhoneNumber(phone);
                        //display if no user with the phone number found
                        if (user == null)
                        {
                            Console.WriteLine($"No User Found With Phone Number {phone}");
                            break;
                        }
                        foreach(var item in user)
                        {
                            Console.WriteLine(item);
                        }
                        break;
                    }
                
                //display all the registered user - no return statement everthing handled in service
                case 4:
                    {
                        userService.PrintAllUsers();
                        break;
                    }
                
                //delete the user by email id
                case 5:
                    {
                        Console.WriteLine("Enter the Email To Delete The User");
                        //Inputs given and validated - check inputcheck file
                        string email = inputCheck.EmailInputs();
                        var user = userService.DeleteUserByEmail(email);
                        //display if no user with the email id found
                        if (user == null)
                        {
                            Console.WriteLine($"No User Found With Email Address {email}");
                            break;
                        }
                        Console.WriteLine(user);
                        break;
                    }

                // here all the user with the registered phone number will be deleted - used in rare cases if needed
                case 6:
                    {
                        Console.WriteLine("Enter the PhoneNumber To Delete The User");
                        //Inputs given and validated - check inputcheck file
                        string phone = inputCheck.PhoneNumberInputs();
                        var user = userService.DeleteUserByPhoneNumber(phone);
                        //display if no user with the phone number found
                        if (user == null)
                        {
                            Console.WriteLine($"No User Found With Phone Number {phone}");
                            break;
                        }
                        Console.WriteLine("Deleted User List With Phone Number");
                        foreach(var item in user)
                        {
                            Console.WriteLine(item);
                        }
                        break;
                    }

                //customised message send to the email only to the registered users
                case 7:
                    {
                        Console.WriteLine("Enter Email To Send Message To The User");
                        //Inputs given and validated - check inputcheck file
                        string email = inputCheck.EmailInputs();
                        var user = userService.GetUserByEmail(email);
                        //display if no user with the email id found
                        if (user == null)
                        {
                            Console.WriteLine($"No User Found With Email Address {email}");
                            break;
                        }
                        string message = inputCheck.MessageInputs(email);
                        INotification emailService = new EmailService();
                        emailService.Send(message, user);
                        break;
                    }

                //customised message send to the phone number only to the registered users
                case 8:
                    {
                        Console.WriteLine("Enter PhoneNumber To Send Message To The User");
                        //Inputs given and validated - check inputcheck file
                        string phone = inputCheck.PhoneNumberInputs();
                        var user = userService.GetUserByPhoneNumber(phone);
                        if (user == null)
                        {
                            Console.WriteLine($"No User Found With Phone Number {phone}");
                            break;
                        }
                        string message = inputCheck.MessageInputs(phone);
                        INotification smsService = new SMSService();
                        foreach(var item in user)
                        {
                            smsService.Send(message, item);
                        }
                        break;
                    }
                case 9:
                    {
                        //Inputs given and validated - check inputcheck file
                        int userid = inputCheck.UserIdInputs();
                        var user = userService.GetUserById(userid);
                        //display if no user with the id found
                        if (user == null) 
                        {
                            Console.WriteLine("User not found");
                            break;
                        }
                        Console.WriteLine(user);
                        break;
                    }
                case 10:
                    {
                        //Inputs given and validated - check inputcheck file
                        int userid = inputCheck.UserIdInputs();
                        var user = userService.UpdateUserById(userid);
                        //display if no user with the id found
                        if (user == null) 
                        {
                            Console.WriteLine("User not found");
                            break;
                        }
                        Console.WriteLine(user);
                        break;
                    }
                case 11:
                    {
                        //Inputs given and validated - check inputcheck file
                        int userid = inputCheck.UserIdInputs();
                        var user = userService.DeleteUserById(userid);
                        //display if no user with the id found
                        if (user == null) 
                        {
                            Console.WriteLine("User not found");
                            break;
                        }
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