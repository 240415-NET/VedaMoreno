using System.Net;
using System.Security.Cryptography.X509Certificates;
using ScheduleShowings.Controllers;
using ScheduleShowings.Models;


namespace ScheduleShowings.Presentation;

public class ShowingMenu
{
    //created a new object called 'showingController' of the Showing Controller class used in the Showing Controller file. 
    // this showingController object can now be used within this Showing Menu class.
    public static ShowingController showingController = new ShowingController();


    public static void ShowingFunctionMenu(User user)//Create Method ShowingFunctionMenu which provides the functionality for User to have a menu for selection of options
    {
        int userInput; //declare userInput object
        bool validInput = false;  //logic for validating whether User input is valid or not
        try
        {
            do
            {

                Console.Write("Please select from the following options:\n1. View List of Showings\n2. Add Showing\n3. Remove Showing\n4. Exit Program\n");
                //Console output to User to select a showing option
                userInput = Convert.ToInt16(Console.ReadLine()); //Console reads the userInput and string is converted to Integer
                string removeInput = ""; //declare and intialize removeInput

                switch (userInput)  //switch statement used for determining user input cases
                {

                    case 1: //List of Showings for end user
                        List<Showing> showings = showingController.FindShowingForUser(user.userId); //Create List of showings object which the FindShowingForUser method is called in the showing Controller with passing one argument 
                        foreach (Showing show in showings)  //foreach loop to process each item in the showings list
                        {
                            Console.WriteLine(show.ToString()); //Console output of list of showings and convert output to String 
                        }
                        validInput = true;  //logic for validating whether User input is valid or not
                        break;

                    case 2: //Add Showing for end user
                        validInput = true;  //logic for validating whether User input is valid or not
                        Showing newShowing = NewShowingItem(user);  //Create newshowing object which the NewShowingItem method is called (below) with passing one argument 
                        showingController.AddShowing(newShowing);  //Calls the AddShowing method in showing Controller 
                        break;

                    case 3:  //Remove a showing
                        validInput = true;  //logic for validating whether User input is valid or not
                        Console.WriteLine("Please enter the showing name you would like to delete?");  //Console output to User to input showing name to delete
                        List<Showing> showingList = showingController.FindShowingForUser(user.userId);  //Create List of showingList object which the FindShowingForUser method is called in the showing Controller with passing one argument 
                        foreach (Showing show in showingList)  //foreach loop to process each item in the showinglist

                        {
                            Console.WriteLine(show.ToString());  //Console output of list of showings and convert output to String 
                        }
                        removeInput = Console.ReadLine();  //Console reads the line and removes the showing user input (removeInput)
                        Console.WriteLine();

                        int countNotMatching = 0;  //declare and assign countMatching object
                        foreach (Showing show in showingList)  //foreach loop to process each item in the showinglist

                        {
                            if (removeInput == show.showingName)  //remove showingName if = to removeInput 
                            {
                                showingController.RemoveShowing(show);  //Call to RemoveShowing method in showing Controller
                                Console.WriteLine($"Showing: {show.showingName} successfully deleted");  //Console output to User showing was deleted
                            }
                            else if (show.showingName != removeInput)  //if showingName does not equal the removeInput 

                            {
                                countNotMatching = countNotMatching + 1;  //CountNotMatching is 1
                            }

                        }
                        if (countNotMatching == showingList.Count)  //if showing list is = to countNotMatching (0)

                        {
                            Console.WriteLine("Showing was not successfully deleted");  //Then console output to user showing was not deleted
                        }
                        
                        break;

                    case 4: //Exit program for end user
                        validInput = true;  //logic for validating whether User input is valid or not
                        Console.WriteLine($"You are now exiting the showing program.");  //Console output to User they are exiting the program
                        return;

                    default:
                        Console.WriteLine("Please key a valid option");
                        break;


                }

                if (validInput == true)
                {
                    ShowingFunctionMenu(user);  //Calls ShowingFunctionMenu and displays menu to User 
                }

            } while (validInput == false);

        }



        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
    public static Showing NewShowingItem(User user) //Creat NewShowing Item method with one parameter
    {
        bool entrySuccess = false;  

        do
        {
            try  
            {
                string showingAddress; //declare objects/variables
                string showingCity;
                string showingState;
                string showingZip;
                string showingDate;
                string showingTime;
                string showingName;

                Console.WriteLine("Please enter a showing Name for your showing:  ie, Broadway");
                showingName = Console.ReadLine().Trim();
                Console.WriteLine("Please enter the street address for your showing. (ie:  123 Main St.)");
                showingAddress = Console.ReadLine().Trim();
                Console.WriteLine("Please enter the city for your showing");
                showingCity = Console.ReadLine().Trim();
                Console.WriteLine("Please enter the state for your showing, (ie:  IN)");
                showingState = Console.ReadLine().Trim();
                Console.WriteLine("Please enter the zip code for your showing, (ie:  10027)");
                showingZip = Console.ReadLine().Trim();
                Console.WriteLine("Please enter the date of your showing, please enter the format MM/DD/YYYY");
                showingDate = Console.ReadLine().Trim();
                Console.WriteLine("Please enter the time of your showing, please enter the format ie: 08:00 AM or PM");
                showingTime = Console.ReadLine().Trim();
                entrySuccess = true;
                Showing nShowing = new Showing(user.userId, showingName, showingDate, showingTime, showingAddress, showingCity, showingState, showingZip);  
                //Creat new nShowing object with parameters
                // Guid userId, string showingName, string showingDate, string showingTime, string showingAddress, string showingCity, string showingState, string showingZip
                return nShowing;  
            }
            catch (Exception e)  //catch any exceptions
            {
                Console.Clear(); //Clears the Console
                Console.WriteLine("Please key in a valid input!");  //Console output to user to input a valid input
                return null;
            }
        }
        while (entrySuccess == false);  //do while entrysuccess is false 
    }

    public static void ViewItemMenu(Guid userID)  //Create ViewItemMenu method with a GUID userID parameter
    {
        Guid userReturnedGuid;  //user GUID declared
        bool exitViewMenu = false;  //logic for validating whether User exit the program is valid or not
        do
        {
            Console.Clear();
            Console.WriteLine("Please make a selection"); //Console output to User to make selection

            Console.WriteLine("1. View my Showings");
            Console.WriteLine("2. Back to Main Menu");
            string userInput = (Console.ReadLine() ?? "").Trim(); //Reads and trims the userInput
            if (String.IsNullOrEmpty(userInput))  //verifies if userInput is null or empty
            {
                Console.WriteLine("Your selection cannot be empty or blank, please enter a number."); //Console output to user to enter a number
                Console.ReadKey();
                exitViewMenu = false;
            }
            else
            {
                try
                {
                    int userSelection = Convert.ToInt32(userInput);  //create userSelection object and convert userInput to integer
                    switch (userSelection)  //switch statement and condition used for the two cases and default
                    {
                        case 1:
                            userReturnedGuid = ViewAllItems(userID, 1);  //ViewAllItems method with 2 parameters
                            if (userReturnedGuid != Guid.Empty) {ViewShowingItemDetails(userID, userReturnedGuid);}  //conditional logic if userReturnedGuid is not equal to empty
                            //then ViewShowingItemDetails method is 
                            break;

                        case 2:
                            exitViewMenu = true;
                            break;
                        default:
                            Console.WriteLine("Input not valid, please try again.");  //if input is not valid
                            Console.ReadKey();
                            exitViewMenu = false;  
                            break; //exits and breaks out
                    }
                }
                catch (Exception e)  //handles exception
                {
                    Console.WriteLine(e.Message);  //Console output of exception
                    Console.WriteLine(e.StackTrace.ToString());
                    Console.ReadKey();
                }
            }
        } while (!exitViewMenu);  //do while loop until exitViewMenu is not valid
    }

    private static Guid ViewAllItems(Guid userID, int v)  //Create ViewAllItems method of GUID type
    {
        throw new NotImplementedException();  //throws exception error
    }

    private static void ViewShowingItemDetails(Guid userID, Guid userReturnedGuid)  //Create ViewShowingItemDetails with two GUID parameters, userID and userReturnedGuid
    {
        throw new NotImplementedException();  //Exception thrown 
    }
}