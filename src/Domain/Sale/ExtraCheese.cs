using System;
using System.Linq;

namespace Domain.Sale
{
    public class ExtraCheese : ISale
    {
        private const string DESCRIPTION = "Muita carne";
        private const decimal DISCOUNT = 1.5m;        
        public SaleDiscount SaleDiscount(Burger burger)
        {
            var saleDiscount = new SaleDiscount() { SaleDescription = DESCRIPTION };

            if (burger == null) throw new ArgumentNullException("burguer");

            var hasCheeseQtyMultipleOfThree =  burger.BurgerIngredients
            .Any(has => has.Ingredient.IngredientType == IngredientType.Cheese && has.Qty % 3 == 0);

            if (hasCheeseQtyMultipleOfThree)
            {
                var cheeseIngredient = burger.BurgerIngredients.FirstOrDefault(has => has.Ingredient.IngredientType == IngredientType.Cheese);
                var cheeseQty = cheeseIngredient?.Qty;
                var saleQty = cheeseQty / DISCOUNT;
                var qtyDiscount = cheeseQty - saleQty;
                saleDiscount.Discount = (qtyDiscount.HasValue ? qtyDiscount.Value : decimal.Zero) * cheeseIngredient.Ingredient.Price;
            }

            return saleDiscount;
        }
    }
}