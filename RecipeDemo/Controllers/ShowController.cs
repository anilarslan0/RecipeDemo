using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RecipeDemo.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeDemo.Controllers
{
    public class ShowController : Controller
    {
        CategoryRepository categoryRepository = new CategoryRepository();
        RecipeRepository recipeRepository = new RecipeRepository();

        [AllowAnonymous]
        public IActionResult Index(string category)
        {
            if (!string.IsNullOrEmpty(category))
            {
                return View(categoryRepository.List(x => x.CategoryName.Contains(category)));
            }
            return View(categoryRepository.TList());
        }
        [AllowAnonymous]
        public IActionResult CategoryDetails(int id)
        {
           
            var recipeList = recipeRepository.List(x => x.CategoryId == id);
            return View(recipeList);
        }
        [AllowAnonymous]
        public IActionResult RecipeDetails(int id)
        {
            var detail = recipeRepository.List(x=>x.RecipeId==id);
            return View(detail);
        }

    }
}
