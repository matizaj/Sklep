using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using SportStore.Infrastructure.Extensions;
using SportStore.Models.ViewModels;

namespace SportStore.Models
{
    public class CartRepository:Cart
    {
        //private List<CartItem> _items=new List<CartItem>();
        //pobieranie do sesji+
        [JsonIgnore]
        public ISession Session;
        public static Cart GetCart(IServiceProvider serviceProvider)
        {
            var session = serviceProvider.GetRequiredService<IHttpContextAccessor>().HttpContext.Session;
            CartRepository cart = session.Get<CartRepository>("Cart") ?? new CartRepository();
            cart.Session = session;
            return cart;
        }

       public override void AddItem(Product product, int quantity)
        {
            base.AddItem(product,quantity);
            Session.Set("Cart", this);
        }

        public override void RemoveLine(Product product)
        {
            base.RemoveLine(product);
            Session.Set("Cart", this);
        }
    }
}
