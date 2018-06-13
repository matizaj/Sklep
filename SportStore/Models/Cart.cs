using SportStore.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportStore.Models
{
    public class Cart
    {
        private List<CartItem> _items=new List<CartItem>();
        public IEnumerable<CartItem> Items => _items;
        
        public virtual void AddItem(Product product, int quantity)
        {
            //var items = Items.ToList();
            var item = _items.FirstOrDefault(x => x.Product.ProductID == product.ProductID);

            if (item != null)
            {
                item.Quantity += quantity;
            }
            else
            {
                _items.Add(new CartItem { Product = product, Quantity = quantity });
            }
        }

        public virtual decimal CalculateTotalValue()
        {
            var result = _items.Sum(e => e.Product.Price * e.Quantity);
            return result;
        }
        public virtual void RemoveLine(Product product) =>
            _items.RemoveAll(l => l.Product.ProductID == product.ProductID);

        public virtual void Clear() =>_items.Clear();
    }
}
