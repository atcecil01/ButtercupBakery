using Microsoft.AspNetCore.Mvc;

namespace ButtercupBakery.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RecipeController : ControllerBase
    {
        private readonly ILogger<RecipeController> _logger;

        public RecipeController(ILogger<RecipeController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetRecipes")]
        public IEnumerable<Recipe> Get()
        {
            //TODO: This method should retrieve recipes from a database or other data source.
            return new List<Recipe>
            {
                new Recipe { Id = 1, Name = "Chocolate Cake", Description = "A rich chocolate cake.", CategoryId = 1, PreparationTime = 60 },
                new Recipe { Id = 2, Name = "Caesar Salad", Description = "A classic Caesar salad.", CategoryId = 2, PreparationTime = 15 }
            };
        }

        [HttpPost(Name = "CreateRecipe")]
        public IActionResult Post([FromBody] Recipe recipe)
        {
            if (recipe == null)
            {
                return BadRequest();
            }

            //TODO: This method should save the new recipe to a database or other data source.

            return CreatedAtAction(nameof(Get), new { id = recipe.Id }, recipe);
        }
    }
}