using System;
using System.Linq;

namespace Domain.Sale
{
    public class LightSale : ISale
    {
        private const decimal DISCOUNT = 0.1m;
        private const string DESCRIPTION = "Light";
        public SaleDiscount SaleDiscount(Burger burger)
        {
            var saleDiscount = new SaleDiscount() { SaleDescription = DESCRIPTION };

            if (burger == null) throw new ArgumentNullException("burguer");

            var hasLettuce = burger.BurgerIngredients.Any(has => has.Ingredient.IngredientType == IngredientType.Lettuce);
            var hasNotBacon = !burger.BurgerIngredients.Any(has => has.Ingredient.IngredientType == IngredientType.Bacon);

            if (hasLettuce && hasNotBacon)
            {
                saleDiscount.Discount = burger.Price() * DISCOUNT;
            }

            return saleDiscount;
        }
    }
}