using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client.HambugiGame
{
    public class Order
    {
        public Guid Id { get; } = Guid.NewGuid();
        public List<IngredientType> Recipe { get; }
        public int BasePrice { get; }          // 주문표에 적힌 가격
        public string Comment { get; }
        public Order(List<IngredientType> recipe, int price, string comment)
            => (Recipe, BasePrice, Comment) = (recipe, price, comment);
    }
}
