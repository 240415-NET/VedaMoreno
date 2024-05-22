namespace ScheduleShowings.Models;

public class User  //This class holds the functionality for creating a GUID User Id and User Name
                   //There is a prebuilt data type from the default System Library which will create a random and unique User ID for us by utilizing GUID  
{
    public Guid userId {get; set;} //GUID data type which creates the random and unique User ID
    public string userName {get; set;} //Get and Set the string type variable userName

    public User() {}  //Default Constructor with no parameters

    public User(string _userName) //This Constructor takes in one argument

    {
        userName = _userName;
        userId = Guid.NewGuid(); //The NewGuid method creates a random and unique GUID for us and will be passed as userID in the User Constructor when called 
    }

}
