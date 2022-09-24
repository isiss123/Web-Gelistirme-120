using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Main.Business.Abstract;
using Main.Data.Abstract;
using Main.Entity;

namespace Main.Business.Concrete
{
    public class CartManager : ICartService
    {
        public ICartRepository _cartRepository { get; set; }
        

        public CartManager(ICartRepository cartRepository)
        {
            this._cartRepository = cartRepository;
        }
        public void InitializeCart(string userId)
        {
            _cartRepository.Create(new Entity.Cart{UserId = userId});
        }

        public Cart GetCartByUserId(string userId)
        {
            return _cartRepository.GetByUserId(userId);
        }
    }
}