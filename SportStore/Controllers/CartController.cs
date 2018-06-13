using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportStore.Models;
using SportStore.Models.ViewModels;

namespace SportStore.Controllers
{
    public class CartController:Controller
    {
        private IRepository _productRepo;
        private Cart _cartRepo;
        public CartController(IRepository productRepo, Cart cartRepo)
        {
            _productRepo = productRepo;
            _cartRepo = cartRepo;
        }
        public IActionResult Index(string returnUrl) => View(new CartListViewModel
        {
            Cart=_cartRepo,
            ReturnUrl = returnUrl
        });


        [HttpPost]
        public IActionResult AddToCart(int productId, string returnUrl)
        {
            var product = _productRepo.Products.FirstOrDefault(x => x.ProductID == productId);
            if (product != null)
            {
                _cartRepo.AddItem(product,1);
            }

            return RedirectToAction("Index", new {returnUrl});
        }

        public IActionResult RemoveLine(int productId, string returnUrl)
        {
            var product = _productRepo.Products.FirstOrDefault(x => x.ProductID == productId);
            if (product != null)
            {
                _cartRepo.RemoveLine(product);
            }

            return RedirectToAction("Index", new { returnUrl });
        }

        public IActionResult CartSummaryPartial() => PartialView();
        [HttpPost]
        public IActionResult ClearCart()
        {
            _cartRepo.Clear();
            return RedirectToAction("Index", "Product");

        }
    }

}
