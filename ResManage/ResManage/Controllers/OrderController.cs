using Microsoft.AspNetCore.Mvc;
using ResManage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;   

namespace ResManage.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepo;

        public OrderController(IOrderRepository OrderRepo)
        {
            _orderRepo = OrderRepo;
        }

        public IActionResult Index()
        {
            var model = _orderRepo.GetAllOrders();
            return View(model);
        }

        public ViewResult Details(int id)
        {
            Order order = _orderRepo.GetOrder(id);
            if(order == null)
            {
                Response.StatusCode = 404;
                return View("OrderNotFound", id);
            }
            return View(order);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Order Orders)
        {
            if (ModelState.IsValid)
            {
                Order newOrder = _orderRepo.Add(Orders);
                return RedirectToAction("details", new { id = newOrder.Id });
            }
            return View();
        }

        [HttpGet]
        public ViewResult Edit(int id)
        {
            Order order = _orderRepo.GetOrder(id);
            return View(order);
        }

        [HttpPost]
        public IActionResult Edit(Order model)
        {
            if (ModelState.IsValid)
            {
                Order Orders = _orderRepo.GetOrder(model.Id);
                Orders.foodname = model.foodname;
                Orders.quantity = model.quantity;
                Orders.Date = model.Date;
                Order updatedOrder = _orderRepo.Update(Orders);

                return RedirectToAction("index");

            }
            return View(model);

        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Order order = _orderRepo.GetOrder(id);
            if (order == null) {
                return NotFound();
            }
            return View(order);

        }

        [HttpPost,ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var order = _orderRepo.GetOrder(id);
            _orderRepo.Delete(order.Id);

            return RedirectToAction("index");
        }




    }
}
