using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Main.Data.Abstract;
using Main.Entity;
using Microsoft.EntityFrameworkCore;

namespace Main.Data.Concrete.EfCore
{
    public class EfCoreOrderRepository : EfCoreGenericRepository<Order>, IOrderRepository
    {
        public EfCoreOrderRepository(MainContext _db) : base(_db)
        {
            
        }
        public MainContext _db {
            get{return db as MainContext;}
        }
        public List<Order> GetOrders(string userId)
        {
                var orders = _db.Orders
                                    .Include(i=>i.OrderDetails)
                                    .ThenInclude(i=>i.Product)
                                    .AsQueryable();
                if(!string.IsNullOrEmpty(userId))
                {
                    orders = orders.Where(i=>i.UserId == userId);
                }
                return orders.ToList();
        }
    }
}