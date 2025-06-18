using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace client.FindDifferForm
{
    public partial class FindEnd : Form
    {
        string result;
        Form1 Form1;
        float result2;
        

        public FindEnd(string resultMessage, string result, Form1 form1)
        {
            InitializeComponent();

            this.Form1 = form1;

            this.result = result;

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.Text = "게임 결과";

            lbResult.Text = resultMessage;
            Form1 = form1;

            if (result == "승리")
            {
                result2 = 1;

            }
            else if (result == "패배")
            {
                result2 = 0;
            }
            else
            {
                result2 = 2;
            }

            OnGameEnd(form1);
        }


        private void btnEnd_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private async void OnGameEnd(Form1 form)
        {
            await form.SaveCodeFindResult(result2);

        }
    }
}
