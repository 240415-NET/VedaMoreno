using System.Xml.XPath;
using Microsoft.Data.SqlClient;

namespace ADOExample;

class Program
{
    static void Main(string[] args)
    {
        string connectionString = "Data Source=GEIPW0785VB;Initial Catalog=ADOExampleDB;Integrated Security=False;User Id=sa;Password=bluesky;MultipleActiveResultSets=True;TrustServerCertificate=True;";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            bool entry = true;
            int UserId = 1;
            connection.Open();
            do
            {
                //Creating an entry into my table
                //My table is called UsersExample
                //The table has 5 fields
                //UserId - INT - int
                //LastName -VARCHAR - string
                //FirstName -VARCHAR - string
                //Userame -VARCHAR - string
                //Password -VARCHAR - string


                string LastName = "Carlton";
                string FirstName = "Katherine";
                string Username = "user" + UserId.ToString();
                string Password = "pass" + UserId.ToString();


                string query = "INSERT INTO UsersExample(UserId, LastName, FirstName, Username, Password) VALUES (@val1, @val2, @val3, @val4, @val5)";

                using SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@val1", UserId);
                command.Parameters.AddWithValue("@val2", LastName);
                command.Parameters.AddWithValue("@val3", FirstName);
                command.Parameters.AddWithValue("@val4", Username);
                command.Parameters.AddWithValue("@val5", Password);



                int result = command.ExecuteNonQuery();

                if (result > 0)
                {
                    Console.WriteLine("User Created Successfully");

                }

                if (UserId < 100)

                {
                    UserId++;

                }
                else
                {

                    entry = false;
                }


            } while (entry == true);

            connection.Close();
        }

    }
}
// PF3BP04L;Database=ADOExampleDb;Trusted_Connection=True;TrustServerCertificate=True; 
//Brian's example above.