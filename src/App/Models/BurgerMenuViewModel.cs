using System.Collections.Generic;
using Domain;

namespace app.Models
{
    public class BurgerMenuViewModel
    {
        public IEnumerable<BurgerViewModel> Burgers { get; set; }
        public IEnumerable<IngredientViewModel> Ingredients { get; set; }
    }
}