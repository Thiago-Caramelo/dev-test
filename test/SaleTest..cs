using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain;
using Domain.Sale;

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
            var burger = new Burger() { BurgerIngredients = { new BurgerIngredient() { Ingredient = repository.Ingredients[IngredientType.Lettuce] } } };
            var burgerOriginalPrice = burger.Price();
            var burgerSalePrice = burger.Price(new LightSale());
            Assert.AreEqual<decimal>(burgerOriginalPrice * discount, burgerSalePrice);
            // pegar a quantidade pedida e ver se é multiplo de 3, ou seja se dividir por 3 e não tive resto
            // para saber quanto o cliente vai pagar é só dividir por 1,5
        }
    }
}
