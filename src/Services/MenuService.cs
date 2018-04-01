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
    }
}