using ScheduleShowings.Presentation;

namespace ScheduleShowings;

class Program
{
    static void Main(string[] args)
    {
        
        UserMenu userMenu = new UserMenu(); //instantiating the UserMenu class in the UserMenu.cs file by giving the UserMenu a new value
        userMenu.DisplayMenu(); //Using the new userMenu object and the period, then calling the DisplayMenu method which is located in the User Menu class.

    }
}
