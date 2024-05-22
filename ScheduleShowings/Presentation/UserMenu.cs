
using ScheduleShowings.Controllers;
using ScheduleShowings.Models;

namespace ScheduleShowings.Presentation;

public class UserMenu // Class that holds the UI display/menu for creating a new User, return, User Log in and exiting the menu. 
{

    public void StartMenu() //created a method for creating and displaying the Display Menu for the User when opening the program. 
    {
        int userSelection = 0; // We are taking the user input as numbers for selection
        bool validInput = false; // We are using a boolean to indicate if the input is correct

        // Print out UI to the user console
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

                        // UserLoginMenu(); //Log In for a Return User
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

        } while (!validInput); //do while will continue to loop until valid input returns true

    }

    public void CreateUserMenu() //Method that creates the New User profile/account
    {
        string userInput = "";//declared and inititalized userInput object
        bool validInput = false;
        do
        {
            Console.WriteLine("Please create and enter a Username:  "); //Prompting User to create and input a User 


            userInput = Console.ReadLine();

            userInput = userInput.Trim(); //Use the Trim method to trim the string whereas it removes any beginning or ending spaces

            if (String.IsNullOrEmpty(userInput)) //verifies if User input is null or an empty string
            {
                validInput = false;
                Console.WriteLine("Username cannot be empty or blank, please try entering another Username again");
            }
            else if (UserController.UserExists(userInput))
            {
                //verify if User exists already by calling the UserController, User Exists method.
                validInput = false;
                Console.WriteLine("Username already exists, please use another Username");

            }
            else
            {
                //call UserController method CreateNewUser to create a new User profile
                validInput = true;
                UserController.CreateNewUser(userInput);
                Console.WriteLine("Success! Profile has been created");
            }
        } while (!validInput); //the do while will continue to loop until validInput is true/valid
    }

    // public void UserLoginMenu() //Method that creates the Return User Log in Menu
    // {
    //     string userInput = "";//declared and inititalized userInput object with type being string
    //     bool validInput = false;

    //     do
    //     {
    //         Console.WriteLine("Please enter your Username:  "); //Prompting Return User to input their User Name

    //         userInput = Console.ReadLine();

    //         userInput = userInput.Trim(); //Use the Trim method to trim the string whereas it removes any beginning or ending spaces

    //         if (String.IsNullOrEmpty(userInput)) //verifies if User input is null or an empty string
    //         {
    //             validInput = false;
    //             Console.WriteLine("Username cannot be empty or blank, please try entering another Username again");
    //         }
    //         else if (UserController.UserExists(userInput)) //verify if User exists already by calling the UserController class, User Exists method.
    //         {

    //             validInput = false; //verifies that Username does not exist and informs the user to use another Username
    //             Console.WriteLine("Username does not exist, please use another username");

    //         }
    //         else //if neither check triggers, then we call the ReturnUser method from the User Controller
    //         {
    //             //call UserController, and ReturnUser method to return User information
    //             validInput = true;
    //             User existingUser = UserController.ReturnUser(userInput);
    //             Console.WriteLine("Successful,  you are now logged in");
    //             Console.WriteLine($"Username:   {existingUser.userName}");
    //             Console.WriteLine($"User ID:  {existingUser.userID}");
    //         }
    //     } while (!validInput); //the do while will continue to loop until validInput is true/valid
    // }


}




