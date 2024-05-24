using ScheduleShowings.Controllers;
using ScheduleShowings.Models;


namespace ScheduleShowings.Presentation;

public class ShowingMenu
{

    public static void ShowingFunctionMenu(User user)
    {
        string userInput;
        bool validInput = false;


        try
        {
            do
            {
                Console.Clear();

                Console.Write("Please select from the following options:\n1. View List of Showings\n2. Add Showing\n3. Remove Showing\n4. Exit Program");
                userInput = Console.ReadLine().Trim().ToLower();
                switch (userInput)
                {
                    case "1":
                    case "1.":
                    case "1. list":
                    case "1. list showing":
                    case "list":
                    case "list showing":
                        ViewItemMenu(user.userId);
                        validInput = true;
                        break;
                    case "2":
                    case "2.":
                    case "2. new":
                    case "2. new showing":
                    case "new":
                    case "new showing":
                        validInput = true;
                        NewShowingItem(user);
                        break;
                    case "3":
                    case "3.":
                    case "3. remove":
                    case "3. remove showing":
                    case "remove":
                    case "remove showing":
                        validInput = true;

                        // Console.WriteLine(ViewAllItems(user.userId,1,"Which showing record would you like to delete?"));
                        // ItemController.RemoveItem(ViewAllItems(user.userId, 1, "Which item/showing would you like to delete?"), user);
                        break;
                      case "4":
                    case "4.":
                    case "4. exit":
                    case "4. exit program":
                    case "exit":
                    case "exit program": 
                        return;
                    break;

                    default:
                        Console.WriteLine("Please key a valid option");
                        break;
                    

                }
            }
            while (validInput == false);
        }

        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
    public static void NewShowingItem(User user)
    {
        bool entrySuccess = false;

        do
        {
            try
            {
                string showingAddress;
                string showingCity;
                string showingState;
                string showingZip;
                DateTime showingDate;
                DateTime showingTime;

                Console.WriteLine("Please enter the street address for your showing. (ie:  123 Main St.)");
                showingAddress = Console.ReadLine().Trim();
                Console.WriteLine("Please enter the city for your showing");
                showingCity = Console.ReadLine().Trim();
                Console.WriteLine("Please enter the state for your showing, (ie:  IN)");
                showingState = Console.ReadLine().Trim();
                Console.WriteLine("Please enter the zip code for your showing, (ie:  10027)");
                showingZip = Console.ReadLine().Trim();
                Console.WriteLine("Please enter the date of your showing, please enter the format YYYY/MM/DD");
                showingDate = DateTime.Parse(Console.ReadLine().Trim());
                Console.WriteLine("Please enter the time of your showing, please enter the format ie:");
                showingTime = DateTime.Parse(Console.ReadLine().Trim());
                entrySuccess = true;
                // ItemController.CreateItem(user, showingAddress, showingCity, showingState, showingZip, showingDate, showingTime);
            }
            catch (Exception e)
            {
                Console.Clear();
                Console.WriteLine("Please key in a valid input!");
            }
        }
        while (entrySuccess == false);
    }

    public static void ViewItemMenu(Guid userID)
    {
        Guid userReturnedGuid;
        bool exitViewMenu = false;
        do
        {
            Console.Clear();
            Console.WriteLine("Please make a selection");

            Console.WriteLine("1. View my Showings");
            Console.WriteLine("2. Back to Main Menu");
            string userInput = (Console.ReadLine() ?? "").Trim();
            if (String.IsNullOrEmpty(userInput))
            {
                Console.WriteLine("Your selection cannot be empty or blank, please enter a number.");
                Console.ReadKey();
                exitViewMenu = false;
            }
            else
            {
                try
                {
                    int userSelection = Convert.ToInt32(userInput);
                    switch (userSelection)
                    {
                        case 1:
                            // userReturnedGuid = ViewAllItems(userID, 1);
                            // if (userReturnedGuid != Guid.Empty) { ViewShowingItemDetails(userID, userReturnedGuid); }
                            break;

                        case 2:
                            exitViewMenu = true;
                            break;
                        default:
                            Console.WriteLine("Input not valid, please try again.");
                            Console.ReadKey();
                            exitViewMenu = false;
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine(e.StackTrace.ToString());
                    Console.ReadKey();
                }
            }
        } while (!exitViewMenu);
    }

    // public static Guid ViewAllItems(Guid userID, int abbreviatedList = 0, string messageToUser = "Which item would you like to view?")
    // {
    //     // List<Item> allMyItems = ItemController.GetAllItems(userID);
    //     if (allMyItems.Count() < 1)
    //     {
    //         Console.WriteLine("You have nothing...");
    //         Console.ReadKey();
    //     }
    //     else
    //     {
    //         bool exitView = false;
    //         do
    //         {
    //             Console.Clear();
    //             int loopCount = 1;
    //             foreach (Item item in allMyItems)
    //             {
    //                 if (abbreviatedList == 0)
    //                 {
    //                     Console.WriteLine(item);
    //                 }
    //                 else
    //                 {
    //                     Console.WriteLine($"{loopCount}: {item.AbbrToString()}");
    //                 }
    //                 loopCount++;
    //             }
    //             Console.WriteLine($"{loopCount}: Exit");
    //             Console.WriteLine(messageToUser);
    //             string userInput = (Console.ReadLine() ?? "").Trim();
    //             try
    //             {
    //                 int userChoice = Convert.ToInt32(userInput);
    //                 if (userChoice == loopCount)
    //                 {
    //                     exitView = true;
    //                 }
    //                 else if (userChoice <= allMyItems.Count() && userChoice > 0)
    //                 {
    //                     return allMyItems[userChoice - 1].itemId;
    //                 }
    //                 else
    //                 {
    //                     Console.WriteLine("Wut? Pick a number from the list");
    //                     Console.ReadKey();
    //                     exitView = false;
    //                 }
    //             }
    //             catch (Exception e)
    //             {
    //                 Console.WriteLine("Try picking a NUMBER from the provided list.");
    //                 Console.ReadKey();
    //                 exitView = false;
    //             }
    //         } while (!exitView);
    //     }
    //     return Guid.Empty;
    // }

    // public static Guid ViewMyItems(Guid userID, int abbreviatedList = 0, string messageToUser = "Which item would you like to view?")
    // {
    //     List<Item> allMyItems = ItemController.GetItems(userID);
    //     if (allMyItems.Count() < 1)
    //     {
    //         Console.WriteLine("You have nothing...");
    //         Console.ReadKey();
    //     }
    //     else
    //     {
    //         bool exitView = false;
    //         do
    //         {
    //             Console.Clear();
    //             int loopCount = 1;
    //             foreach (Item item in allMyItems)
    //             {
    //                 if (abbreviatedList == 0)
    //                 {
    //                     Console.WriteLine(item);
    //                 }
    //                 else
    //                 {
    //                     Console.WriteLine($"{loopCount}: {item.AbbrToString()}");
    //                 }
    //                 loopCount++;
    //             }
    //             Console.WriteLine($"{loopCount}: Exit");
    //             Console.WriteLine(messageToUser);
    //             string userInput = (Console.ReadLine() ?? "").Trim();
    //             try
    //             {
    //                 int userChoice = Convert.ToInt32(userInput);
    //                 if (userChoice == loopCount)
    //                 {
    //                     exitView = true;
    //                 }
    //                 else if (userChoice <= allMyItems.Count() && userChoice > 0)
    //                 {
    //                     return allMyItems[userChoice - 1].itemId;
    //                 }
    //                 else
    //                 {
    //                     Console.WriteLine("Wut? Pick a number from the list");
    //                     exitView = false;
    //                 }
    //             }
    //             catch (Exception e)
    //             {
    //                 Console.WriteLine("Try picking a NUMBER from the provided list.");
    //                 exitView = false;
    //             }
    //         } while (!exitView);
    //     }
    //     return Guid.Empty;
    // }


    // public static void ViewShowingItemDetails(Guid userID, Guid itemID)
    // {
    //     List<Item> allMyItems = ItemController.GetAllItems(userID);
    //     Console.Clear();
    //     var SpecificItem = allMyItems.Where(x => x.itemId.Equals(itemID));
    //     foreach (var thing in SpecificItem)
    //     {
    //         Console.WriteLine(thing);
    //     }
    //     Console.ReadKey();
    // }
}