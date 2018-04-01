using Domain;

namespace app.Models
{
    public class IngredientViewModel
    {
        public IngredientType IngredientType { get; set; }
        public string IngredientDescription { get; set; }
        public int IngredientQty { get; set; }
    }
}