namespace ButtercupBakery.Server
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Quantity { get; set; } = string.Empty;
        public string Unit { get; set; } = string.Empty;
        public int SortOrder { get; set; }
        public int RecipeId { get; set; } // Foreign key to Recipe
    }
}
