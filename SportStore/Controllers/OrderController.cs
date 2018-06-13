using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using SportStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportStore.Controllers
{
    public class OrderController:Controller
    {
        private IOrderRepository repository;
        private Cart cart;
        public OrderController(IOrderRepository repo, Cart cart)
        {
            repository = repo;
            this.cart = cart;
        }

        public ViewResult Thanks() => View();
        public ViewResult Index() => View(new Order());
        [HttpPost]
        public IActionResult Index(Order order)
        {
            if (!cart.Items.Any())
            {
                ModelState.AddModelError("", "Koszyk nie może być pusty");
            }

            if (ModelState.IsValid)
            {
                order.Lines = cart.Items.ToArray();
                repository.SaveOrder(order);
                cart.Clear();
                return RedirectToAction(nameof(Thanks));
            }
            return View(order);
        }
        [Authorize]
        public ViewResult List()
        {
            var ordersList=repository.Orders;
            return View(ordersList);
        }

        //public ViewResult ListShipped() => View(repository.Orders.Where(o => !o.Shipped));
        //public IActionResult MarkShipped() => View();
    }
}
