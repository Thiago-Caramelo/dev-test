using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Domain
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum BurgerType
    {
        XCustom = 0,
        XBacon = 1,
        XBurguer = 2,
        XEgg = 3,
        XEggBacon = 4
    }    
}