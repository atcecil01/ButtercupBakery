using System.Data.SQLite;

namespace ButtercupBakery.Server.Repositories
{
    public static class CategoryRepository
    {
        public static List<Category> GetCategories()
        {
            List<Category> categories = new List<Category>();
            using (var connection = DatabaseHelper.GetConnection())
            using (var command = new SQLiteCommand(connection))
            {
                connection.Open();
                command.CommandText = "SELECT * FROM Category ORDER BY Name DESC";
                SQLiteDataReader? reader = command.ExecuteReader();
                while (reader.Read())
                {
                    categories.Add(new Category()
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1)
                    });
                }
            }
            return categories;
        }
    }
}