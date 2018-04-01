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
        private readonly IList<Burger> _localBurgerDb = new List<Burger>();
        public TestRepository()
        {
            var XBacon = new Burger(BurgerType.XBacon.ToString(),
            new List<BurgerIngredient>(){
                    new BurgerIngredient() { Qty = 1, Ingredient = _ingredients[IngredientType.Bacon] },
                    new BurgerIngredient() { Qty = 1, Ingredient = _ingredients[IngredientType.Hamburger] },
                    new BurgerIngredient() { Qty = 1, Ingredient = _ingredients[IngredientType.Cheese] }
                }, BurgerType.XBacon
            );

            var XBurger = new Burger(BurgerType.XBurguer.ToString(),
            new List<BurgerIngredient>(){
                    new BurgerIngredient() { Qty = 1, Ingredient = _ingredients[IngredientType.Hamburger] },
                    new BurgerIngredient() { Qty = 1, Ingredient = _ingredients[IngredientType.Cheese] }
            }, BurgerType.XBurguer
            );

            var xEgg = new Burger(BurgerType.XEgg.ToString(),
            new List<BurgerIngredient>() {
                    new BurgerIngredient() { Qty = 1, Ingredient = _ingredients[IngredientType.Egg] },
                    new BurgerIngredient() { Qty = 1, Ingredient = _ingredients[IngredientType.Hamburger] },
                    new BurgerIngredient() { Qty = 1, Ingredient = _ingredients[IngredientType.Cheese] }
            }, BurgerType.XEgg
            );

            var xEggBacon = new Burger(BurgerType.XEggBacon.ToString(),
            new List<BurgerIngredient>() {
                    new BurgerIngredient() { Qty = 1, Ingredient = _ingredients[IngredientType.Egg] },
                    new BurgerIngredient() { Qty = 1, Ingredient = _ingredients[IngredientType.Hamburger] },
                    new BurgerIngredient() { Qty = 1, Ingredient = _ingredients[IngredientType.Cheese] },
                    new BurgerIngredient() { Qty = 1, Ingredient = _ingredients[IngredientType.Bacon] }
            }, BurgerType.XEggBacon
            );

            _localBurgerDb.Add(XBacon);
            _localBurgerDb.Add(XBurger);
            _localBurgerDb.Add(xEgg);
            _localBurgerDb.Add(xEggBacon);
        }
        public Burger GetBurgerByType(BurgerType type)
        {
            return _localBurgerDb.FirstOrDefault(filter => filter.Type == type);
        }
        public Ingredient GetIngredientByType(IngredientType ingredientType)
        {
            return _ingredients[ingredientType];
        }
    }
}