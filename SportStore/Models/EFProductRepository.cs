using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportStore.Models
{
    public class EFProductRepository : IRepository
    {
        private AppDbContext context;
        public EFProductRepository(AppDbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Product> Products => context.Products;

        public void SaveProduct(Product product)
        {
            if (product.ProductID == 0)
            {
                context.Products.Add(product);
            }
            else
            {
                Product Entry = context.Products
                .FirstOrDefault(p => p.ProductID == product.ProductID);
                if (Entry != null)
                {
                    Entry.Name = product.Name;
                    Entry.Description = product.Description;
                    Entry.Price = product.Price;
                    Entry.Category = product.Category;
                }
            }
            context.SaveChanges();
        }
        public Product DeleteProduct(int productID)
        {
            Product Entry = context.Products
            .FirstOrDefault(p => p.ProductID == productID);
            if (Entry != null)
            {
                context.Products.Remove(Entry);
                context.SaveChanges();
            }
            return Entry;
        }
    }
}
