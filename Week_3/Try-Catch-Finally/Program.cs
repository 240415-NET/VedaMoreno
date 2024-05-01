using System;

namespace Try_Catch_Finally;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            Console.WriteLine("Please input a number");

            int num = int.Parse(Console.ReadLine());
            Console.WriteLine($"Square root of {num} is {num * num}");
        }

        catch
        {
            Console.Clear();
            Console.WriteLine("Format error occured, please check number");
        }
    }
}