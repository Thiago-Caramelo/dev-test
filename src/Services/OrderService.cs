using System;
using Domain;
using Infra;

namespace Services
{
    public class OrderService
    {
        private IRepository _repository;
        public OrderService(IRepository repository)
        {
            _repository = repository;
        }
        public Order GetOrderByCartId(string cartId)
        {
            return _repository.GetOrderByCartId(cartId);
        }
        public Order OrderBurger(string cartId, Burger burger) {

            var order = _repository.GetOrderByCartId(cartId);

            if (order == null) {
                order = new Order(cartId, burger);
                _repository.SaveOrder(order);
            }
            else
            {
                order.AddBurger(burger);
            }

            return order;
        }
    }
}
