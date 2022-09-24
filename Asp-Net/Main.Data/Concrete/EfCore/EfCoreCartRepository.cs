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
        public void DeleteFromCart(int cartId, int productId)
        {
            using (var db = new MainContext())
            {
                var cmd = @"delete from cartitems where CartId=@p0 and ProductId=@p1";
                db.Database.ExecuteSqlRaw(cmd, cartId, productId);
            }
        }

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
        public override void Update(Cart entity)
        {
            using( var db = new MainContext())
            {
                db.Carts.Update(entity);
                db.SaveChanges();
            }
        }
    }
}