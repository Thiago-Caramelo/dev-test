using System.Collections.Generic;
using Domain;

namespace app.Models
{
    public class CartViewModel
    {
        public int BurgerQty { get; set; }
        public IEnumerable<BurgerPrice> BurgerPrices { get; set; }
        public decimal TotalDiscount { get; set; }
        public decimal Total { get; set; }
    }
}