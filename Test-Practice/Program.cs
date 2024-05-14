using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;

namespace Test_Practice;

public class Solution
{
    static void Main(string[] args)
    {
        public bool IsPalindrome(int x)
        {
            return string.Concat(x.ToString().Reverse()) == x.ToString();

        }

        string s = Console.ReadLine();

        bool isPalendrome = CheckForPalindrome(s);
        string strIsPalendrome = isPalendrome.ToString();
        string strLower = strIsPalendrome.ToLower();
        Console.WriteLine(strLower);
    }

    // public static bool CheckForPalindrome(string s)
    // {

    //      return s.SequenceEqual(s.Reverse());

}











