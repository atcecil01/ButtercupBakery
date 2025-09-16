namespace ButtercupBakery.Server
{
    public class Recipe
    {
        public int Id { get; set; }
        public string RecipeName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int CategoryId { get; set; } //Foreign key to Category
        public int? PreparationTime { get; set; } // in minutes

        public List<string> Ingredients { get; set; } = new List<string>();
        public List<string> Instructions { get; set; } = new List<string>();
    }
}
