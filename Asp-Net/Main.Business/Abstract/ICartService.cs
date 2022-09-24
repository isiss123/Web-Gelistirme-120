using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Main.Entity;

namespace Main.Business.Abstract
{
    public interface ICartService
    {
        void InitializeCart(string userId);
        Cart GetCartByUserId(string userId);
        bool AddToCart(string userId, int productId, int quantity);
        void DeleteFromCart(string userId, int productId);
    }
}