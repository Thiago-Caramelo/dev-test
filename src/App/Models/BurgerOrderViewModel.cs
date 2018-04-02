using System.Collections.Generic;
using Domain;

namespace app.Models
{
    public class BurgerOrderViewModel
    {
        public BurgerType BurgerType { get; set; }
        public IEnumerable<IngredientViewModel> BurgerIngredients { get; set; }
    }
}