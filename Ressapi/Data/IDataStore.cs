namespace Ressapi.Data
{
    public interface IDataStore
    {
        IEnumerable<Recipe> GetAllRecipes();
        Recipe GetRecipe(int id);
        Recipe AddRecipe(Recipe recipe);
        Recipe UpdateRecipe(Recipe recipe); 
        void DeleteRecipe(int id);
    }

    public class InMemoryDataStore : IDataStore
    {
        private List<Recipe> recipes = new List<Recipe>();

        Recipe GetRecipe(int id)
        {
            return recipes[id];
        }
        Recipe AddRecipe(Recipe recipe)
        {
            recipes.Add(recipe);
            return recipe;
        }

        Recipe DeleteRecipe(int id)
        {
            recipes.Remove();
        }
        Recipe UpdateRecipe(Recipe recipe)
        {

        }
    }



    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Instructions { get; set; }

        public List<Ingredient> Ingredients { get; set; }
    }

    public class Ingredient
    {
        public string Name { get; set; }
        public decimal Quantity { get; set; }
        public string Unit { get; set; }
    }
}
