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
        public async Task<IEnumerable<Recipe>> Get()
        {
            return await dataStore.GetAllRecipes();
        }

        [HttpGet("{id}")]
        public Task<Recipe> Get(int id)
        {
            return dataStore.GetRecipe(id);
        }

        [HttpPost]
        public async Task<Recipe> Post([FromBody] Recipe recipe)
        {
            var newRecipe = await dataStore.AddRecipe(recipe);
            return newRecipe;
        }
    }

   
}
