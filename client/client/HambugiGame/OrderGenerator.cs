using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace client.HambugiGame
{
    public class OrderGenerator
    {
        private readonly Timer _timer;
        private readonly List<Order> _orders = new List<Order>();
        private readonly Random _rand = new Random();

        public event Action<Order> OnOrderCreated;

        public OrderGenerator()
        {
            _timer = new Timer { Interval = _rand.Next(1000, 3000) };
            _timer.Tick += (_, _) =>
            {
                if (_orders.Count >= 5) return;

                var order = MakeRandomOrder();
                _orders.Add(order);
                OnOrderCreated?.Invoke(order);

                // 다음 간격 재설정
                _timer.Interval = _rand.Next(1000, 3000);
            };
        }

        public void Start() => _timer.Start();
        private Order MakeRandomOrder()
        {
            // 예시: 패티 1장 기본 햄버거
            var recipe = new List<IngredientType>
        {
            IngredientType.BunBottom,
            IngredientType.PattyMedium,
            IngredientType.Tomato,
            IngredientType.Lettuce,
            IngredientType.BunTop
        };
            return new Order(recipe, 500, "기본으로 주세요!");
        }
    }
}
