using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyRecipeAPI.Models;
using MyRecipeAPI.Repositories;
using Microsoft.Extensions.Logging;

namespace MyRecipeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        private readonly IRecipeRepository _recipeRepository;
        private readonly ILogger<RecipesController> _logger;

        public RecipesController(IRecipeRepository recipeRepository, ILogger<RecipesController> logger)
        {
            _recipeRepository = recipeRepository;
            _logger = logger;

    }

    [HttpGet(template: "{id}")]
        public ActionResult<Recipe> GetRecipe(int id)
        {
            Recipe recipe;
            try
            {
                recipe = _recipeRepository.FindRecipeById(id);
            }
            catch (Exception ex)
            {
                
                _logger.LogError(ex.Message);
                throw;
            }

            return recipe;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Recipe>> GetAllRecipes()
        {
            IEnumerable<Recipe> recipes;

            try
            {
                recipes = _recipeRepository.GetAllRecipes().ToList();
            }
            catch (Exception e)
            {
                _logger.LogError("Kudzai has logged this error " + e.Message);
                _logger.LogInformation("Kudzai has logged this information " + e.Message);
                _logger.LogWarning("Kudzai has logged this warning " + e.Message);
                throw e;
            }


            return recipes.ToList();
        }

        [HttpPost]
        public ActionResult<Recipe> addRecipe(Recipe recipe)
        {
            try
            {

                _recipeRepository.AddRecipe(recipe);
            }
            catch (Exception)
            {

                throw;
            }
            return recipe;
            
        }

        [HttpPut]
        public ActionResult<Recipe> updateRecipe(Recipe recipe)
        {
            try
            {
                _recipeRepository.UpdateRecipe(recipe);
            }
            catch (Exception)
            {

                throw;
            }
            return recipe;

        }


        [HttpDelete]
        public ActionResult<Recipe> deleteRecipe(Recipe recipe)
        {
            try
            {
                _recipeRepository.DeleteRecipe(recipe);
            }
            catch (Exception)
            {

                throw;
            }
            return recipe;

        }
    }
}