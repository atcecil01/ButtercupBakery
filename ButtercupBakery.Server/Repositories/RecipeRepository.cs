using System.Data.SQLite;

namespace ButtercupBakery.Server.Repositories
{
    public static class RecipeRepository
    {
        public static List<Recipe> GetRecipes(string SearchString = null, int? CategoryID = null)
        {
            List<Recipe> recipes = new List<Recipe>();
            using (var connection = DatabaseHelper.GetConnection())
            using (var command = new SQLiteCommand(connection))
            {
                connection.Open();
                command.CommandText = "SELECT * FROM Recipe WHERE (@name is null OR @name = Name) AND (@categoryID is null OR @categoryID = CategoryId)";
                command.Parameters.AddWithValue("@name", SearchString);
                command.Parameters.AddWithValue("@categoryID", CategoryID);
                SQLiteDataReader? reader = command.ExecuteReader();
                while (reader.Read())
                {
                    recipes.Add(new Recipe()
                    {
                        Id = reader.GetInt32(0),
                        RecipeName = reader.GetString(1),
                        Description = reader.GetString(2),
                        CategoryId = reader.GetInt32(3),
                        PreparationTime = reader.GetInt32(4)
                    });
                } 
            }
            return recipes;
        }
    }
}
