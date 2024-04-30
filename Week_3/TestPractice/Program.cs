namespace TestPractice;

class Program
{
    static void Main(string[] args)
    {
        int a = 10;
        int b = 20;
        int result1 = 0;
        int result = AddTwoNumbers(a, b);
        result1 = result1 + result; 
        Console.WriteLine(result);
        result = MultiplyTwoNumber(a,b);
        result1 = result + result1;
        Console.WriteLine(result);
    Console.WriteLine(result1);
        // for(int i = 1; i <=10; i++)
        // {

        //     Console.WriteLine("Numbers:" + (i%2));


        // }



    }
    public static int AddTwoNumbers(int a, int b)

    {

        return a + b;
    }

    public static int MultiplyTwoNumber(int a, int b)

    {
        return a * b;
    }


}
