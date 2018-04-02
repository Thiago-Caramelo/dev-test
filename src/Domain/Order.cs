using System.Collections.Generic;
using Domain.Sale;
using System.Linq;

namespace Domain
{
    public class Order
    {
        public Order(string cartId, Burger burger)
        {
            CartId = cartId;
            OrderBurgers.Add(burger);
        }
        public void AddBurger(Burger burger)
        {
            OrderBurgers.Add(burger);
        }
        public void ClearOrder()
        {
            OrderBurgers.Clear();
        }
        public int OrderID { get; set; }
        public string CartId { get; set; }
        private IList<Burger> OrderBurgers { get; set; } = new List<Burger>();
        public int QtyBurgers()
        {
            return OrderBurgers.Count;
        }

        public IEnumerable<BurgerPrice> OrderBurgersPrices(IEnumerable<ISale> sales)
        {
            return OrderBurgers
                .Select(bg => new BurgerPrice()
                 {
                     Price = bg.Price(sales.ToList()),
                     BurgerName = bg.Name,
                     Discount = bg.SaleDiscounts.Sum(sum => sum.Discount) }
                 );
        }
    }
}