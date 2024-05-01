using System;

namespace List;

public class Program
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

        foreach (string store in storeList)

        {

            Console.WriteLine(store);

        }


        List<string> pastryList = new List<string>();

        pastryList.Add("cookie");
        pastryList.Add("donut");
        pastryList.Add("cake");
        pastryList.Add("canoli");
        pastryList.Add("pie");

        foreach (string pastry in pastryList)

        {
            Console.WriteLine(pastry);
        }
    }
}








