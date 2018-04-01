using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using app.Models;
using Infra;
using Services;

namespace app.Controllers
{
    public class MenuController : Controller
    {
        private readonly MenuService _menuService;
        public MenuController(MenuService menuService)
        {
            _menuService = menuService;
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

            return View(menuViewModel);
        }
    }
}