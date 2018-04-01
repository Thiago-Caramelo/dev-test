using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain;
using Domain.Sale;
using System.Collections.Generic;

namespace Test
{
    [TestClass]
    public class SaleTest
    {
        [TestMethod]
        public void Light_Burguer_Should_Be_10_Percent_Cheaper()
        {   
            const decimal discount = 0.90m;

            var repository = new TestRepository();
            var burger = new Burger(BurgerType.XCustom.ToString(), 
            new List<BurgerIngredient>() { new BurgerIngredient() { Ingredient = repository.GetIngredientByType(IngredientType.Lettuce) } },
            BurgerType.XCustom);

            var burgerOriginalPrice = burger.Price();
            var burgerSalePrice = burger.Price(new LightSale());
            Assert.AreEqual<decimal>(burgerOriginalPrice * discount, burgerSalePrice);
        }
        [TestMethod]
        public void Extra_Hamburger_Burger_Should_Be_Proportionally_Cheaper()
        {
            // pegar a quantidade pedida e ver se é multiplo de 3, ou seja se dividir por 3 e não tive resto
            // para saber quanto o cliente vai pagar é só dividir por 1,5

            var repository = new TestRepository();
            var saleBurger = repository.GetBurgerByType(BurgerType.XBurguer);
            var burger  = repository.GetBurgerByType(BurgerType.XBurguer);
            
            saleBurger.SetIngredientQuantity(repository.GetIngredientByType(IngredientType.Hamburger), 3);
            burger.SetIngredientQuantity(repository.GetIngredientByType(IngredientType.Hamburger), 2);
            
            var saleBurgerPrice = saleBurger.Price(new ExtraHamburger());
            var burgerPrice = burger.Price();

            Assert.AreEqual<decimal>(burgerPrice, saleBurgerPrice);
        }
    }
}