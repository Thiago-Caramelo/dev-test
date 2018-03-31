using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Sale;

namespace Domain
{
    public class Burger
    {
        public IList<BurgerIngredient> BurgerIngredients { get; set; } = new List<BurgerIngredient>();
        public BurgerType Type { get; set; }
        public IList<SaleDiscount> SaleDiscounts { get; set; } = new List<SaleDiscount>();
        public decimal Price()
        {
            return Price(new List<ISale>());
        }
        public decimal Price(ISale sale)
        {
            var sales = new List<ISale>() { sale };
            return Price(sales);
        }
        public decimal Price(IList<ISale> sales)
        {
            var total = BurgerIngredients.Sum(toSum => toSum.Ingredient.Price * toSum.Qty);

            this.SaleDiscounts.Clear();
            
            for (int i = 0; sales != null && i < sales.Count; i++)
            {
                var sale = sales[i];
                var saleDiscount = sale.SaleDiscount(this);

                total -= saleDiscount.Discount;

                this.SaleDiscounts.Add(saleDiscount);
            }

            return total;
        }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}