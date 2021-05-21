using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RecipeDemo.Models;
using RecipeDemo.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeDemo.Controllers
{
    public class RecipeController : Controller
    { Context context = new Context();
        RecipeRepository recipeRepository = new RecipeRepository();

        public IActionResult Index()
        {
            return View(recipeRepository.TList("Category"));
        }
        [HttpGet]
        public IActionResult AddRecipe()
        {
            List<SelectListItem> values = (from x in context.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryID.ToString()
                                           }).ToList();
            ViewBag.value = values;
            return View();
        }
        [HttpPost]
        public IActionResult AddRecipe(Recipe recipe)
        {
            recipeRepository.TAdd(recipe);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteRecipe(int id)
        {
            recipeRepository.TDelete(new Recipe { RecipeId=id});
            return RedirectToAction("Index");
        }

        public IActionResult RecipeGet(int id)
        {
            var x = recipeRepository.TGet(id);

            List<SelectListItem> values = (from y in context.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = y.CategoryName,
                                               Value = y.CategoryID.ToString()
                                           }).ToList();
            ViewBag.valueUpdate = values;

            Recipe recipe = new Recipe()
            {
                RecipeId=x.RecipeId,
                CategoryId = x.CategoryId,
                Title = x.Title,
                Description = x.Description,
                ImageURL = x.ImageURL

            };
            return View(recipe);
        }

        [HttpPost]
        public IActionResult RecipeUpdate(Recipe recipe)
        {
            var x = recipeRepository.TGet(recipe.RecipeId);
            x.Title = recipe.Title;
            x.Description = recipe.Description;
            x.ImageURL = recipe.ImageURL;
            x.CategoryId = recipe.CategoryId;
            recipeRepository.TUpdate(x);
            return RedirectToAction("Index");
        }

    }
}
