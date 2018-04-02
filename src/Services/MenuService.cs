using System.Collections.Generic;
using Domain;
using Infra;

namespace Services
{
    public class MenuService
    {
        private readonly IRepository _repository;
        public MenuService(IRepository repository)
        {
            _repository = repository;
        }

        public IList<Burger> GetMenuBurgers()
        {
            return _repository.GetMenuBurgers();
        }

        public IList<Ingredient> GetIngredients()
        {
            return _repository.GetIngredients();
        }

        public Ingredient GetIngredientByType(IngredientType ingredientType)
        {
            return _repository.GetIngredientByType(ingredientType);
        }
        public Burger GetBurgerByType(BurgerType burgerType)
        {
            return _repository.GetBurgerByType(burgerType);
        }
    }
}

