
using ScheduleShowings.Controllers;
using ScheduleShowings.Models;

namespace ScheduleShowings.Presentation;

public class UserMenu // Class that holds the UI display/start menu for options of creating a new User, finding a returning User via User Log in and exiting the menu. 
{

    public void StartMenu() //created a method for creating and displaying the Display/Start Menu for the User when opening the program. 
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

                switch (userSelection) //switch statement used for determining user input cases
                {
                    case 1:  //Create a New User profile
                        User createdUser = CreateUserMenu(); //created an object createdUser which calls the CreateUserMenu down below 
                        ShowingMenu.ShowingFunctionMenu(createdUser); //calls the ShowingFunctionMenu in ShowingMenu
                        validInput = true; //validates if User selected and wants to create a New User profile

                        break;

                    case 2:  //Returning User Log In   

                        User loginUser = UserLoginMenu();   //created an object loginUser for returning Users which calls the UserLoginMenu down below  
                        ShowingMenu.ShowingFunctionMenu(loginUser);  //calls the ShowingFunctionMenu in ShowingMenu
                        validInput = true;  //validates if User selected and wants to log into their profile
                        
                        break;

                    case 3: //User selects to Exit the program 
                        return; 

                    default:  //If User input is not 1, 2 or 3.
                        validInput = false;  //validates if User selected anything other than 1, 2, or 3
                        Console.WriteLine("Please enter a valid number from the default menu!");  //output to User instructing them to input a valid number

                        break;
                }

            }
            catch (Exception e) //Created the catching exception, The catch block takes a parameter of an exception type 
            {
                validInput = false;  //validates if an exception is caught 
                Console.WriteLine(e.Message);  //output to User providing them the exception message
                Console.WriteLine(e.StackTrace); //added StackTrace to show the top-down sequence of function that led to the error 
                Console.WriteLine("Please enter a valid number (from the exception)!"); //output to User instructing them to input a valid number

            }

        } while (!validInput); //do while will continue to loop until valid input is not valid

    }

    public User CreateUserMenu() //Method that creates the New User profile/account
    {
        string userInput = "";//declared and inititalized userInput object
        bool validInput = false; //logic for validating whether User input is valid or not
        do
        {
            Console.WriteLine("Please create and enter a Username:  "); //Prompting User to create and input a Username 


            userInput = Console.ReadLine();  //Console reads the userInput

            userInput = userInput.Trim(); //Use the Trim method to trim the string of the userInput whereas it removes any beginning or ending spaces

            //use if elseif else to verify different user input scenarios
            if (String.IsNullOrEmpty(userInput)) //verifies if User input is null or an empty string
            {
                validInput = false;  //validates if User input is valid or not
                Console.WriteLine("Username cannot be empty or blank, please try entering another Username again");  //output and notification to User instructing them to input a valid number

            }
            else if (UserController.UserExists(userInput))
            {
                //verify if User exists already by calling the UserController, User Exists method.
                validInput = false;  //validates if User input is valid or not
                Console.WriteLine("Username already exists, please use another Username");  //output and notification to User instructing them to input another Username
            }
            else
            {
                //call UserController CreateNewUser method to create a new User profile
                validInput = true;  //validates if User input is valid or not
                User newUser = UserController.CreateNewUser(userInput);  //call UserController, CreateNewUser method to create a new User profile and assigning it newUser object
                Console.WriteLine("Success! Profile has been created");  //output and notification to User instructing them new User profile was created
                return newUser;  //returning newUser object

            }
        } while (!validInput); //the do while will continue to loop until validInput is not valid

        return new User();  //return User
    }

    public User UserLoginMenu() //Method and functionality that creates the Return User Log in Menu
    {
        string userInput = "";//declared and inititalized userInput object with type being string
        bool validInput = false;  //logic for validating whether User input is valid or not

        do
        {
            Console.WriteLine("Please enter your Username:  "); //Prompting Return User to input their User Name

            userInput = Console.ReadLine(); //Console reads userInput

            userInput = userInput.Trim(); //Use the Trim method to trim the string whereas it removes any beginning or ending spaces

            if (String.IsNullOrEmpty(userInput)) //verifies if User input is null or an empty string
            {
                validInput = false;  //logic for validating whether User input is valid or not
                Console.WriteLine("Username cannot be empty or blank, please try entering another Username again");  //output and notification to User input cannot be empty or blank
            }
            else if (!UserController.UserExists(userInput)) //verify if User exists already by calling the UserController class, User Exists method.
            {

                validInput = false; //verifies if or if not User exists 
                Console.WriteLine("Username does not exist, please input another username");  //output and notification to User informing the user to input another Username  

            }
            else //if neither check triggers, then we call the ReturnUser method from the User Controller
            {
                
                validInput = true;
                User existingUser = UserController.ReturnUser(userInput); //call UserController, and ReturnUser method to find and return User and assign it existingUser 
                Console.WriteLine("Successful, you are now logged in!"); //output and notification to User providing confirmation, Username and UserId   
                Console.WriteLine($"Username:   {existingUser.userName}");
                Console.WriteLine($"User ID:  {existingUser.userId}");
                return existingUser; //returns existingUser
            }
        } while (!validInput); //the do while will continue to loop until validInput is not valid

        return new User();  //return User 
    }


}




