using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Sale;

namespace Domain
{
    public class Burger
    {
        public Burger(string name, IList<BurgerIngredient> burgerIngredients, BurgerType type, string description = null)
        {
            Name = name;
            Description = description;
            Type = type;
            BurgerIngredients = new List<BurgerIngredient>(burgerIngredients);
        }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public IList<BurgerIngredient> BurgerIngredients { get; private set; } = new List<BurgerIngredient>();
        public BurgerType Type { get; private set; }
        public IList<SaleDiscount> SaleDiscounts { get; private set; } = new List<SaleDiscount>();
        public decimal Price()
        {
            return Price(new List<ISale>());
        }
        public decimal Price(ISale sale)
        {
            var sales = new List<ISale>() { sale };
            return Price(sales);
        }
        public decimal Price(IList<ISale> sales)
        {
            var total = BurgerIngredients.Sum(toSum => toSum.Ingredient.Price * toSum.Qty);

            this.SaleDiscounts.Clear();
            
            for (int i = 0; sales != null && i < sales.Count; i++)
            {
                var sale = sales[i];
                var saleDiscount = sale.SaleDiscount(this);

                total -= saleDiscount.Discount;

                this.SaleDiscounts.Add(saleDiscount);
            }

            return total;
        }
        public void SetIngredientQuantity(Ingredient ingredient, int qty)
        {
            var existingIngredient = BurgerIngredients.FirstOrDefault(type => type.Ingredient.IngredientType == ingredient.IngredientType);

            if (existingIngredient == null) {
                BurgerIngredients.Add(new BurgerIngredient() { Ingredient = ingredient, Qty = qty } );
            }
            else
            {
                BurgerIngredients.Remove(existingIngredient);
                BurgerIngredients.Add(new BurgerIngredient() { Ingredient = ingredient, Qty = qty } );
            }
        }
    }
}