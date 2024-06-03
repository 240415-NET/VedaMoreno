using ScheduleShowings.Presentation;
using ScheduleShowings.Models;
using ScheduleShowings.Data;


namespace ScheduleShowings.Controllers;


public class UserController  //This class holds the functionality for controlling the various methods being used by the Presentation layer and the accessing of the User data at the Data layer for creating, finding, storing, and returning User data  
{
    private static SQLUserStorage _userData = new SQLUserStorage();  //create new SQLUserStorage object and assign it _userData
    public static User CreateNewUser(string _userInput)  //Method that creates the New User profile/account and receives one argument
    {
        User newUser = new User(_userInput);  //create newUser object and assign it newUser

        Console.WriteLine(newUser.userName);  //Console output to User of userName and userId
        Console.WriteLine(newUser.userId);
        _userData.StoreUser(newUser);  //Method to store _userData 
        return newUser;  //return newUser
    }
    public static bool UserExists(string _userInput)  //Method to verify if User exists and receives one argument
    {
       if(_userData.FindUser(_userInput)!=null)  //Method to Find User and verify if not null
       {
         
            return true;  //returns valid as true
       }

       else {

        return false;  //returns valid as false
       }
    }

    public static User ReturnUser(string _userInput)  //Method to verify if User is a Return User and receives one argument
    {
        User existingUser = _userData.FindUser(_userInput);  //Validates User was found and creates new existingUser object 
        return existingUser;  //returns existingUser
    
    }
}
