using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportStore.Models.ViewModels
{
    public class CartListViewModel
    {
        public IEnumerable<CartItem> Items { get; set; }
        public string ReturnUrl { get; set; }
    }
}
