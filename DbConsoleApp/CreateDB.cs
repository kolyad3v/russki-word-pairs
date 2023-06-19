namespace DbConsoleApp;
using Microsoft.Data.Sqlite;

public class CreateDB
{

    public string? DbPath { get; set; }

    public void CreateNewDb(string? dbname)
    {
        
        // Set the path and name of your SQLite database file
        if (dbname != null)
        {
            DbPath = $"../../../{dbname}";
        }
        else
        {
            DbPath = "../../../words2.db";
        }
    
        string fullPath = Path.GetFullPath(DbPath);
        Console.WriteLine("Database file path: " + fullPath);

        // Create a new SQLite connection
        using (var connection = new SqliteConnection($"Data Source={DbPath}"))
        {
            // Open the connection
            connection.Open();

            // Create a new table
            var createTableCommand = connection.CreateCommand();
            createTableCommand.CommandText = @"
            CREATE TABLE IF NOT EXISTS MyTable (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Name TEXT NOT NULL
            );";
            createTableCommand.ExecuteNonQuery();

            // Insert data into the table
            var insertCommand = connection.CreateCommand();
            insertCommand.CommandText = "INSERT INTO MyTable (Name) VALUES ('Nick')";
            insertCommand.ExecuteNonQuery();

            // Close the connection
            connection.Close();
        }

        Console.WriteLine("SQLite database created successfully.");

    }
}