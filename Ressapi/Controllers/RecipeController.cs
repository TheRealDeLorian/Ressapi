using Microsoft.AspNetCore.Mvc;
using Ressapi.Data;

namespace Ressapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    //[HttpGet(Name = "GetRecipes")]
    //[ResponseCache(Location = ResponseCacheLocation.Any, Duration = 60)]


    public class RecipeController : ControllerBase
    {
        private readonly ILogger<RecipeController> _logger;
        private readonly IDataStore dataStore;

        public RecipeController(ILogger<RecipeController> logger, IDataStore dataStore)
        {
           
            _logger = logger;
            this.dataStore = dataStore;
        }

        [HttpGet()]
        public IEnumerable<Recipe> Get()
        {
            return dataStore.GetAllRecipes();
        }

        [HttpGet("{id}")]
        public Recipe Get(int id)
        {
            return dataStore.GetRecipe(id);
        }

        [HttpPost]
        public Recipe Post([FromBody] Recipe recipe)
        {
            var newRecipe = dataStore.AddRecipe(recipe);
            return newRecipe;
        }
    }

   
}
