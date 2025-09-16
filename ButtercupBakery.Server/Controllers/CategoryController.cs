using ButtercupBakery.Server.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ButtercupBakery.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ILogger<RecipeListController> _logger;

        public CategoryController(ILogger<RecipeListController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetCategories")]
        public IEnumerable<Category> Get()
        {
            return CategoryRepository.GetCategories().ToArray();
        }
    }
}