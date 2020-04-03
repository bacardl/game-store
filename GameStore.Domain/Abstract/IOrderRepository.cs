using GameStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Domain.Abstract
{
    public interface IOrderRepository
    {
        IEnumerable<Order> Orders { get; }
        Order FindOrder(int orderId);
        void CreateOrder(Order order);
        void SaveOrder(Order order);
        void DeleteOrder(Order order);
    }
}
