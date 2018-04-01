using System;
using System.Collections.Generic;
using Domain;
using System.Linq;

namespace app.Models
{
    public class BurgerViewModel
    {
        public BurgerViewModel() { }
        public BurgerViewModel(Burger burger) {
            
            if (burger == null) throw new ArgumentNullException("burger");

            BurgerType = burger.Type.ToString();
            BurgerName = burger.Name;
            BurgerPrice = burger.Price();
            IngredientsDescription = burger.BurgerIngredients.Select(result => result.Ingredient.Description);
        }

        public string BurgerType { get; set; }
        public string BurgerName { get; set; }
        public decimal BurgerPrice { get; set; }
        public IEnumerable<string> IngredientsDescription { get; set; }
    }
}