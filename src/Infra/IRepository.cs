using System;
using System.Collections.Generic;
using Domain;
using Domain.Sale;

namespace Infra
{
    public interface IRepository
    {
        Burger GetBurgerByType(BurgerType type);
        Ingredient GetIngredientByType(IngredientType ingredientType);
        IList<Burger> GetMenuBurgers();
        IList<Ingredient> GetIngredients();
        Order GetOrderByCartId(string cartId);
        void SaveOrder(Order order);
        IList<Sale> GetActiveSales();
    }    
}