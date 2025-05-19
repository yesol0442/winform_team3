using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client.classes
{
    internal class CodeGame
    {
        public string Type { get; set; } // 메시지 종류 (예: "CLICK")
        public int Line { get; set; }     // 줄 번호
        public int Col { get; set; }      // 열 번호 (문자 인덱스)

        public override string ToString() => $"{Type} {Line} {Col}";

        public static CodeGame Parse(string raw)
        {
            var parts = raw.Split(' ');
            return new CodeGame { Type = parts[0], Line = int.Parse(parts[1]), Col = int.Parse(parts[2]) };
        }
    }
}
