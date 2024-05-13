
using ScheduleShowings.Models;

namespace ScheduleShowings.Presentation;

public class UserMenu // Class that holds the UI display/menu for creating a new User, return User Log in and exiting the menu. 
{

    public void DisplayMenu() //created a method for creating and displaying the Display Menu for the User when opening the program. 
    {

        Console.WriteLine("Welcome to the Showings Scheduler, please select an option");
        Console.WriteLine("1.  Create New User");
        Console.WriteLine("2.  Returning User Log In");
        Console.WriteLine("3.  Exit Scheduler program");

    }

}
