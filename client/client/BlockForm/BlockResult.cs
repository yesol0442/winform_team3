using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace client.BlockForm
{
    public partial class BlockResult : Form
    {
        private int result;
        public BlockResult(int result, Form1 main)
        {
            InitializeComponent();
            this.result = result;

            result_current.Text = result + "초";
            if (main == null)
            {
                MessageBox.Show("오류 발생! main폼이 null 입니다.");
            }
            OnGameEnd(main);
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void OnGameEnd(Form1 mainForm)
        {
            await mainForm.SaveBlockResult(result);
            MessageBox.Show("점수가 저장되었습니다.");
        }
    }
}
