using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using app.Models;
using Services;
using Microsoft.AspNetCore.Http;
using Domain;

namespace app.Controllers
{
    [Route("Order")]
    public class OrderController : Controller
    {
        private readonly OrderService _orderService;
        private readonly MenuService _menuService;
        private readonly SaleService _saleService;
        private readonly IUtil _util;

        public OrderController(OrderService orderService, IUtil util, MenuService menuService, SaleService saleService)
        {
            _orderService = orderService;
            _util = util;
            _menuService = menuService;
            _saleService = saleService;
        }

        [HttpPost("Burger")]
        public IActionResult AddBurger([FromBody]BurgerOrderViewModel burgerOrder)
        {
            var cartId = _util.GetCartId();
            Burger burger;

            if (burgerOrder.BurgerType == BurgerType.XCustom)
            {
                var ingredients = burgerOrder?
                .BurgerIngredients?
                .Select(ing => new BurgerIngredient()
                { Qty = ing.IngredientQty, Ingredient = _menuService.GetIngredientByType(ing.IngredientType) })?.ToList();

                burger = new Burger(BurgerType.XCustom.ToString(), ingredients, burgerOrder.BurgerType);
            }
            else
            {
                burger = _menuService.GetBurgerByType(burgerOrder.BurgerType);
            }

            var order = _orderService.OrderBurger(cartId, burger);

            var orderBurgersPrices = order.OrderBurgersPrices(_saleService.GetActiveSales());

            var cartViewModel = new CartViewModel()
            {
                BurgerPrices = orderBurgersPrices,
                TotalDiscount = orderBurgersPrices.Sum(sum => sum.Discount),
                BurgerQty = order.QtyBurgers(),
                Total = orderBurgersPrices.Sum(sum => sum.Price) - orderBurgersPrices.Sum(sum => sum.Discount)
            };

            return PartialView("Cart", cartViewModel);
        }
    }
}
