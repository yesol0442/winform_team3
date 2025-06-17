using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client.HambugiGame
{
    public class Order
    {
        public List<IngredientType> Recipe { get; }
        public int BasePrice { get; } // 주문표에 적힌 가격
        public string Comment { get; }

        public bool Orderinfo { get; } // 주문 순서가 중요한가?
        public Order(List<IngredientType> recipe, int price, string comment, bool orderinfo)
            => (Recipe, BasePrice, Comment,Orderinfo) = (recipe, price, comment,orderinfo);
    }
}
