using Microsoft.AspNetCore.Identity;
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

    }
}
