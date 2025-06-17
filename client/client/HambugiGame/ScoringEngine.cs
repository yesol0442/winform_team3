using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client.HambugiGame
{
    public class ScoringEngine
    {
        public (int earned, string comment) Evaluate(Order order, Burger cooked)
        {
            // 1. 조립 여부 (맨 위·아래가 빵인지 확인)
            if (cooked.Layers.FirstOrDefault()?.Type != IngredientType.BunBottom ||
                cooked.Layers.LastOrDefault()?.Type != IngredientType.BunTop)
                return (0, "음식이 장난이야?");

            // 2. 패티 익힘
            var patty = cooked.Layers.FirstOrDefault(x => x.Type.ToString().Contains("Patty"));
            if (patty != null && patty.CookState == CookState.Raw)
                return (-5000, "엑 하나도 안 익었잖아! 병원비 줘!");

            // 3. 순서·구성 비교
            bool perfect = cooked.Layers.Select(l => l.Type).SequenceEqual(order.Recipe);
            if (perfect) return (order.BasePrice, "완벽해요!");

            // 누락·순서 오류 → 50% 삭감
            return ((int)(order.BasePrice * 0.5), "뭔가 빠졌거나 순서가 이상해요");
        }
    }
}