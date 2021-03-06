﻿using Microsoft.AspNetCore.Mvc;
using SportStore.Models;
using SportStore.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportStore.Infrastructure
{
    public class CartListViewComponent : ViewComponent
    {
        private Cart cart;
        public CartListViewComponent(Cart cart)
        {
            this.cart = cart;
        }

        public IViewComponentResult Invoke(string returnUrl)
        { 
           return View(new CartListViewModel{Cart=cart, ReturnUrl = returnUrl });
        }
    }
}
