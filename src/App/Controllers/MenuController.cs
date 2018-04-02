using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using app.Models;
using Infra;
using Services;
using Domain;

namespace app.Controllers
{
    public class MenuController : Controller
    {
        private readonly MenuService _menuService;
        private readonly IUtil _util;
        private readonly OrderService _orderService;
        private readonly SaleService _saleService;
        public MenuController(MenuService menuService, IUtil util, OrderService orderService, SaleService saleService)
        {
            _menuService = menuService;
            _util = util;
            _orderService = orderService;
            _saleService = saleService;
        }
        public IActionResult Index()
        {
            var burgers = _menuService.GetMenuBurgers();
            var ingredients = _menuService.GetIngredients();

            var menuViewModel = new BurgerMenuViewModel();
            var burgersViewModel = new List<BurgerViewModel>();

            foreach (var burger in burgers)
            {
                burgersViewModel.Add(new BurgerViewModel(burger));
            }

            menuViewModel.Burgers = burgersViewModel;
            menuViewModel.Ingredients = ingredients
                .Select(ingredient => new IngredientViewModel()
                    {
                        IngredientDescription = ingredient.Description,
                        IngredientQty = 1,
                        IngredientType = ingredient.IngredientType
                    });

            var cartId = _util.GetCartId();
            var order = _orderService.GetOrderByCartId(cartId);

            if (order != null) {
                var orderBurgersPrices = order.OrderBurgersPrices(_saleService.GetActiveSales());
                var cartViewModel = new CartViewModel()
                {
                    BurgerPrices = orderBurgersPrices,
                    TotalDiscount = orderBurgersPrices.Sum(sum => sum.Discount),
                    BurgerQty = order.QtyBurgers(),
                    Total = orderBurgersPrices.Sum(sum => sum.Price)
                };
                menuViewModel.CartViewModel = cartViewModel;
            }

            return View(menuViewModel);
        }
    }
}