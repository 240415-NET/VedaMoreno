

namespace ScheduleShowings.Models;


public class Showing
{
    public Guid showingId { get; set; }
    public Guid userId { get; set; }

    public string showingName { get; set; }

    public string showingDate { get; set; }
    public string showingTime { get; set; }
    //Ensure I use string for date and time
    public string showingAddress { get; set; }
    public string showingCity { get; set; }
    public string showingState { get; set; }
    public string showingZip { get; set; }

    //Constructors 
    public Showing() { }

    public Showing(Guid userId, string showingName, string showingDate, string showingTime, string showingAddress, string showingCity, string showingState, string showingZip)
    {
        this.userId = userId;
        showingId = Guid.NewGuid();
        this.showingName = showingName;
        this.showingDate = showingDate;
        this.showingTime = showingTime;
        this.showingAddress = showingAddress;
        this.showingCity = showingCity;
        this.showingState = showingState;
        this.showingZip = showingZip;

    }
    public Showing(Guid showingId, Guid userId, string showingName, string showingDate, string showingTime, string showingAddress, string showingCity, string showingState, string showingZip)
    {
        this.showingId = showingId;
        this.userId = userId;
        this.showingName = showingName;
        this.showingDate = showingDate;
        this.showingTime = showingTime;
        this.showingAddress = showingAddress;
        this.showingCity = showingCity;
        this.showingState = showingState;
        this.showingZip = showingZip;

    }

    public override string ToString()
    {
        return $"Showing ID: {showingId}\nUser ID: {userId}\nShowing Name: {showingName}\nDate: {showingDate}\nTime: {showingTime}\nAddress: {showingAddress}\nCity: {showingCity}\nState: {showingState}\nZip: {showingZip}";
    }
    // public string AbbrToString()
    // {
    //     return String.Format("Description: {0,-25}   Purchase Date: {1,10:d}   Original Cost: {2,-12:C2}",description,purchaseDate,originalCost);
    // }
}