using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SportStore.Models.ViewModels;

namespace SportStore.Models
{
    public class CartRepository
    {
        private List<CartItem> _items=new List<CartItem>();

        public IEnumerable<CartItem> Items => _items;


        public void AddItem(Product product, int quantity)
        {
            var item = _items.FirstOrDefault(x => x.Product.ProductID == product.ProductID);
            if (item != null)
            {
                item.Quantity += quantity;
            }
            else
            {
                _items.Add(new CartItem{ID = product.ProductID, Product = product,Quantity = quantity});
                
            }
        }
    }
}
