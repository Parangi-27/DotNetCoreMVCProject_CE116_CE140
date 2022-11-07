using Microsoft.AspNetCore.Mvc;
using ResManage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;   

namespace ResManage.Controllers
{
    public class FoodController : Controller
    {
        private readonly IFoodRepository _foodRepo;

        public FoodController(IFoodRepository foodRepo)
        {
            _foodRepo = foodRepo;
        }

        public IActionResult Index()
        {
            var model = _foodRepo.GetAllFoods();
            return View(model);
        }

        public ViewResult Details(int id)
        {
            Food food = _foodRepo.GetFood(id);
            if(food == null)
            {
                Response.StatusCode = 404;
                return View("FoodNotFound", id);
            }
            return View(food);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Food food)
        {
            if (ModelState.IsValid)
            {
                Food newfood = _foodRepo.Add(food);
                return RedirectToAction("details", new { id = newfood.Id });
            }
            return View();
        }

        [HttpGet]
        public ViewResult Edit(int id)
        {
            Food food = _foodRepo.GetFood(id);
            return View(food);
        }

        [HttpPost]
        public IActionResult Edit(Food model)
        {
            if (ModelState.IsValid)
            {
                Food food = _foodRepo.GetFood(model.Id);
                food.Name = model.Name;
                food.Price = model.Price;
                Food updatedfood = _foodRepo.Update(food);

                return RedirectToAction("index");

            }
            return View(model);

        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Food food = _foodRepo.GetFood(id);
            if (food == null) {
                return NotFound();
            }
            return View(food);

        }

        [HttpPost,ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var food = _foodRepo.GetFood(id);
            _foodRepo.Delete(food.Id);

            return RedirectToAction("index");
        }




    }
}
