using ScheduleShowings.Presentation;
using ScheduleShowings.Models;
using ScheduleShowings.Data;


namespace ScheduleShowings.Controllers;


public class UserController
{
    private static SQLUserStorage _userData = new SQLUserStorage();
    public static void CreateNewUser(string _userInput)
    {
        User newUser = new User(_userInput);

        Console.WriteLine(newUser.userName);
        Console.WriteLine(newUser.userId);
        _userData.StoreUser(newUser);
    }
    public static bool UserExists(string _userInput)
    {
       if(_userData.FindUser(_userInput)!=null)
       {
         
            return true;
       }

       else {

        return false;
       }
    }

    // public static User ReturnUser(string _userInput)
    // {
    //     // User existingUser = _userData.FindUser(userName);
    //     // return existingUser;
    //     return false;
    // }
}
