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
            var burger = repository.GetBurgerByType(BurgerType.XBacon);
            var burgerPrice = burger.Price();
            Assert.AreEqual<decimal>(xBaconPrice, burgerPrice);
        }
        [TestMethod]
        public void XBurger_Price_Should_Be_4_50()
        {
            const decimal xBurgerPrice = 4.50m;

            var repository = new TestRepository();
            var burger = repository.GetBurgerByType(BurgerType.XBurguer);
            var burgerPrice = burger.Price();
            Assert.AreEqual<decimal>(xBurgerPrice, burgerPrice);
        }
        [TestMethod]
        public void XEgg_Price_Should_Be_5_30()
        {
            const decimal xEggPrice = 5.30m;

            var repository = new TestRepository();
            var burger = repository.GetBurgerByType(BurgerType.XEgg);
            var burgerPrice = burger.Price();
            Assert.AreEqual(xEggPrice, burgerPrice);
        }
        [TestMethod]
        public void XEggBacon_Price_Should_Be_7_30()
        {
            const decimal xEggBaconPrice = 7.30m;

            var repository = new TestRepository();
            var burger = repository.GetBurgerByType(BurgerType.XEggBacon);
            var burgerPrice = burger.Price();
            Assert.AreEqual<decimal>(xEggBaconPrice, burgerPrice);
        }
    }
}
