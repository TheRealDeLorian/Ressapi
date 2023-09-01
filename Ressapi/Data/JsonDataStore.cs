using System.Text.Json;

namespace Ressapi.Data;

public class JsonDataStore : IDataStore
{
    List<Recipe> recipes;
    string recipesPath = "recipes.json";
    public JsonDataStore()
    {
        recipes = new List<Recipe>();
        if(File.Exists(recipesPath))
        {
            var json = File.ReadAllText(recipesPath);
            recipes = JsonSerializer.Deserialize<List<Recipe>>(json);
        }
    }

    public async Task<Recipe> AddRecipe(Recipe recipe)
    {
        if(recipes.Count == 0)
        {
            recipe.Id = 1;
        }
        else
        {
            recipe.Id = recipes.Max(r => r.Id) + 1;
        }
        recipes.Add(recipe);

        await saveRecipes();
        return recipe;
    }

    private async Task saveRecipes()
    {
        var json = JsonSerializer.Serialize(recipes);
        await File.WriteAllTextAsync(recipesPath, json);
    }

    public Task DeleteRecipe(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Recipe>> GetAllRecipes()
    {
        throw new NotImplementedException();
    }

    public Task<Recipe> GetRecipe(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Recipe> UpdateRecipe(Recipe recipe)
    {
        throw new NotImplementedException();
    }
}
