using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client.quizForm
{
    public class PlayerResult
    {
        public int Rank { get; set; }
        public int Player { get; set; }
        public int Score { get; set; }

        public PlayerResult(int rank, int player, int score)
        {
            Rank = rank;
            Player = player;
            Score = score;
        }
    }
}
