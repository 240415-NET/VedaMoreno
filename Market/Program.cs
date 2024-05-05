namespace Store;

class Program
{
    static void Main(string[] args)
    {
        string itemsInList = "";
        bool enterAdditionalItem = true;
        string answer = "";
        List<string> storeList = new List<string>();

        Console.WriteLine("Store items Menu");

        do
        {
            Console.WriteLine("Please enter grocery item: ");
            itemsInList = Console.ReadLine();

            storeList.Add(itemsInList);

            Console.WriteLine("Do you want to enter another item, Yes or No?");
            answer = Console.ReadLine();


            if (answer == "yes")
            {
                enterAdditionalItem = true;

            }

            else if (answer == "no")
            {

                enterAdditionalItem = false;

            }


        } while (enterAdditionalItem == true);

        Console.WriteLine("List:  " + storeList[0]);

    }
}
