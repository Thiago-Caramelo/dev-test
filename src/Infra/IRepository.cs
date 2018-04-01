using System;
using System.Collections.Generic;
using Domain;

namespace Infra
{
    public interface IRepository
    {
        Burger GetBurgerByType(BurgerType type);
        Ingredient GetIngredientByType(IngredientType ingredientType);
        IList<Burger> GetMenuBurgers();
    }    
}