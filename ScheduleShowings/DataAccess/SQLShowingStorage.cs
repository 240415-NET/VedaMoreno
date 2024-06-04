using ScheduleShowings.Models;
using System.Data.SqlClient;
namespace ScheduleShowings.Data;

public class SQLShowingStorage  //This class holds the functionality for finding, storing, removing a showing and connecting to a SQL database for accessing, storing and extracting Showing data  

{

    public static string connectionString = File.ReadAllText(@"C:\Users\A221249\Desktop\Desktop\Projects\Team Rocket-Commercial\Claims-API-Desktop\Engineer Bootcamp\Git Hub\ConnectionString.txt");
    //connection string for connecting to SQL DB
    public List<Showing> FindShowing(Guid userId)  //Create List method for finding a Showing w/one GUID parameter of userId. 

    {

        List<Showing> foundShowing = new List<Showing>();  //Create new List of foundShowing object


        //Just like with our INSERT we will create a SqlConnection object
        using SqlConnection connection = new SqlConnection(connectionString);

        try
        {
            //Open the connection
            connection.Open();

            //We start creating our command/Query text
            string cmdText = @"SELECT ShowingId, userId, showingName, showingDate,  showingTime,  showingAddress,  showingCity,  showingState,  showingZip
                                FROM dbo.SHOWING
                                WHERE userId=@userToFind;";

            //We create our SqlCommand object
            using SqlCommand cmd = new SqlCommand(cmdText, connection);

            //We then fill in the parameter @userToFind with our string usernameToFind that comes in
            //as an argument to our method
            cmd.Parameters.AddWithValue("@userToFind", userId);

            //To execute a query, we need to use a SqlDataReader object.
            //This object reads whatever is returned from our query, row by row - column by column
            //As the reader passes over the columns and rows we need to take steps to store or work with 
            //the data that comes back - Once the reader moves on from a row, we would need to execute the 
            //command again to re-read the row.
            //It is forward only! No going back up to another row we have already passed.
            using SqlDataReader reader = cmd.ExecuteReader();  //calls reader method and creates/assigns reader 

            //We are going to use a while-loop to read through our data coming back from our SqlDataReader
            //and execute code until it is done reading
            while (reader.Read())
            {
                //While we are on a particular row, we have to save data if we find it.
                //When using reader.GetType() methods, we have to specify which column we are targeting
                //Like arrays, these start at position 0
                Showing newShowing = new Showing(reader.GetGuid(0), reader.GetGuid(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetString(7), reader.GetString(8));
                //Create newShowing object with nine constructors and their positions

                foundShowing.Add(newShowing);  //Add newShowing


            }//Once we are done reading, and no more records are coming back to be read, we exit the while-loop

            //Close our connection
            connection.Close();

            //If we get to this point and found a Showing, we return the filled out showing object

            //If the new Showing on foundShowing is empty, we manually return a null. 
            //if(String.IsNullOrEmpty(foundUser.userName))
            if (foundShowing.Count <= 0)
            {
                return null;
            }

            //Otherwise we return the found filled out foundShowing object
            return foundShowing;

        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally //We will leverage the finally block to close our connection incase 
        { //either nothing is found OR we actually catch some Exception
            //Close our connection if we find nothing or something bad happens
            connection.Close();
        }

        
        return null;

    }
    public void StoreShowing(Showing newShowing)  //Create method to StoreShowing with one parameter
    {
        //Create a SQLConnection object to be able to connect to our Database.
        //we want this object to be "disposable" - that is to say, we want it to be destroyed or dereferenced
        //as soon as this method is done executing. We do this with a "using" statement.  
        using SqlConnection connection = new SqlConnection(connectionString);

        //After we create our connection object, we call an instance method called Open() to open the connection
        connection.Open();

        //After this, we start to create our command, we can do this with a templated string as shown below.
        //Doing this we can avoid any issues with SQL Injection, as well as not have to mess with 
        //manual string concatenation 
        string cmdText = @"INSERT INTO SHOWING (ShowingId, userId, ShowingName, ShowingDate,  ShowingTime,  ShowingAddress,  ShowingCity,  ShowingState,  ShowingZip)
                            VALUES (@ShowingId, @userId, @showingName, @showingDate,  @showingTime,  @showingAddress,  @showingCity, @showingState, @showingZip);";

        //We use the connection we created and opened, as well as the command text template we created above
        //to create a new SqlCommand object that we will eventually send to do things in our SQL database. 
        using SqlCommand cmd = new SqlCommand(cmdText, connection);

        //Now that we have our SqlCommand object, in this case named cmd, we can call a method AddWithValue() all the showing parameters
        //to fill out the templated INSERT command string
        //We call this a little differently than other instance methods, because we are reaching deeper into
        //the cmd object. 
        cmd.Parameters.AddWithValue("@ShowingId", newShowing.showingId);
        cmd.Parameters.AddWithValue("@userId", newShowing.userId);
        cmd.Parameters.AddWithValue("@showingName", newShowing.showingName);
        cmd.Parameters.AddWithValue("@showingDate", newShowing.showingDate);
        cmd.Parameters.AddWithValue("@showingTime", newShowing.showingTime);
        cmd.Parameters.AddWithValue("@showingAddress", newShowing.showingAddress);
        cmd.Parameters.AddWithValue("@showingCity", newShowing.showingCity);
        cmd.Parameters.AddWithValue("@showingState", newShowing.showingState);
        cmd.Parameters.AddWithValue("@showingZip", newShowing.showingZip);

        //We then execute our INSERT statement that we created and flush out above by running
        //the instance method ExecuteNonQuery() off of our cmd object
        cmd.ExecuteNonQuery();

        //Once that is done, we simply close the connection
        connection.Close();

    }

    public void RemoveShowing(Showing newShowing)  //Create method to RemoveShowing
    {
        using SqlConnection connection = new SqlConnection(connectionString);  //create a SqlConnection object

        connection.Open();  //Open the connection

        //Create our command with a templated string 
        string cmdText = @"DELETE FROM SHOWING 
                            WHERE showingName=@showingName"; 

        //We use the connection we created and opened, as well as the command text template we created above
        //to create a new SqlCommand object that where we will send to do things in our SQL database. 
        using SqlCommand cmd = new SqlCommand(cmdText, connection);

        //Now that we have our SqlCommand object, in this case named cmd, we can call a method AddWithValue() and the showing parameters
        //to fill out the templated INSERT command string
        //We call this a little differently than other instance methods, because we are reaching deeper into
        //the cmd object.        
        cmd.Parameters.AddWithValue("@showingName", newShowing.showingName);

        //We then execute our INSERT statement that we created and flush out above by running
        //the instance method ExecuteNonQuery() off of our cmd object
        cmd.ExecuteNonQuery();

        //Close connection
        connection.Close();

    }

}