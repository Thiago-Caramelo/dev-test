using System;
using System.Collections.Generic;

namespace Domain
{
    public class Burguer
    {
        public IList<Ingredient> Ingredients { get; set; }
        public BurguerType Type { get; set; }
        public decimal Price()
        {
            throw new NotImplementedException();
        }
    }
}