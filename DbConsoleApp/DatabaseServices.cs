using Microsoft.Data.Sqlite;

namespace DbConsoleApp;

public class DbMethods
{
    public static string DbPath { get; set; } 
    public static void ShowData()
    {
        DbPath = "../../../words.db";
        string SQLiteDatabaseConnectionString = $"Data Source={DbPath};";

        using (SqliteConnection connection = new SqliteConnection(SQLiteDatabaseConnectionString))
        {
            connection.Open();

            string query = "SELECT * FROM wordPairs";
            
            // Create a command object, with a query, and connection. 
            using (SqliteCommand command = new SqliteCommand(query, connection))
            {
                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string col1Value = reader.GetString(0);
                        string col2Value = reader.GetString(1);
                        
                        Console.WriteLine($"Russian: {col1Value}, English: {col2Value}");
                    }
                }
            }
        }
    }
}