namespace MyApp;

class Program
{
    static void Main(string[] args)
    {
        //         // Instantiate both classes
        //         // Call the method in ExampleClass
        ExampleClass.PrintName("Anna");

        //         // Print out the field of the HolderClass

        //         // Once these are working, put the ExampleClass in it's own file and namespace
        //         // Then run the code, and try to get it working

        //         // Next put the HolderClass in it's own file, and unique namespace
        //         // Run the code again, and try to get it working
        //         // Give us input from the terminal

    }
}


public class ExampleClass

{
    string name;
    {
    // Create a method
    public void PrintName(string name);
    Console.WriteLine(name);
    }
}

public class HolderClass
{
    // Create a field
    string name = "Daniel";
    {
        // Print field 
        Console.WriteLine(name);
    }
}





