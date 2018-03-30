using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain
{
    public class Burger
    {
        public IList<BurgerIngredient> BurgerIngredients { get; set; } = new List<BurgerIngredient>();
        public BurgerType Type { get; set; }
        public decimal Price()
        {
            var total = BurgerIngredients.Sum(toSum => toSum.Ingredient.Price * toSum.Qty);
            return total;
        }
    }
}