using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResManage.Controllers
{
    public class HomeController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public RedirectToActionResult IndexFood()
        {
            return RedirectToAction("index", "Food");
        }
        public RedirectToActionResult IndexOrder()
        {
            return RedirectToAction("index", "Order");
        }
        public RedirectToActionResult IndexLogout()
        {
            return RedirectToAction("index", "Home");
        }
    }
}
