using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Main.Data.Abstract;
using Main.Entity;
using Microsoft.EntityFrameworkCore;

namespace Main.Data.Concrete.EfCore
{
    public class EfCoreCartRepository : EfCoreGenericRepository<Cart>, ICartRepository
    {
        public EfCoreCartRepository(MainContext _db) : base(_db)
        {
            
        }
        public MainContext _db {
            get{return db as MainContext;}
        }
        public void ClearCart(int cartId)
        {
                var cmd = @"delete from cartitems where CartId=@p0";
                _db.Database.ExecuteSqlRaw(cmd,cartId);
        }

        public void DeleteFromCart(int cartId, int productId)
        {
                var cmd = @"delete from cartitems where CartId=@p0 and ProductId=@p1";
                _db.Database.ExecuteSqlRaw(cmd, cartId, productId);
        }

        public Cart GetByUserId(string userId)
        {
                return _db.Carts
                        .Include(i=>i.CartItems)
                        .ThenInclude(i=>i.Product)
                        .FirstOrDefault(i=>i.UserId==userId);
        }
        public override void Update(Cart entity)
        {
                _db.Carts.Update(entity);
                _db.SaveChanges();
        }
    }
}