using System;
using Domain;

namespace Infra
{
    public interface IRepository
    {
        Burger GetBurgerByType(BurgerType type);
        Ingredient GetIngredientByType(IngredientType ingredientType);
    }    
}