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

        public bool AddToCart(string userId, int productId, int quantity)
        {
            var cart = _cartRepository.GetByUserId(userId);
            if(cart!=null)
            {
                var index = cart.CartItems.FindIndex(i=>i.ProductId==productId);
                if(index<0)
                {
                    cart.CartItems.Add(new CartItem{
                        ProductId = productId,
                        Quantity = quantity,
                        CartId = cart.Id
                    });
                }else{
                    cart.CartItems[index].Quantity += quantity;
                }
                _cartRepository.Update(cart);
                return true;
            }
            return false;
        }

        public void DeleteFromCart(string userId, int productId)
        {
            var cart = GetCartByUserId(userId);
            if(cart!=null)
            {
                _cartRepository.DeleteFromCart(cart.Id, productId);
            }
        }
    }
}