using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client.classes
{
    public class CodePracticeResult : EventArgs
    {
        public int TypingSpeed { get; set; }     // 타수TB.Text 값
        public int Accuracy { get; set; }        // 정확도TB.Text 값

        public CodePracticeResult(int typingSpeed, int accuracy)
        {
            TypingSpeed = typingSpeed;
            Accuracy = accuracy;
        }
    }
}
