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
        private readonly IRepository _repository;
        private readonly MenuService _menuService;
        public MenuController(IRepository repository, MenuService menuService)
        {
            _repository = repository;
            _menuService = menuService;
        }
        public IActionResult Index()
        {
            var burgers = _repository.GetMenuBurgers();

            return View();
        }
    }
}