// Bringing in the classes from Presentation and Model namespace to utilize here in program file
using ScheduleShowings.Presentation;
using ScheduleShowings.Models;


namespace ScheduleShowings;

class Program
{
    static void Main(string[] args)
    {
        
        UserMenu userMenu = new UserMenu(); //instantiating the UserMenu class in the UserMenu.cs file by giving the UserMenu a new value
        userMenu.StartMenu(); //Using the new userMenu object and the period, then calling the DisplayMenu method which is located in the User Menu class.

    }
}
