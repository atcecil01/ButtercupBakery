namespace ButtercupBakery.Server
{
    public class Instruction
    {
        public int Id { get; set; }
        public string Step { get; set; } = string.Empty;
        public int SortOrder { get; set; }
        public int RecipeId { get; set; } // Foreign key to Recipe
    }
}
