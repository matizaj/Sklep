using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SportStore.Infrastructure.Extensions;
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
        private SeedData seedData;
        public ProductController(IRepository repo, SeedData seed)
        {
            repository = repo;
            seedData = seed;
        }
       
        public async Task<ViewResult> Index(string category, int page=1)
        {
            
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
            ViewBag.ReturnUrl = Request.PathAndQuery();
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
        public ViewResult Create() => View("Edit", new Product());//trzeba podac model new Product() bo inaczej model jest nullem

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
        [HttpPost]
        [Authorize]
        public IActionResult SeedData()
        {
            seedData.Seed();
            return RedirectToAction(nameof(Index));
        }

        [Authorize]
        public IActionResult Save(Product product)
        {
            if (ModelState.IsValid)
            {
                repository.SaveProduct(product);
                return RedirectToAction("Index");
            }
            return View(product);
        }

    }
}
