

namespace ScheduleShowings.Models;


public class Showing  //This class holds the functionality for Showing data and constructors
{
    public Guid showingId { get; set; }  //GUID data type which creates the random and unique showingId
    public Guid userId { get; set; }  //GUID data type which creates the random and unique UserId

    public string showingName { get; set; }  //Get and Set the string type variable showingName

    public string showingDate { get; set; }  //Get and Set the string type variable showingDate
    public string showingTime { get; set; }  //Get and Set the string type variable showingTime
        public string showingAddress { get; set; }  //Get and Set the string type variable showingAddress
    public string showingCity { get; set; }  //Get and Set the string type variable showingCity
    public string showingState { get; set; }  //Get and Set the string type variable showingState
    public string showingZip { get; set; }  //Get and Set the string type variable showingZip

    //Constructors 
    public Showing() { }  //Default Constructor with no parameters

    public Showing(Guid userId, string showingName, string showingDate, string showingTime, string showingAddress, string showingCity, string showingState, string showingZip)
    //This Constructor takes in eight arguments
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
    //This Constructor takes in nine arguments
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

    public override string ToString()  //ToString method to provide a more suitable return and representation to the User of all the constructors
    {
        return $"\nShowing ID: {showingId}\nUser ID: {userId}\nShowing Name: {showingName}\nDate: {showingDate}\nTime: {showingTime}\nAddress: {showingAddress}\nCity: {showingCity}\nState: {showingState}\nZip: {showingZip}\n";
    }
    
}