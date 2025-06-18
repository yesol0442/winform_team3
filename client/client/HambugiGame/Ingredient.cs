using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client.HambugiGame
{
    public class Ingredient
    {
        public IngredientType Type { get; }
        public CookState CookState { get; set; } = CookState.Raw;
        public Ingredient(IngredientType type) => Type = type;
    }
}
