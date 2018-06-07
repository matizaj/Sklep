using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportStore.Models;

namespace SportStore.Controllers
{
    public class CartController:Controller
    {
        private IRepository _productRepo;
        private CartRepository _cartRepo;
        public CartController(IRepository productRepo, CartRepository cartRepo)
        {
            _productRepo = productRepo;
            _cartRepo = cartRepo;
        }
        public ViewResult Index() => View(_cartRepo.Items);

        [HttpPost]
        public IActionResult AddToCart(int productId)
        {
            var product = _productRepo.Products.FirstOrDefault(x => x.ProductID == productId);
            if (product != null)
            {
                _cartRepo.AddItem(product,1);
            }

            return RedirectToAction("Index");
        }
    }
}
