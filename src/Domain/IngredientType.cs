using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Domain
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum IngredientType
    {
        Lettuce = 1,
        Bacon = 2,
        Hamburger = 3,
        Egg = 4,
        Cheese = 5
    }
}