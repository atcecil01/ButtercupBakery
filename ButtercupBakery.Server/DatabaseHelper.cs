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
            string createInstructionTableQuery = @"
                CREATE TABLE IF NOT EXISTS Instruction (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name TEXT NOT NULL,
                    SortOrder INTEGER NOT NULL,
                    RecipeId INTEGER NOT NULL,
                    FOREIGN KEY (RecipeId) REFERENCES Recipe(Id)
                );
            ";

            string createVersionTableQuery = @"
                CREATE TABLE IF NOT EXISTS Version (
                      [Id] INT NOT NULL PRIMARY KEY DEFAULT AUTO_INCREMENT
                    , [Version] NUMERIC NOT NULL
                    , [DATE] DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP
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

                command.CommandText = createInstructionTableQuery;
                command.ExecuteNonQuery();

                command.CommandText = createVersionTableQuery;
                command.ExecuteNonQuery();

                Console.WriteLine("Database initialized successfully.");
            }
        }
    }

    public static void UpdateDatabase()
    {
        string updatePath = @"Files\DatabaseUpdateScripts\";

        string[] files = Directory.GetFiles(updatePath, "*.sql");
        if (files.Length == 0)
        {
            Console.WriteLine("No update scripts found.");
            return;
        }

        using (var connection = GetConnection())
        {
            connection.Open();
            int? versionNumber;
            using (var command = new SQLiteCommand(connection))
            {
                command.CommandText = "SELECT [Version] FROM [Version] ORDER BY [Version] DESC LIMIT 1";
                versionNumber = (int?)command.ExecuteScalar();
            }

            if (versionNumber == null)
            {
                versionNumber = 0;
            }

            files = files.Where(f => int.Parse(Path.GetFileNameWithoutExtension(f)) > versionNumber).OrderBy(f => f).ToArray();
            if (files.Length == 0)
            {
                Console.WriteLine("No new update scripts to apply.");
                return;
            }

            foreach (var file in files)
            {
                string script = File.ReadAllText(file);
                using (var command = new SQLiteCommand(script, connection))
                {
                    command.ExecuteNonQuery();
                }
                Console.WriteLine($"Executed update script: {Path.GetFileName(file)}");
            }
        }
    }
}
