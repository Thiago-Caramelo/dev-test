using System.Collections.Generic;
using Domain;
using Infra;
using System.Linq;

namespace Test
{
    public class TestRepository : IRepository
    {
        private readonly Dictionary<IngredientType, Ingredient> _ingredients = new Dictionary<IngredientType, Ingredient>()
        {
            { IngredientType.Lettuce, new Ingredient () { Description = "Alface", Price = 0.40m, IngredientType = IngredientType.Lettuce } },
            { IngredientType.Bacon, new Ingredient () { Description = "Bacon", Price = 2.00m, IngredientType = IngredientType.Bacon } },
            { IngredientType.Hamburger, new Ingredient () { Description = "Hamburguer de carne", Price = 3.00m, IngredientType = IngredientType.Hamburger } },
            { IngredientType.Egg, new Ingredient () { Description = "Ovo", Price = 0.80m, IngredientType = IngredientType.Egg } },
            { IngredientType.Cheese, new Ingredient () { Description = "Queijo", Price = 1.50m, IngredientType = IngredientType.Cheese } }
        };
        public Dictionary<IngredientType, Ingredient> Ingredients
        {
            get { return _ingredients; }
        }
        

        private readonly IList<Burger> _localBurgerDb = new List<Burger>();

        public TestRepository()
        {
            var XBacon = new Burger()
            {
                Type = BurgerType.XBacon,
                BurgerIngredients = {
                    new BurgerIngredient() { Qty = 1, Ingredient = _ingredients[IngredientType.Bacon] },
                    new BurgerIngredient() { Qty = 1, Ingredient = _ingredients[IngredientType.Hamburger] },
                    new BurgerIngredient() { Qty = 1, Ingredient = _ingredients[IngredientType.Cheese] }
                }
            };

            _localBurgerDb.Add(XBacon);
        }

        public Burger GetBurguerByType(BurgerType type)
        {
            return _localBurgerDb.FirstOrDefault(filter => filter.Type == type);
        }
    }
}