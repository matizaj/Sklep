using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportStore.Models
{
    public  class SeedData
    {
        private AppDbContext context;
        public SeedData(AppDbContext context)
        {
            this.context = context;
        }
        public  void Seed()
        {            
            if (!context.Products.Any())
            {
                context.Products.AddRange(
                    new Product { Name = "Ball", Category = "Soccer", Price = 19M, Description = "For kikking" },
                    new Product { Name = "Kayak", Category = "Watersport", Price = 450M, Description = "Boat for one person" },
                    new Product { Name = "Harness", Category = "Climbing", Price = 75M, Description = "Personal staff for safety" },
                    new Product { Name = "Quickdraws", Category = "Climbing", Price = 125M, Description = "For clipping rope" },
                    new Product { Name = "Helmet", Category = "Climbing", Price = 100M, Description = "Prpotection" },
                    new Product { Name = "Ocun Ozon", Category = "Climbing", Price = 115M, Description = "Shoe" },
                    new Product { Name = "Tendom Rope 9.8mm", Category = "Climbing", Price = 250M, Description = "80m long" },
                    new Product { Name = "Tendom Rope 9.8mm", Category = "Climbing", Price = 250M, Description = "60m long" }
                    );
            }
            context.SaveChanges();
        }
    }
}
