
using ScheduleShowings.Models;
// using ScheduleShowings.DataAccess;
using ScheduleShowings.Presentation;
using System.Diagnostics.Contracts;
using ScheduleShowings.Data;


namespace ScheduleShowings.Controllers;


public class ShowingController
{
    public static SQLShowingStorage showingData = new SQLShowingStorage();

    //created a SQL showing storage object, this object has a method called FindShowing
    //that takes in a parameter of Guid Id
    public List<Showing> FindShowingForUser(Guid userId)
    {
        List<Showing> showings = showingData.FindShowing(userId);
        return showings;
    }

    public void AddShowing(Showing newShowing)
    {
        showingData.StoreShowing(newShowing);
    }
   
   public void RemoveShowing(Showing removeShowing)
    {
        showingData.RemoveShowing(removeShowing);
        
    }
}