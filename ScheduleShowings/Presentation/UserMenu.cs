
using ScheduleShowings.Models;

namespace ScheduleShowings.Presentation;

public class UserMenu // Class that holds the UI display/menu for creating a new User, return, User Log in and exiting the menu. 
{

    public void DisplayMenu() //created a method for creating and displaying the Display Menu for the User when opening the program. 
    {
        int userSelection = 0;
        bool validInput = true;

        Console.WriteLine("Welcome to the Showings Scheduler, please select an option");
        Console.WriteLine("1.  Create New User");
        Console.WriteLine("2.  Returning User Log In");
        Console.WriteLine("3.  Exit Scheduler program");

        //Set up the try catch to cover the User input and validate input choice and exception,
        // Use the do while to allow User to try again

        do
        {
            try
            {
                userSelection = Convert.ToInt32(Console.ReadLine()); //Naming the variable, and Using ToIn32 to convert the return of string to an Integer
                validInput = true; //logic for validating whether User input is valid or not

                switch (userSelection)
                {

                    case 1:  //Create a New User profile
                        CreateUserMenu();

                        break;

                    case 2:

                        UserLoginMenu(); //Log In for a Return User
                        break;

                    case 3: //User selects to Exit the program
                        return;

                    default:  //If User input is not 1, 2 or 3.
                        validInput = false;
                        Console.WriteLine("Please enter a valid number from the default menu!");
                        break;
                }

            }
            catch (Exception e) //Creating the catching exception, The catch block takes a parameter of an exception type 
            {
                validInput = false;
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                Console.WriteLine("Please enter a valid number (from the exception)!");
            }

        } while (!validInput); //do while will continue to loop until valid input returns false

    }

}




