using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain;

namespace Test
{
    [TestClass]
    public class BurgerTest
    {
        [TestMethod]
        public void XBacon_Price_Should_Be_6_50()
        {   
            const decimal xBaconPrice = 6.50m;

            var repository = new TestRepository();
            var burger = repository.GetBurguerByType(BurgerType.XBacon);
            var burgerPrice = burger.Price();
            Assert.AreEqual<decimal>(xBaconPrice, burgerPrice);
            // pegar a quantidade pedida e ver se é multiplo de 3, ou seja se dividir por 3 e não tive resto
            // para saber quanto o cliente vai pagar é só dividir por 1,5
        }
    }
}
