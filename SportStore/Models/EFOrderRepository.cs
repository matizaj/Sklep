using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportStore.Models
{
    public class EFOrderRepository:IOrderRepository
    {
        private AppDbContext context;

        public EFOrderRepository(AppDbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Order> Orders => context.Orders.Include(x => x.Lines).ThenInclude(l => l.Product);

        public void SaveOrder(Order order)
        {
            //TODO:
            context.AttachRange(order.Lines.Select(o=>o.Product));
            if (order.OrderID == 0)
            {
                context.Orders.Add(order);
            }

            context.SaveChanges();
        }
    }
}
