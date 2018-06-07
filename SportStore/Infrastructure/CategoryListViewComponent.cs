using Microsoft.AspNetCore.Mvc;
using SportStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportStore.Infrastructure
{
    public class CategoryListViewComponent:ViewComponent
    {
        private IRepository repository;
        public CategoryListViewComponent(IRepository repo)
        {
            repository = repo;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCat = RouteData.Values["category"];
            //ViewData["SelectedCategory"];
            return View(repository.Products.Select(x => x.Category).Distinct());
        }
    }
}
