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
        public BlockResult(int result)
        {
            InitializeComponent();
            this.result = result;

            result_current.Text = result + "초";
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
