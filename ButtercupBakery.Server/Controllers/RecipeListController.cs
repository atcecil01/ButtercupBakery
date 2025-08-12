using ButtercupBakery.Server.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ButtercupBakery.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RecipeListController : ControllerBase
    {
        private readonly ILogger<RecipeListController> _logger;

        public RecipeListController(ILogger<RecipeListController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetRecipeList")]
        public IEnumerable<Recipe> Get()
        {
            return RecipeRepository.GetRecipes().ToArray();
        }
    }
}