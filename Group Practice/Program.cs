using System.ComponentModel;

namespace Group_Practice;

class Program
{
    static void Main(string[] args)

    {
        List<string> storeList = new List<string> { "Meijer", "Kroger", "Publix", "Whole Foods", "Fresh Market", "Sprouts", "Winn Dixie" };

        List<string> groceryList = new List<string>();

        List<string> purchaseStatus = new List<string>();
        List<GroceryItem> futureGroceryList = new List<GroceryItem>();     
       // futureGroceryList.Add(new GroceryItem("Bread"));
       // futureGroceryList.Add(new GroceryItem("Milk", "in the cart"));   

        string selectedStore;

        Console.WriteLine("Pick a store:");

        for (int i = 0; i < storeList.Count(); i++)
        {

            Console.WriteLine($"{i + 1}. {storeList[i]}");

        }

        string storeLocation = Console.ReadLine();
        int storeNumber = Convert.ToInt32(storeLocation);
        selectedStore = storeList[storeNumber - 1];

        bool exitLoop = true;
        Console.WriteLine("Please enter your grocery items, when done type finished");
        do

        {
            string newGroceryItem = Console.ReadLine();
            if(newGroceryItem.ToLower() == "finished")
            
            {
                exitLoop = false;
            
            }
            else
            {
           //     groceryList.Add(newGroceryItem);
                futureGroceryList.Add(new GroceryItem(newGroceryItem));
            }

        }while (exitLoop);
        futureGroceryList.Add(new GroceryItem("final item", "in the cart"));
        foreach(GroceryItem item in futureGroceryList)
        {

            Console.WriteLine($"{item.ItemName}\t{item.ItemStatus}");
        }



    }
}
