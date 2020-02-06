using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyRecipeAPI.Enums;

namespace MyRecipeAPI.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Ingredients { get; set; }
        public string Method { get; set; }

        public RecipeType recipeType { get; set; }
    }
}
