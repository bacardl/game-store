using GameStore.Domain.Abstract;
using GameStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Domain.Concrete
{
    public class EFOrderRepository : IOrderRepository
    {
        EFDbContext context = new EFDbContext();

        public IEnumerable<Order> Orders
        {
            get { return context.Orders; }
        }

        public void CreateOrder(Order order)
        {
            context.Orders.Add(order);
            context.SaveChanges();
        }

        public void DeleteOrder(Order order)
        {
            context.Orders.Remove(order);
            context.SaveChanges();
        }

        public Order FindOrder(int orderId)
        {
            var order = context.Orders.Find(orderId);
            context.Entry(order).Collection(o => o.OrderItems).Load();
            return order;
        }

        public void SaveOrder(Order order)
        {
            context.Entry(order).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
