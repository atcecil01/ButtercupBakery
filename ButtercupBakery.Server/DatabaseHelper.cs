using System.Data.SQLite;
using System.IO;

public static class DatabaseHelper
{
    private const string DbPath = @"Files\ButtercupBakery.db";

    public static SQLiteConnection GetConnection()
    {
        if (!File.Exists(DbPath))
        {
            throw new FileNotFoundException("Database file not found.", DbPath);
        }
        return new SQLiteConnection($"Data Source={DbPath};Version=3;");
    }

    public static void InitializeDatabase()
    {

        if (File.Exists(DbPath))
        {
            // If the database file already exists, skip creating it.
            Console.WriteLine("Database file already exists. Skipping creation.");
            return;
        }

        SQLiteConnection.CreateFile(DbPath);

        using (var connection = GetConnection())
        {
            connection.Open();

            string createCategoryTableQuery = @"
                CREATE TABLE IF NOT EXISTS Category (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name TEXT NOT NULL
                );
            ";
            string createRecipeTableQuery = @"
                CREATE TABLE IF NOT EXISTS Recipe (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name TEXT NOT NULL,
                    Description TEXT NOT NULL,
                    CategoryId Integer NOT NULL,
                    PreparationTime INTEGER NULL,
                    FOREIGN KEY (CategoryId) REFERENCES Category(Id)
                );
            ";
            string createIngredientTableQuery = @"
                CREATE TABLE IF NOT EXISTS Ingredient (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name TEXT NOT NULL,
                    Quantity TEXT NOT NULL,
                    Unit TEXT NOT NULL,
                    SortOrder INTEGER NOT NULL,
                    RecipeId INTEGER NOT NULL,
                    FOREIGN KEY (RecipeId) REFERENCES Recipe(Id)
                );
            ";
            string createInsructionTableQuery = @"
                CREATE TABLE IF NOT EXISTS Insruction (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name TEXT NOT NULL,
                    SortOrder INTEGER NOT NULL,
                    RecipeId INTEGER NOT NULL,
                    FOREIGN KEY (RecipeId) REFERENCES Recipe(Id)
                );
            ";

            using (var command = new SQLiteCommand(connection))
            {
                command.CommandText = createCategoryTableQuery;
                command.ExecuteNonQuery();

                command.CommandText = createRecipeTableQuery;
                command.ExecuteNonQuery();

                command.CommandText = createIngredientTableQuery;
                command.ExecuteNonQuery();

                command.CommandText = createInsructionTableQuery;
                command.ExecuteNonQuery();

                Console.WriteLine("Database initialized successfully.");
            }
        }
    }
}
