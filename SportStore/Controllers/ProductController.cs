﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SportStore.Models;
using SportStore.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportStore.Controllers
{
    public class ProductController:Controller
    {
        private int pageSize = 3;
        private IRepository repository;
        private UserManager<IdentityUser> _userManager;
        public ProductController(IRepository repo, UserManager<IdentityUser> userManager)
        {
            repository = repo;
            _userManager = userManager;
        }
       
        public async Task<ViewResult> Index(string category, int page=1)
        {
            await SeedUsers.Seed(_userManager);

            var products = repository.Products;
            if (!string.IsNullOrEmpty(category))
            {
               products = products.Where(p => p.Category == category);
            }

            var totalItems = products.Count();

            products = products.Skip((page - 1) * pageSize).Take(pageSize);

            var productList = new ProductListViewModel()
            {
                Products = products,
                PageInfo = new PageInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = totalItems
                }
            };
            ViewBag.SelectedCat = category;
            return View(productList);
        }
        public ViewResult Edit(int productId)
        {
            Product editProduct = repository.Products.FirstOrDefault(e => e.ProductID == productId);
            return View("Edit",editProduct);
        }
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                repository.SaveProduct(product);
                return RedirectToAction("Index");
            }
            else
            {
                return View(product);
            }
        }
        public ViewResult Create() => View("Edit");

        [HttpPost]
        public IActionResult Delete(int productId)
        {
            Product deletedProduct = repository.DeleteProduct(productId);
            if (deletedProduct != null)
            {
                TempData["message"] = $"{deletedProduct.Name} został usuniety";
            }
            return RedirectToAction("Index");
        }

    }
}
