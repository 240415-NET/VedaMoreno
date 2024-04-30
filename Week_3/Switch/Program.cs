namespace Switch;

class Program
{
    static void Main(string[] args)
    {
        int g = 30;

        switch (g)
        {
            case 10: 
                Console.WriteLine("Value of g is 10");
                break;
            case 20:
                Console.WriteLine("Value of g is 20");
                break;
            case 30:  
                Console.WriteLine("Value of g is 30");
                break; 
            default:
                Console.WriteLine("Value of g is unkown");
                break;
                
        }

    }
}
