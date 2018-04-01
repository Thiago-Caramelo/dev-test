using System;
using System.Linq;

namespace Domain.Sale
{
    public class ExtraHamburger : ISale
    {
        private const string DESCRIPTION = "Muita carne";
        private const decimal DISCOUNT = 1.5m;
        public SaleDiscount SaleDiscount(Burger burger)
        {
            var saleDiscount = new SaleDiscount() { SaleDescription = DESCRIPTION };

            if (burger == null) throw new ArgumentNullException("burguer");

            var hasBurger = burger.BurgerIngredients
            .Any(has => has.Ingredient.IngredientType == IngredientType.Hamburger && has.Qty % 3 == 0);

            if (hasBurger) {
                var hamburgerIngredient = burger.BurgerIngredients.FirstOrDefault(has => has.Ingredient.IngredientType == IngredientType.Hamburger);
                var hamburgerQty= hamburgerIngredient?.Qty;
                var saleQty = hamburgerQty / DISCOUNT;
                var qtyDiscount = hamburgerQty - saleQty;
                saleDiscount.Discount = qtyDiscount.HasValue ? qtyDiscount.Value : decimal.Zero * hamburgerIngredient.Ingredient.Price;
            }

            return saleDiscount;
        }
    }
}