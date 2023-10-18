using System;
using System.Data.SqlClient;
using Newtonsoft.Json;

class Program
{
    static void Main()
    {
        string userInput = GetUserInput(); // User-provided input (e.g., from a form or query parameter)
        string query = "SELECT * FROM Users WHERE Username = '" + userInput + "';"; // Use a parameterized query

        // Define the connection string
        string connectionString = "Server=your-server;Database=your-database;User Id=your-username;Password=your-password;";

        // Create a SQL connection
        using (SqlConnection sqlConnection = new SqlConnection(connectionString))
        {
            sqlConnection.Open(); // Open the connection

            // Create a SQL command
            using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
            {
                // Execute the query
                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Process query results here
                    }
                }
            }

            // Close the connection when done
            sqlConnection.Close();
        }

        string maliciousJson = "{\"$type\":\"System.Windows.Forms.MessageBox, System.Windows.Forms\",\"text\":\"Hello\",\"caption\":\"Message\",\"buttons\":\"0\",\"icon\":\"0\"}";
        JsonConvert.DeserializeObject<object>(maliciousJson); // Deserialize the malicious JSON
    }

    static string GetUserInput()
    {
        Console.Write("Enter a username: ");
        return Console.ReadLine();
    }
}
