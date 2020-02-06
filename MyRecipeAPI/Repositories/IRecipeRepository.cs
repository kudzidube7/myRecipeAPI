using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyRecipeAPI.Models;

namespace MyRecipeAPI.Repositories
{
   public interface IRecipeRepository
    {
        Recipe FindRecipeById(int id);
        IEnumerable<Recipe> GetAllRecipes();
        void AddRecipe(Recipe recipeModel);
        void UpdateRecipe(Recipe recipeModel);
        void DeleteRecipe(Recipe recipeModel);
    }
}
