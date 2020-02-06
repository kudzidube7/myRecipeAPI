using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyRecipeAPI.Models;
using MyRecipeAPI.Database;
namespace MyRecipeAPI.Repositories.Implementations
{
    public class RecipeRepository : IRecipeRepository
    {
        private RecipeDbContext _context;

        public RecipeRepository(RecipeDbContext context)
        {
            _context = context;
        }
      public Recipe FindRecipeById(int id)
        {

            var recipe = _context.Recipes.Find(id);
            return recipe;
        }


     public  IEnumerable<Recipe> GetAllRecipes()
        {
            var recipes = _context.Recipes;
            return recipes;
        }
        public void AddRecipe(Recipe recipeModel)
        {
            _context.Recipes.Add(recipeModel);
            _context.SaveChanges();
        }
        public void UpdateRecipe(Recipe recipeModel)
        {
            _context.Recipes.Update(recipeModel);
            _context.SaveChanges();
        }
        public void DeleteRecipe(Recipe recipeModel)
        {
            _context.Recipes.Remove(recipeModel);
            _context.SaveChanges();
        }
    }
}
