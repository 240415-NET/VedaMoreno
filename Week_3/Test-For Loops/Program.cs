namespace Test_For_Loops;

class Program
{
    static void Main(string[] args)
    {
        // Example of for loop
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine("Value of i: {0}", i);
        }

        // // Example of REVERSE for loop
        for (int i = 10; i > 0; i--)
        {
            Console.WriteLine("Value of i: {0}", i);
        }

        // Example of While Loop and using break to exit

        int k = 0;

        while (true)
        {
            Console.WriteLine("k = {0}", k);
            k++;

            if (k > 7)
                break;
        }

        // Example of DO While Loop 
        // Use break or return to exit from the do while loop

        int j = 0;

        do
        {
            Console.WriteLine("j = {0}", j);
            j++;

            if (j > 4)
                break;

        } while (j < 8);

    }

}





