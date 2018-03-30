using System.Collections.Generic;

namespace Domain
{
    public class Order
    {
        public int OrderID { get; set; }
        public IList<Burger> OrderBurgers { get; set; }
    }
}