using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using app.Models;
using Services;

namespace app.Controllers
{
    [Route("Order")]
    public class OrderController : Controller
    {
        private readonly OrderService _orderService;

        public OrderController(OrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost("Burger")]
        public IActionResult AddBurger([FromBody]BurgerOrderViewModel burgerOrder)
        {
            return PartialView("Cart", new CartViewModel());
        }
    }
}
