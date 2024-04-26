namespace List;

class Program
{
    static void Main(string[] args)
    {   
        List<string> storeList = new List<string>();

        storeList.Add("Meijer");
        storeList.Add("Kroger");
        storeList.Add("Publix");
        storeList.Add("Whole Foods");
        storeList.Add("Fresh Market");
        storeList.Add("Sprouts");
        storeList.Add("Winn Dixie");

        foreach(string store in storeList)

        { 

            Console.WriteLine(store);

        }

    }
}
