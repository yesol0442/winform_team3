using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client.HambugiGame
{
    public class ScoringEngine
    {
        private static bool IsPatty(IngredientType t)
        {
            return t == IngredientType.PattyRaw ||
                   t == IngredientType.PattyMedium ||
                   t == IngredientType.PattyBurnt;
        }

        private static bool IsCookableVeg(IngredientType t)
        {
            //“가열되면 안 됨
            return t == IngredientType.Tomato ||
                   t == IngredientType.Lettuce ||
                   t == IngredientType.Onion ||
                   t == IngredientType.Pickle;
        }

        private static bool NeedBottomBun(Order order)
        {
            return order.Recipe.Contains(IngredientType.BunBottom);
        }

        private static bool NeedTopBun(Order order)
        {
            return order.Recipe.Contains(IngredientType.BunTop);
        }

        private static bool BottomBunCorrect(Burger b)
        {
            return b.Layers.Count > 0 && b.Layers[0].Type == IngredientType.BunBottom;
        }

        private static bool TopBunCorrect(Burger b)
        {
            return b.Layers.Count > 0 &&
                   b.Layers[b.Layers.Count - 1].Type == IngredientType.BunTop;
        }


        public static (int earned, string comment) Evaluate(Order order, Burger cooked)
        {
            int earned = order.BasePrice;
            string comment = null;


            //고기 익힘 검사
            int needRaw = order.Recipe.Count(t => t == IngredientType.PattyRaw);
            int needMed = order.Recipe.Count(t => t == IngredientType.PattyMedium);
            int needBurnt = order.Recipe.Count(t => t == IngredientType.PattyBurnt);
            int gotRaw = 0, gotMed = 0, gotBurnt = 0;

            foreach (var layer in cooked.Layers)
            {
                if (!IsPatty(layer.Type)) continue;

                switch (layer.CookState)
                {
                    case CookState.Raw: gotRaw++; break;
                    case CookState.Medium: gotMed++; break;
                    case CookState.Burnt: gotBurnt++; break;
                }
            }

            // - 5000
            if (needRaw == 0 && gotRaw > 0)
                return (-5000, "엑 하나도 안 익었잖아! 병원비 내놓으라!");

            // 태우면 30퍼 감점
            if (needBurnt == 0 && gotBurnt > 0)
            {
                earned = (int)(earned * 0.7);
                comment = "퉤퉤 이게 뭐야! 음식이 장난이야?";
            }

            foreach (var layer in cooked.Layers)
            {
                if (IsCookableVeg(layer.Type) && layer.CookState != CookState.Raw)
                {
                    earned = (int)(earned * 0.8);
                    comment = "채소를 왜 익힌거야?";
                    break;
                }
            }

            // 재료 비교 순서 무시함
            var expected = new List<IngredientType>(order.Recipe);
            var actual = new List<IngredientType>();

            foreach (var l in cooked.Layers) actual.Add(l.Type);

            List<IngredientType> missing = new List<IngredientType>();
            List<IngredientType> extra = new List<IngredientType>();

            foreach (var ing in expected)
            {
                if (!actual.Remove(ing))
                    missing.Add(ing);
            }
            extra.AddRange(actual);

            // 순서 검사
            bool orderCorrect = true;
            if (order.Orderinfo)
            {
                int len = System.Math.Min(order.Recipe.Count, cooked.Layers.Count);

                for (int i = 0; i < len; i++)
                {
                    if (order.Recipe[i] != cooked.Layers[i].Type)
                    {
                        orderCorrect = false;
                        break;
                    }
                }

                if (!orderCorrect)
                {
                    earned = (int)(earned * 0.8);
                    comment = "순서가 뒤죽박죽이네! ";
                }
            }
            else
            {
                if (NeedBottomBun(order) || NeedTopBun(order))
                {
                    orderCorrect = false;
                    bool bottomOk = !NeedBottomBun(order) || BottomBunCorrect(cooked);
                    bool topOk = !NeedTopBun(order) || TopBunCorrect(cooked);

                    if (!bottomOk || !topOk)
                    {
                        
                        earned = (int)(earned * 0.9);
                        comment = "빵이 ..? ";
                    }
                }
            }

            // 누락이나 과다인 경우 감점
            if (missing.Count > 0 || extra.Count > 0)
            {
                if (missing.Count + extra.Count <= 2)
                {
                    if (missing.Count > 0)
                        comment = string.Format("{0} 빠졌어요!", string.Join(", ", missing));
                    else if (extra.Count > 0)
                        comment = "뭔가 이상한데?";
                }
                else
                {
                    comment = "제 햄버거 아닌것 같은데요";
                }
                int unitPenalty = order.BasePrice / order.Recipe.Count;
                int rawPenalty = unitPenalty * (missing.Count + extra.Count);

                int maxPenalty = (int)(order.BasePrice * 0.8);
                int finalPenalty = Math.Min(rawPenalty, maxPenalty);

                earned -= finalPenalty;

                if (earned < 0) earned = 0;

            }

            // 햄북스딱스를 제대로 주지 않은 경우 0원
            if (order.Comment.StartsWith("햄부기햄북"))
            {
                if (order.Comment.StartsWith("햄부기햄북") && (missing.Count > 0 || extra.Count > 0 || !orderCorrect))
                {
                    return (0, "햄부기햄북 햄북어 햄북스딱스 함부르크햄부가우가 햄비기햄부거 햄부가티햄부기온앤 온을 차려오라고 하지 않았느냐!");
                }
            }

            // 완벽한경우
            if (comment == null && earned == order.BasePrice) comment = "완벽해요!";


            if (earned == order.BasePrice)
            {
                HambugiGameForm.bugerimage = Properties.Resources.hamburger_best;
            }
            else if (earned < order.BasePrice * 0.3)
            {
                HambugiGameForm.bugerimage = Properties.Resources.hamburger_cheap;
            }
            else if (earned < order.BasePrice * 0.8)
            {
                HambugiGameForm.bugerimage = Properties.Resources.hamburger;
            }

            return (earned, comment);
        }
    }
}

