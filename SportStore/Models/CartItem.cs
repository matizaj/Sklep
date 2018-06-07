using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportStore.Models.ViewModels
{
    public class CartItem
    {
        public int ID { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
