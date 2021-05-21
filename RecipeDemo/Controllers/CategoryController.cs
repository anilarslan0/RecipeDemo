using Microsoft.AspNetCore.Mvc;
using RecipeDemo.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecipeDemo.Models;
using Microsoft.AspNetCore.Authorization;
using X.PagedList;

namespace RecipeDemo.Controllers
{
    public class CategoryController : Controller
    {
        CategoryRepository categoryRepository = new CategoryRepository();
       
        public IActionResult Index(int page=1)
        {
            return View(categoryRepository.TList().ToPagedList(page,5));
        }
        
        [HttpGet]
      
        public IActionResult CategoryAdd()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CategoryAdd(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View("CategoryAdd");
            }
            categoryRepository.TAdd(category);
            return RedirectToAction("Index");
        }

        public IActionResult CategoryGet(int id)
        {
            var x = categoryRepository.TGet(id);
            Category category = new Category()
            {
                CategoryName=x.CategoryName,
                CategoryDescription=x.CategoryDescription,
                CategoryImageURL=x.CategoryImageURL,
                CategoryID=x.CategoryID
            };
            return View(category);
        }
        [HttpPost]
        public IActionResult CategoryUpdate(Category category)
        {
            var x = categoryRepository.TGet(category.CategoryID);
            x.CategoryName = category.CategoryName;
            x.CategoryDescription = category.CategoryDescription;
            x.CategoryImageURL = category.CategoryImageURL;
            x.Status = true;
            categoryRepository.TUpdate(x);
            return RedirectToAction("Index");
        }

        public IActionResult CategoryDelete(int id)
        {
            var x = categoryRepository.TGet(id);
            x.Status = false;
            categoryRepository.TUpdate(x);
            return RedirectToAction("Index");
        }
    }
}
