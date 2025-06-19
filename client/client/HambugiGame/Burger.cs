using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client.HambugiGame
{
    public class Burger
    {
        public List<Ingredient> Layers { get; } = new List<Ingredient>();
        public void AddIngredient(Ingredient ing) => Layers.Add(ing);

        public Ingredient FindFirstIngredient(IngredientType t)
        {
            return Layers.FirstOrDefault(x => x.Type == t);
        }
    }
}