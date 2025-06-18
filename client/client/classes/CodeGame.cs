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

        public string PlayerId { get; set; }  // 플레이어 구분

        public int Score { get; set; }  // 점수

        //public override string ToString() => $"{Type} {Line} {Col} {PlayerId}";

        public override string ToString()
        {
            if (Type == "CLICK")
                return $"{Type} {Line} {Col} {PlayerId}";
            else if (Type == "END")
                return $"{Type} {Score} {PlayerId}";
            return Type;
        }


        public static CodeGame Parse(string raw)
        {
            var parts = raw.Split(' ');
            var gm = new CodeGame { Type = parts[0] };

            if (gm.Type == "CLICK")
            {
                gm.Line = int.Parse(parts[1]);
                gm.Col = int.Parse(parts[2]);
                gm.PlayerId = parts[3];
            }
            else if (gm.Type == "END")
            {
                gm.Score = int.Parse(parts[1]);
                gm.PlayerId = parts[2];
            }

            return gm;
        }
    }
}
