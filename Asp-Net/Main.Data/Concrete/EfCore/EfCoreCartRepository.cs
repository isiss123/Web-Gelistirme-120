using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Main.Data.Abstract;
using Main.Entity;
using Microsoft.EntityFrameworkCore;

namespace Main.Data.Concrete.EfCore
{
    public class EfCoreCartRepository : EfCoreGenericRepository<Cart, MainContext>, ICartRepository
    {
        public Cart GetByUserId(string userId)
        {
            using (var db = new MainContext())
            {
                return db.Carts
                        .Include(i=>i.CartItems)
                        .ThenInclude(i=>i.Product)
                        .FirstOrDefault(i=>i.UserId==userId);
            }
        }
    }
}