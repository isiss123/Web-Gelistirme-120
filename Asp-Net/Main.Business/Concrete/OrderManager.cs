using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Main.Business.Abstract;
using Main.Data.Abstract;
using Main.Entity;

namespace Main.Business.Concrete
{
    public class OrderManager : IOrderService
    {
        public IOrderRepository _orderRepository { get; set; }
        

        public OrderManager(IOrderRepository orderRepository)
        {
            this._orderRepository = orderRepository;
        }
        public void Create(Order entity)
        {
            _orderRepository.Create(entity);
        }
    }
}