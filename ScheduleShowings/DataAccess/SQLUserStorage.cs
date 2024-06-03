using ScheduleShowings.Models;
using System.Data.SqlClient;
namespace ScheduleShowings.Data;

public class SQLUserStorage  //This class holds the functionality for finding, storing, and connecting to a SQL database for accessing, storing and extracting User data  
{

     public static string connectionString = File.ReadAllText(@"C:\Users\A221249\Desktop\Desktop\Projects\Team Rocket-Commercial\Claims-API-Desktop\Engineer Bootcamp\Git Hub\ConnectionString.txt");
        //connection string for connecting to SQL DB and sending, receiving and storing data to/from and in SQL DB
     public User FindUser(string userName)  //method for finding an existing User w/one parameter. 
     {
             
        //User we find in our DB and create and assign it foundUser object
        User foundUser = new User();

        //Create a SqlConnection object w/one parameter and assigning it connection
        //we want this object to be "disposable" - that is to say, we want it to be destroyed or dereferenced
        //as soon as this method is done executing. We do this with a "using" statement.  
        using SqlConnection connection = new SqlConnection(connectionString);

        try
        {
            //After we create our connection object, we call an instance method called Open() to open the connection
            connection.Open();

            //We start creating our command/Query text from SQL DB/Query
            string cmdText = @"SELECT userId, userName 
                                FROM dbo.USERS
                                WHERE userName=@userToFind;";
                               
           //We use the connection we created and opened, as well as the command text template we created above
            //to create a new SqlCommand object w/2 parameters and assign it cmd 
            using SqlCommand cmd = new SqlCommand(cmdText, connection);

            //We then fill in the parameter @userToFind with our string usernameToFind that comes in
            //as an argument to our method
            cmd.Parameters.AddWithValue("@userToFind", userName);

            //To execute a query, we need to use a SqlDataReader object.
            //This object reads whatever is returned from our query, row by row - column by column
            //As the reader passes over the columns and rows we need to take steps to store or work with 
            //the data that comes back - Once the reader moves on from a row, we would need to execute the 
            //command again to re-read the row.
            //It is forward only! No going back up to another row we have already passed.
            using SqlDataReader reader = cmd.ExecuteReader(); //calls reader method and creates/assigns reader 
            
            //We are going to use a while-loop to read through our data coming back from our SqlDataReader
            //and execute code until it is done reading
            while(reader.Read())
            {
                //While we are on a particular row, we have to save data if we find it.
                //When using reader.GetType() methods, we have to specify which column we are targeting
                //Like arrays, these start at position 0
                foundUser.userId = reader.GetGuid(0); //reading the GUID and assigning it userId
                foundUser.userName = reader.GetString(1);  //reading the String and assigning it UserName
            }//Once we are done reading, and no more records are coming back to be read, we exit the while-loop
            
            //Close our connection
            connection.Close();

            //If we get to this point and found a user, we return the filled out user object

            //If the username on foundUser is empty, we manually return a null. 
            //if(String.IsNullOrEmpty(foundUser.userName))
            if (foundUser.userId == Guid.Empty)
            {
                return null;
            }

            //Otherwise we return the foundUser filled out user object
            return foundUser;

        }catch(Exception e)   //Created the catching exception, The catch block takes a parameter of an exception type 
        {
            Console.WriteLine(e.Message);    //output to User providing them the exception message
        }finally //We will leverage the finally block to close our connection incase 
        {        //either nothing is found OR we actually catch some Exception
            
            connection.Close();  //Close our connection if we find nothing or something bad happens
        }

        
        return null;

     }
     public void StoreUser(User user)  //method for storing an existing User w/one parameter.  
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
        string cmdText = @"INSERT INTO dbo.USERS (userId, userName)
                            VALUES (@userId, @userName);";

        //We use the connection we created and opened, as well as the command text template we created above
        //to create a new SqlCommand object that we will eventually send to do stuff on our database. 
        using SqlCommand cmd= new SqlCommand(cmdText, connection);

        //Now that we have our SqlCommand object, in this case named cmd, we can call a method AddWithValue()
        //to fill out the templated INSERT command string
        //We call this a little differently than other instance methods, because we are reaching deeper into
        //the cmd object. 
        cmd.Parameters.AddWithValue("@userId", user.userId);
        cmd.Parameters.AddWithValue("@userName", user.userName);

        //We then execute our INSERT statement that we created and flushed out above by running
        //the instance method ExecuteNonQuery() off of our cmd object
        cmd.ExecuteNonQuery();

        //Once complete, we close the connection
        connection.Close();

    }
     
}