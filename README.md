The ENV File will be removed after the evaluation as needed for security purpose.

## Screenshots

<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/1776049b-58a5-41a7-885e-727b36cb1248" />

<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/8807680e-e06a-4d7e-b9c0-99c06ae70bd8" />

<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/44f31e8d-28d7-44a2-9aab-4f281df6d637" />

<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/e5d92a81-0266-466b-a46c-4e9f391e49fb" />

<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/809348fb-cf3a-405b-9a08-10fe6634fa83" />

- Addition of new users
- Validation of the user details
- Donot allow re registration of same email
- Phone number can be used to register
- throw exceptions for invalid users and trying to enter aldready added email
- send notification for creation of account

<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/f9b77f6e-9a9c-4b2e-9144-986c4994b249" />

- get all the user

<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/9e28c23f-f2b8-4da1-916a-3ed68dad8f7c" />

- get the user by email

<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/04f5d9d7-5d00-4dd7-ac29-8a1e4cf8b29b" />

- get the user list by phone number

<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/991bdad3-c3d5-4008-be70-325687863d63" />

- creation of another user

<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/154468d5-314b-4f39-8efd-a06582295ca0" />

- get the user by user id

<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/5f49ed0d-01d6-401f-9100-54d8ed8cb346" />

- update the user 
- send the notification
- donot allow to enter aldready used email id

<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/30ff220d-6e34-4700-9dbd-f972f863ebe2" />

- send message through the email

<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/b5fb82a5-559d-47f3-a216-1e0517eda9bb" />

- send the messagae through the phone number

<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/a0d17a5d-991d-437c-b1bb-7c72c583dd69" />

- deletion of the user by user id
- send notification too

<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/e74a62ef-9953-4d06-be76-02ddda682ac1" />

- check if user is deleted

<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/345e7fde-bfbe-400b-9139-69530bbb3a36" />
<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/b70dfff0-60a1-4fb7-b7d8-25e7b6c0787b" />

- delete the user list by phone number 

<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/778da2e7-85f7-45bd-b38b-c1d2a806d90e" />

- check if the user is deleted

<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/cb964cc3-f25e-47e2-9101-34a465e18e22" />

- deletion done using the email


## Notification App


## Models

- The Models will be created for

    - User
    - Company

- Override of string is created to print the values along with keys.

## Interfaces

- Interfaces
    
    - INotificationService (sending the notification)
    - IRepository (common functions for all repos)
    - IUserService created for the service 

## Repositories

- Repositories

    - AbstractRepository (implement IRepository where common functions are defined)
    - UserRepository (create function)

Interface created for the Repository (Basic CRUD Operations)

- Create
- Delete
- Update
- Get Operation By Id
- Get All User

This interface repository is used for all the Data and an Abstract class can be defined as the functions are similar and no repetation of the code is not needed.

It can be inherited.

AbstractRepository created implementing the IRepository

- Update
- Delete
- Get By iD
- Get All

these functions are similar so no needed to create this for all the model that are created.

- Create function 
    
    - will be different as the attributes and validation are needed to be done which will differ for different for each model. 
    - so the class repository for other models that are inherited can override the function 

Note - The other functions for each repostory can be additionally added if required as per the requirements

The Repositories that are created
- User Repository

User Repository

- create function created
- static variable createad for userId
- userId will be increased for each user addition
- all the attributes are validated in the presentation and buisness layer itself

## InputsCheck

- InputsCheck

Used to check if the inputs are entered correctly or not.If not again loop will be used untill correct input is entered.

- EmailInput
- SMSInput
- IDInput
- MessageInput


## Services

- Email (real email notification sending implemeneted)

    - SendNotification
    - LogNotification
    - Validate notifcation

- SMS  (only console print)

    - SendNotification
    - LogNotification
    - Validate notifcation

- User

    - UserServiceByEmail

        - GetUserByEmail
        - DeleteUserByEmail

    - UserServiceByPhone

        - GetUserByPhone
        - DeleteUserByPhone
        
    - UserServiceById

        - GetUserById
        - DeleteUserById
        - UpdateUserById

    - UserServiceMain.cs

        - print all notification

## Validation

- Validation

    - EmailValidation (Regex)
    - PhoneNumberValidation (Regex)
    - MessageValidation (Conditions)

## Options used in the application

- Add User
- Delete User
    - Delete User By UserId
    - Delete User By Phone Number
    - Delete User By Email
- Update The User
- Get The User
    - Get User By Id
    - Get User By Email
    - Get User By PhoneNumber
    - Get All User
- Deliver Message
    - Email
    - SMS   

The files in the project is origanised by the usage of partial class

By cliking the needed options the logic passess

## Functions and its usage 

Add User

- check the phone number and email id
- no duplicate email user can be added
- phone number duplication for a user is allowed
- a user can have only one email and multiple phone number for registration of user account
- once inputs are checked user added to dictionary
- after creation notification is sent 

Get User

- GetUserById

    - id input is validated (only number greater than 0)
    - Call the user service which implemets the Interface UserService
    - User or null is returned
    - the service is passed to repo and the data is returned

- GetUserByEmail

    - email is validated (loop untill correct mail is entered)
    - Call the user service which implemets the Interface UserService
    - User or null is returned
    - the service is passed to repo and the data is returned

- GetUserByPhone

    - phone number is validated (loop untill correct mail is entered)
    - Call the user service which implemets the Interface UserService
    - User or null is returned
    - the service is passed to repo and the data is returned

- GetAllUser

    - Call the user service which implemets the Interface UserService
    - User List or empty list is returned
    - the service is passed to repo and the data is returned

Delete User

- DeleteUserById

    - id input is validated (only number greater than 0)
    - Call the user service which implemets the Interface UserService
    - User or null is returned
    - the service is passed to repo and the data is returned
    - if user null an message is displayed
    - if user found with that id is deleted.

- DeleteUserByEmail

    - email is validated (loop untill correct mail is entered)
    - Call the user service which implemets the Interface UserService
    - User or null is returned by checking if user registered or not
    - the service is passed to repo and the data is returned
    - if user null an message is displayed
    - if user found then registered user with that email is deleted

- DeleteUserByPhone

    - phone number is validated (loop untill correct mail is entered)
    - Call the user service which implemets the Interface UserService
    - User or null is returned by checking if user registered or not
    - the service is passed to repo and the data is returned
    - if user null an message is displayed
    - if user found then all the resgistered user with that phone number is deleted
    - all user with the registered phone number is deleted.

- Update user

    - update the user by id
    - check the phone number and email id
    - no duplicate email user can be added
    - check the entered email is not already registered. if found then not possible
    - phone number duplication for a user is allowed
    - a user can have only one email and multiple phone number for registration of user account
    - once inputs are checked user updated to dictionary
    - after updation notification is sent 
