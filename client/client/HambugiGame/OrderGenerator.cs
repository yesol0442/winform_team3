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
        private List<Order> orders;
        private Random rnd = new Random();

        public Order getOrder()
        {
            int index = rnd.Next(orders.Count);
            return orders[index];
        }

        private static Order O(int price, string comment, bool orderinfo, params IngredientType[] ing)
        {
            return new Order(new List<IngredientType>(ing), price, comment, orderinfo);
        }

        public OrderGenerator()
        {
            orders = new List<Order>
            {
                O(2000, "기본버거에 케첩 살짝!", false,
                    IngredientType.BunBottom,
                    IngredientType.PattyMedium,
                    IngredientType.Ketchup,
                    IngredientType.Tomato,
                    IngredientType.Lettuce,
                    IngredientType.BunTop),

                O(5000, "햄부기햄북 햄북어 햄북스딱스 함부르크햄부가우가 햄비기햄부거 햄부가티햄부기온앤 온을 차려오거라", false,
                    IngredientType.BunBottom,
                    IngredientType.PattyMedium,
                    IngredientType.Ketchup,
                    IngredientType.Tomato,
                    IngredientType.Lettuce,
                    IngredientType.BunTop),

                O(2500, "치즈랑 케첩 듬뿍 부탁", false,
                    IngredientType.BunBottom,
                    IngredientType.PattyMedium,
                    IngredientType.Cheese,
                    IngredientType.Ketchup,
                    IngredientType.Lettuce,
                    IngredientType.BunTop),

                O(2200, "머스타드 찍어 먹게 패티 두 장!", false,
                    IngredientType.BunBottom,
                    IngredientType.PattyMedium,
                    IngredientType.PattyMedium,
                    IngredientType.Mustard,
                    IngredientType.Pickle,
                    IngredientType.BunTop),

                O(2200, "패티 없이 야채·마요만!", false,
                    IngredientType.BunBottom,
                    IngredientType.Mayonnaise,
                    IngredientType.Tomato,
                    IngredientType.Lettuce,
                    IngredientType.Onion,
                    IngredientType.BunTop),

                O(2200, "데리야끼 소스 촉촉하게~", false,
                    IngredientType.BunBottom,
                    IngredientType.TeriyakiSauce,
                    IngredientType.PattyMedium,
                    IngredientType.Cheese,
                    IngredientType.Tomato,
                    IngredientType.BunTop),

                O(2400, "케첩·마요·머스타드 셋 다! 흘러넘쳐야 함", false,
                    IngredientType.BunBottom,
                    IngredientType.Ketchup,
                    IngredientType.Mayonnaise,
                    IngredientType.Mustard,
                    IngredientType.PattyMedium,
                    IngredientType.Pickle,
                    IngredientType.BunTop),

                O(2200, "빵 빼고 바비큐소스 바른 패티 3개. 손에 소스 안묻게 잘 발라", true,
                    IngredientType.PattyMedium,
                    IngredientType.BarbecueSauce,
                    IngredientType.PattyMedium,
                    IngredientType.BarbecueSauce,
                    IngredientType.PattyMedium),

                O(2100, "빵 위쪽·야채·머스타드·패티 난 양파는 싫어", true,
                    IngredientType.PattyMedium,
                    IngredientType.Mustard,
                    IngredientType.Tomato,
                    IngredientType.Lettuce,
                    IngredientType.BunTop),

                O(2100, "레어 패티, 케첩은 꼭!", false,
                    IngredientType.BunBottom,
                    IngredientType.PattyRaw,
                    IngredientType.Ketchup,
                    IngredientType.Tomato,
                    IngredientType.BunTop),

                O(2700, "양상추랑 패티 넣고 마->머->케 순서 지켜 주세요", true,
                    IngredientType.BunBottom,
                    IngredientType.Ketchup,
                    IngredientType.Mustard,
                    IngredientType.Mayonnaise,
                    IngredientType.PattyMedium,
                    IngredientType.Lettuce,
                    IngredientType.BunTop),

                O(2100, "양파 두 겹, 바비큐 소스 스모키하게", false,
                    IngredientType.BunBottom,
                    IngredientType.BarbecueSauce,
                    IngredientType.PattyMedium,
                    IngredientType.Onion,
                    IngredientType.Onion,
                    IngredientType.BunTop),

                O(2100, "토마토 NO, 대신 데리야끼!", false,
                    IngredientType.BunBottom,
                    IngredientType.TeriyakiSauce,
                    IngredientType.PattyMedium,
                    IngredientType.Lettuce,
                    IngredientType.BunTop),

                O(2200, "치즈 녹아내리고 케첩 줄줄~",false,
                    IngredientType.BunBottom,
                    IngredientType.Cheese,
                    IngredientType.Ketchup,
                    IngredientType.Cheese,
                    IngredientType.PattyMedium,
                    IngredientType.Cheese,
                    IngredientType.BunTop),

                O(2300, "야채 빼고 패티·치즈·케첩!",false,
                    IngredientType.BunBottom,
                    IngredientType.Cheese,
                    IngredientType.Ketchup,
                    IngredientType.PattyMedium,
                    IngredientType.BunTop),

                O(2000, "패티3·치즈3·케첩3 콜라보!",false,
                    IngredientType.BunBottom,
                    IngredientType.PattyMedium,
                    IngredientType.Ketchup,
                    IngredientType.Cheese,
                    IngredientType.PattyMedium,
                    IngredientType.Ketchup,
                    IngredientType.Cheese,
                    IngredientType.PattyMedium,
                    IngredientType.Ketchup,
                    IngredientType.Cheese,
                    IngredientType.BunTop),

                O(2200, "빵 빼고 머스타드·패티·야채", false,
                    IngredientType.PattyMedium,
                    IngredientType.Mustard,
                    IngredientType.Lettuce,
                    IngredientType.Tomato,
                    IngredientType.Onion),

                O(2300, "천천히 구운 패티에 바비큐 향 좀", false,
                    IngredientType.BunBottom,
                    IngredientType.PattyMedium,
                    IngredientType.BarbecueSauce,
                    IngredientType.Tomato,
                    IngredientType.BunTop),

                O(2000, "가격 맞춰! 케첩 한 줄이면 돼", false,
                    IngredientType.BunBottom,
                    IngredientType.PattyMedium,
                    IngredientType.Ketchup,
                    IngredientType.BunTop),

                O(2300, "마요랑 케첩", false,
                    IngredientType.BunBottom,
                    IngredientType.Mayonnaise,
                    IngredientType.PattyMedium,
                    IngredientType.Cheese,
                    IngredientType.Ketchup,
                    IngredientType.BunTop),

                O(2600, "패티4, 머스타드 살짝", false,
                    IngredientType.BunBottom,
                    IngredientType.PattyMedium,
                    IngredientType.PattyMedium,
                    IngredientType.PattyMedium,
                    IngredientType.PattyMedium,
                    IngredientType.Mustard,
                    IngredientType.BunTop),

                O(2200, "패티 웰던X, 데리야끼 조금", false,
                    IngredientType.BunBottom,
                    IngredientType.TeriyakiSauce,
                    IngredientType.PattyMedium,
                    IngredientType.Cheese,
                    IngredientType.BunTop),

                O(2400, "바비큐랑 머스타드 콜라보, 자극적으로!",false,
                    IngredientType.BunBottom,
                    IngredientType.BarbecueSauce,
                    IngredientType.PattyMedium,
                    IngredientType.Mustard,
                    IngredientType.Cheese,
                    IngredientType.BunTop),

                O(2500, "패티 태우고 케첩 뿌려 ㅋㅋ", false,
                    IngredientType.BunBottom,
                    IngredientType.PattyBurnt,
                    IngredientType.Ketchup,
                    IngredientType.BunTop),

                O(2100, "수고! 마요는 살짝", false,
                    IngredientType.BunBottom,
                    IngredientType.PattyMedium,
                    IngredientType.Mayonnaise,
                    IngredientType.Tomato,
                    IngredientType.Lettuce,
                    IngredientType.BunTop),


                O(2300, "늘 먹던대로.", false,
                    IngredientType.BunBottom,
                    IngredientType.PattyMedium,
                    IngredientType.Mustard,
                    IngredientType.Lettuce,
                    IngredientType.BunTop),

                O(2400, "케첩+치즈 추가! 야채 싫어요", false,
                    IngredientType.BunBottom,
                    IngredientType.PattyMedium,
                    IngredientType.Cheese,
                    IngredientType.Ketchup,
                    IngredientType.Cheese,
                    IngredientType.BunTop),

                O(2500, "마·머·케 줄줄 흐르도록!", false,
                    IngredientType.BunBottom,
                    IngredientType.Ketchup,
                    IngredientType.Mustard,
                    IngredientType.Mayonnaise,
                    IngredientType.PattyMedium,
                    IngredientType.PattyMedium,
                    IngredientType.BunTop),

                O(2200, "빵 대신 양상추와 고기만, 데리야끼 코팅", false,
                    IngredientType.Lettuce,
                    IngredientType.TeriyakiSauce,
                    IngredientType.PattyMedium,
                    IngredientType.TeriyakiSauce,
                    IngredientType.Lettuce
                    ),

                O(2300, "바비큐~큐~ 한 큐에 만들어줘 난 양파가 좋아~", false,
                    IngredientType.BunBottom,
                    IngredientType.BarbecueSauce,
                    IngredientType.PattyMedium,
                    IngredientType.Onion,
                    IngredientType.BunTop),

                O(2600, "빵·케첩·패티 끝.", true,
                    IngredientType.BunBottom,
                    IngredientType.PattyMedium,
                    IngredientType.Ketchup,
                    IngredientType.BunTop),

                O(2200, "패티 잘 익힘 + 머스타드", false,
                    IngredientType.BunBottom,
                    IngredientType.PattyBurnt,
                    IngredientType.Mustard,
                    IngredientType.Tomato,
                    IngredientType.BunTop),

                O(2200, "레어패티, 바비큐 향만 살짝", false,
                    IngredientType.BunBottom,
                    IngredientType.PattyRaw,
                    IngredientType.BarbecueSauce,
                    IngredientType.Cheese,
                    IngredientType.BunTop),

                O(2300, "토마토 먼저 치즈는 패티 아래! 케첩은 위!", false,
                    IngredientType.BunBottom,
                    IngredientType.Cheese,
                    IngredientType.PattyMedium,
                    IngredientType.Ketchup,
                    IngredientType.Tomato,
                    IngredientType.BunTop),

                O(2600, "머스타드→치즈→패티 두 번!", true,
                    IngredientType.BunBottom,
                    IngredientType.PattyMedium,
                    IngredientType.Cheese,
                    IngredientType.Mustard,
                    IngredientType.PattyMedium,
                    IngredientType.Cheese,
                    IngredientType.Mustard,
                    IngredientType.BunTop),

                O(2500, "마요 듬뿍 아무거나!", false,
                    IngredientType.BunBottom,
                    IngredientType.Mayonnaise,
                    IngredientType.Mayonnaise,
                    IngredientType.Mayonnaise,
                    IngredientType.PattyMedium,
                    IngredientType.Lettuce,
                    IngredientType.BunTop),

                O(2300, "피클×5, 케첩 약간", false,
                    IngredientType.BunBottom,
                    IngredientType.PattyMedium,
                    IngredientType.Pickle,
                    IngredientType.Pickle,
                    IngredientType.Pickle,
                    IngredientType.Pickle,
                    IngredientType.Pickle,
                    IngredientType.Ketchup,
                    IngredientType.BunTop),

                O(2500, "패티·치즈·데리야끼 두툼히", false,
                    IngredientType.BunBottom,
                    IngredientType.TeriyakiSauce,
                    IngredientType.PattyMedium,
                    IngredientType.Cheese,
                    IngredientType.PattyMedium,
                    IngredientType.Cheese,
                    IngredientType.Lettuce,
                    IngredientType.BunTop),

                O(2200, "양파·피클 빼고 머스타드 한 줄", false,
                    IngredientType.BunBottom,
                    IngredientType.PattyMedium,
                    IngredientType.Mustard,
                    IngredientType.Tomato,
                    IngredientType.Lettuce,
                    IngredientType.BunTop),

                O(2000, "바비큐 소스에~ 패티 두 장", false,
                    IngredientType.BunBottom,
                    IngredientType.BarbecueSauce,
                    IngredientType.PattyMedium,
                    IngredientType.PattyMedium,
                    IngredientType.BunTop),

                O(3000, "빵·패티·빵 구조, 마요+케첩", true,
                    IngredientType.BunBottom,
                    IngredientType.Ketchup,
                    IngredientType.PattyMedium,
                    IngredientType.BunBottom,
                    IngredientType.PattyMedium,
                    IngredientType.Mayonnaise,
                    IngredientType.BunTop),

                O(2000, "케첩만 넣어봐? ㅋㅋ 케첩 잔뜩이요", false,
                    IngredientType.BunBottom,
                    IngredientType.Ketchup,
                    IngredientType.Ketchup,
                    IngredientType.Ketchup,
                    IngredientType.BunTop),

                O(2200, "토마토 두 장, 머스타드 2 g 정밀히, 양파와 피클 빼고", false,
                    IngredientType.BunBottom,
                    IngredientType.PattyMedium,
                    IngredientType.Tomato,
                    IngredientType.Tomato,
                    IngredientType.Mustard,
                    IngredientType.Lettuce,
                    IngredientType.BunTop),

                O(2400, "어제 데리야끼 버거 그대로",false,
                    IngredientType.BunBottom,
                    IngredientType.TeriyakiSauce,
                    IngredientType.PattyMedium,
                    IngredientType.Lettuce,
                    IngredientType.Tomato,
                    IngredientType.BunTop),

                O(2400, "케첩 하트 뿅! 별 다섯 줄게요", false,
                    IngredientType.BunBottom,
                    IngredientType.Ketchup,
                    IngredientType.PattyMedium,
                    IngredientType.Cheese,
                    IngredientType.BunTop),

                O(2000, "패티, 마요 살짝", false,
                    IngredientType.BunBottom,
                    IngredientType.PattyMedium,
                    IngredientType.Mayonnaise,
                    IngredientType.BunTop),


                O(2500, "트리플치즈에 데리야끼 덮어줘! 난 고기가 좋아!", false,
                    IngredientType.BunBottom,
                    IngredientType.Cheese,
                    IngredientType.PattyMedium,
                    IngredientType.Cheese,
                    IngredientType.PattyMedium,
                    IngredientType.Cheese,
                    IngredientType.TeriyakiSauce,
                    IngredientType.BunTop),

                O(2300, "빵X, 머스타드·마요 넣어서 주쇼", false,
                    IngredientType.PattyMedium,
                    IngredientType.Mustard,
                    IngredientType.Cheese,
                    IngredientType.Mayonnaise,
                    IngredientType.Tomato,
                    IngredientType.Lettuce),

                O(3000, "피클빵 주세요", false,
                    IngredientType.BunBottom,
                    IngredientType.Pickle,
                    IngredientType.BunTop),
            };

        }
    }
}
