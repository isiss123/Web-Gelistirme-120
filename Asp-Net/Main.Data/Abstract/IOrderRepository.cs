using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Main.Entity;

namespace Main.Data.Abstract
{
    public interface IOrderRepository : IRepository<Order>
    {
        List<Order> GetOrders(string userId);
    }
}