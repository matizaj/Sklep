using Microsoft.AspNetCore.Mvc;
using SportStore.Models;
using SportStore.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace SportStore.Controllers
{
    public class ProductController:Controller
    {
        private int pageSize = 3;
        private IRepository repository;
        public ProductController(IRepository repo)
        {
            repository = repo;
        }
       
        public ViewResult Index(string category, int page=1)
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

            return View(productList);
        }

    }
}
