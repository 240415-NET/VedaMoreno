using System.Security.Cryptography;

namespace Arrays;

class Program
{
    static void Main(string[] args)
    {
       string[] city = new string[3]{"Tampa", "Jacksonville", "Miami"};
       Console.WriteLine(city[1]); 
       Console.WriteLine(city[0]);
    }
}
