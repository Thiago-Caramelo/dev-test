using System;
using Domain;

namespace Infra
{
    public interface IRepository
    {
        Burger GetBurguerByType(BurgerType type);
    }    
}