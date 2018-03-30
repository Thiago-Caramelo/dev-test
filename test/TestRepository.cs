using System.Collections.Generic;
using Domain;
using Infra;
using System.Linq;

namespace Test
{
    public class TestRepository : IRepository
    {
        private Ingredient Alface = new Ingredient () { IngredientID = 1, Description = "Alface", Price = 0.40m };
        private Ingredient Bacon = new Ingredient () { IngredientID = 1, Description = "Bacon", Price = 2.00m };
        private Ingredient Hamburger = new Ingredient () { IngredientID = 1, Description = "Hamburguer", Price = 3.00m };
        private Ingredient Egg = new Ingredient () { IngredientID = 1, Description = "Egg", Price = 0.80m };
        private Ingredient Cheese = new Ingredient () { IngredientID = 1, Description = "Cheese", Price = 1.50m };
        private readonly IList<Burger> _localBurgerDb = new List<Burger>();

        public TestRepository()
        {
            var xBurger = new Burger()
            {
                Type = BurgerType.XBacon,
                BurgerIngredients = {
                    new BurgerIngredient() { Qty = 1, Ingredient = Bacon },
                    new BurgerIngredient() { Qty = 1, Ingredient = Hamburger },
                    new BurgerIngredient() { Qty = 1, Ingredient = Cheese }
                    }
            };

            _localBurgerDb.Add(xBurger);
        }

        public Burger GetBurguerByType(BurgerType type)
        {
            return _localBurgerDb.FirstOrDefault(filter => filter.Type == type);
        }
    }
}