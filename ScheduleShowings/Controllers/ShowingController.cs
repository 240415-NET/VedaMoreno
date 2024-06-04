
using ScheduleShowings.Models;
// using ScheduleShowings.DataAccess;
using ScheduleShowings.Presentation;
using System.Diagnostics.Contracts;
using ScheduleShowings.Data;


namespace ScheduleShowings.Controllers;


public class ShowingController  
//This class holds the functionality for controlling the various methods being used by the Presentation layer and the accessing of the Showing data at the Data layer for finding, adding, storing, and removing Showing data  
{
    public static SQLShowingStorage showingData = new SQLShowingStorage();  //create new SQLUserStorage object and assign it showingData

    
    public List<Showing> FindShowingForUser(Guid userId)  //creat a List of FindShowingForUser method with one GUID parameter
    
    {
        List<Showing> showings = showingData.FindShowing(userId);  //Create a list of showings object when FindShowing method is called and receiving one argument
        return showings;  //returns list of showings to User
    }

    public void AddShowing(Showing newShowing)  //AddShowing method which takes in one argument
    {
        showingData.StoreShowing(newShowing);  //Calls StoreShowing method which takes in one argument and stores showing in Showing Storage/SQL DB
    }
   
   public void RemoveShowing(Showing removeShowing)  //RemoveShowing method which takes in one argument
    {
        showingData.RemoveShowing(removeShowing);  //Calls RemoveShowing method and removes Showing from Showing Storage/SQL DB
        
    }
}