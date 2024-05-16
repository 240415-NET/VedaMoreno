using ScheduleShowings.Presentation;
using ScheduleShowings.Models;

namespace ScheduleShowings.Controllers;


public class UserController
{
    public static void CreateNewUser(string _userInput)
    {
        User newUser = new User(_userInput);

        
    }
    public static bool UserExists(string _userInput)
    {
        return false;
    }
}
