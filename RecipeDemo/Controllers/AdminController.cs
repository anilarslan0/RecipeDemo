using Microsoft.AspNetCore.Mvc;
using RecipeDemo.Models;
using RecipeDemo.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeDemo.Controllers
{
    public class AdminController : Controller
    {
        AdminRepository adminRepository = new AdminRepository();
        public IActionResult Index()
        {
            return View(adminRepository.TList());
        }
        [HttpGet]
        public IActionResult AdminAdd()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AdminAdd(Admin admin)
        {
            if (!ModelState.IsValid)
            {
                return View("CategoryAdd");
            }
            adminRepository.TAdd(admin);
            return RedirectToAction("Index");
        }


        public IActionResult AdminDelete(int id)
        {
            adminRepository.TDelete(new Admin { AdminId = id });
            return RedirectToAction("Index");
        }


       



    }
}
