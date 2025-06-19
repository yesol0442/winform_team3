using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client.HambugiGame
{
    public static class UserBlockParser
    {
        public static List<string> Ham = new List<string>();
    }
    public interface IDataGettable
    {
        void GetData();
    }
    public interface IDraggableBlock
    {
        bool CanDrag { get; set; }
    }

    public class GrillSlot
    {
        public GrillSlot(Ingredient ingredient)
        {
            Ingredient = ingredient;
        }

        public Ingredient Ingredient { get; set; }
        public int Elapsed { get; set; }
    }

    public class CookingContext
    {
        public List<Ingredient> Workbench { get; } = new List<Ingredient>();
        public List<GrillSlot> Grill { get; } = new List<GrillSlot>();
        public Burger Output { get; set; } = new Burger();
        public bool Finished { get; set; }
    }


    public abstract class Command
    {
        public abstract void Execute(CookingContext ctx);
    }

    public class PlaceIngredientCmd : Command
    {
        private readonly IngredientType _type;
        public PlaceIngredientCmd(IngredientType type) { _type = type; }

        public override void Execute(CookingContext ctx)
        {
            if (_type == IngredientType.Null)
            {
                Console.WriteLine("[Place] Null 건너뜀");
                return;
            }
            ctx.Workbench.Add(new Ingredient(_type));
            Console.WriteLine($"[Place] {_type} 작업대에 추가. 총 {ctx.Workbench.Count}개");
        }
    }

    public class GrillCmd : Command
    {
        private readonly IngredientType _type;
        public GrillCmd(IngredientType type) { _type = type; }

        public override void Execute(CookingContext ctx)
        {
            var ing = ctx.Workbench.FirstOrDefault(i => i.Type == _type);
            if (ing != null)
            {
                ctx.Workbench.Remove(ing);
                ctx.Grill.Add(new GrillSlot(ing));
                Console.WriteLine($"[Grill] {_type} 그릴에 올림. 그릴 {ctx.Grill.Count}칸");
            }
        }
    }

    public class WaitCmd : Command
    {
        private readonly int _seconds;
        public WaitCmd(int seconds) { _seconds = seconds; }

        public override void Execute(CookingContext ctx)
        {
            var doneSlots = new List<GrillSlot>();

            foreach (var slot in ctx.Grill)
            {
                slot.Elapsed += _seconds;

                if (slot.Elapsed >= 5)
                {
                    slot.Ingredient.CookState = CookState.Burnt;
                    slot.Ingredient.Type = IngredientType.PattyBurnt;
                    doneSlots.Add(slot);
                    Console.WriteLine($"[Wait {_seconds}s] Burnt 완성");
                }
                else if (slot.Elapsed >= 3)
                {
                    slot.Ingredient.CookState = CookState.Medium;
                    slot.Ingredient.Type = IngredientType.PattyMedium;
                    doneSlots.Add(slot);
                    Console.WriteLine($"[Wait {_seconds}s] Medium 완성");
                }
                else
                {
                    slot.Ingredient.CookState = CookState.Raw;
                    Console.WriteLine($"[Wait {_seconds}s] Raw 진행 중");

                }
            }

            foreach (var slot in doneSlots)
            {
                ctx.Grill.Remove(slot);
                ctx.Workbench.Add(slot.Ingredient);
                Console.WriteLine($"    ↳ 작업대로 이동. 현재 작업대 {ctx.Workbench.Count}개");
            }
        }
    }

    public class AssembleCmd : Command
    {
        public override void Execute(CookingContext ctx)
        {
            var burger = new Burger();
            foreach (var ing in ctx.Workbench)
                burger.AddIngredient(ing);

            ctx.Output = burger;

            Console.WriteLine($"[Assemble] 버거 완성 층수 {burger.Layers.Count}");

            ctx.Workbench.Clear();
            ctx.Grill.Clear();
            ctx.Finished = true;
        }
    }


    public static class HamParser
    {
        public static List<Command> Parse(IEnumerable<string> rawLines)
        {
            var result = new List<Command>();
            var repeatStack = new Stack<Tuple<int, List<Command>>>();

            foreach (var raw in rawLines)
            {
                var text = raw.Trim('|', ' ').Trim();
                if (text.Length == 0) continue;

                var parts = text.Split(new[] { ' ' }, 2, StringSplitOptions.RemoveEmptyEntries);
                var head = parts[0];

                if (head == "RepeatStart")
                {
                    int n = int.Parse(parts[1]);
                    repeatStack.Push(Tuple.Create(n, new List<Command>()));
                    continue;
                }

                if (head == "RepeatEnd")
                {
                    var tuple = repeatStack.Pop();
                    for (int i = 0; i < tuple.Item1; i++)
                    {
                        if (repeatStack.Any())
                            repeatStack.Peek().Item2.AddRange(tuple.Item2);
                        else
                            result.AddRange(tuple.Item2);
                    }
                    continue;
                }

                Command cmd = CreateCommand(head, parts.Length > 1 ? parts[1] : null);

                if (repeatStack.Any())
                    repeatStack.Peek().Item2.Add(cmd);
                else
                    result.Add(cmd);
            }

            return result;
        }

        private static Command CreateCommand(string head, string arg)
        {
            switch (head)
            {
                case "PlaceIngredient":
                    return new PlaceIngredientCmd(
                        (IngredientType)Enum.Parse(typeof(IngredientType), arg));

                case "Grill":
                    return new GrillCmd(
                        (IngredientType)Enum.Parse(typeof(IngredientType), arg));

                case "Wait":
                    return new WaitCmd(int.Parse(arg));

                case "Assemble":
                    return new AssembleCmd();

                default:
                    throw new InvalidOperationException("Unknown command: " + head);
            }
        }
    }

    public static class HamExecutor
    {
        public static Burger Cook(IEnumerable<Command> commands)
        {
            var ctx = new CookingContext();

            foreach (var cmd in commands)
            {
                if (ctx.Finished) break;
                cmd.Execute(ctx);
            }
            return ctx.Output;
        }
    }
}
