using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace client.quizForm
{
    public partial class quizForm : Form
    {
        //퀴즈 데이터 형식은 {string 문제}, {string 정답}
        //2차원 리스트에 저장
        Dictionary<string, string> questions = new Dictionary<string, string>()
        {
            { "[Test]Q.정답은 O 입니다. O/X", "O" },
            { "[Test]Q.정답은 X 입니다. O/X", "X" }
        };

        List<string> questionList;

        //들어온 순서대로 1p, 2p, 3p, 4p가 정해짐
        //화면을 보고 있는 플레이어가 몇p인지 나타내는 변수 필요
        //ready화면에서 받아와야할듯?
        public int playerNum = 0; //배열 인덱스 생각해서, 실제 번호 -1 로 할까
        public int playerScore = 0;
        public string yourAnswer = ""; //이번에 입력한 정답.

        public quizForm()
        {
            InitializeComponent();
            questionList = new List<string>(questions.Keys);

            PictureBox[] playerPics = { playerPic1, playerPic2, playerPic3, playerPic4 };
            Label[] playerScores = { playerScore1, playerScore2, playerScore3, playerScore4 };
            Label[] playerPlus = { player1Plus, player2Plus, player3Plus, player4Plus };

            PictureBox[] speechBubbles = { pic_sb1, pic_sb2, pic_sb3, pic_sb4 };
            Label[] playerAnswers = { playerAnswer1, playerAnswer2, playerAnswer3, playerAnswer4 };
            for (int i = 0; i < 4; i++)
            {
                playerPlus[i].Visible = false;
                playerAnswers[i].Visible = false;
                speechBubbles[i].Visible = false;
            }

            playerScores[playerNum].Text = playerScore.ToString();
            txt_question.Text = questionList[0];
            answerReadyTimer.Enabled = true;
        }

        private void txt_answer_KeyDown(object sender, KeyEventArgs e)
        {
            Label[] playerAnswers = { playerAnswer1, playerAnswer2, playerAnswer3, playerAnswer4 };
            PictureBox[] speechBubbles = { pic_sb1, pic_sb2, pic_sb3, pic_sb4 };
            if (e.KeyCode == Keys.Enter)
            {
                if (txt_answer.Text != "")
                {
                    yourAnswer = txt_answer.Text;
                    playerAnswers[playerNum].Text = yourAnswer;
                    playerAnswers[playerNum].Visible = true;
                    speechBubbles[playerNum].Visible = true;
                    txt_answer.Enabled = false;
                    //다른 클라이언트에게도 결과 전송
                }
            }
        }

        private void checkAnswer()
        {
            Label[] playerScores = { playerScore1, playerScore2, playerScore3, playerScore4 };
            Label[] playerAnswers = { playerAnswer1, playerAnswer2, playerAnswer3, playerAnswer4 };
            Label[] playerPlus = { player1Plus, player2Plus, player3Plus, player4Plus };
            if (yourAnswer == questions[txt_question.Text]) //맞은경우
            {
                playerAnswers[playerNum].ForeColor = Color.Blue;

                playerPlus[playerNum].Text = "+10"; //맞춘순서에 따른 점수차등 생각중
                playerScore += 10;

                playerPlus[playerNum].Visible = true;
                playerScores[playerNum].Text = playerScore.ToString();
            }
            else
            {
                playerAnswers[playerNum].ForeColor = Color.Red;
            }
        }

        private void answerReadyTimer_Tick(object sender, EventArgs e)
        {
            txt_answer.Enabled = false;
            checkAnswer();
            answerReadyTimer.Enabled = false;

            /*
             * 클라이언트마다 종료 시점이 다를 것 같아서,
             * 시간이 다 되면 서버로 종료 알림을 보내고
             * 네 명의 플레이어가 모두 종료 알림을 보낸 게 확인되면 
             * 그때 CheckAnswer()을 일괄적으로 호출하도록 하자
             */

        }
    }
}
