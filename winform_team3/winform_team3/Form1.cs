using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace winform_team3
{
    public partial class Form1 : Form
    {
        menuPanel.cursorSc cursorSc = new menuPanel.cursorSc();
        menuPanel.taskbarSc taskbarSc = new menuPanel.taskbarSc();
        menuPanel.wallpaperSc wallpaperSc = new menuPanel.wallpaperSc();
        menuPanel.windowSc windowSc = new menuPanel.windowSc();
        menuPanel.homeSc homeSc = new menuPanel.homeSc();

        public static void SetDoubleBuffering(System.Windows.Forms.Control control, bool value)
        {
            System.Reflection.PropertyInfo controlProperty = typeof(System.Windows.Forms.Control).GetProperty("DoubleBuffered",
            System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            controlProperty.SetValue(control, value, null);
        }

        public Form1()
        {
            InitializeComponent();
            SetDoubleBuffering(homeSc, true);
            SetDoubleBuffering(windowSc, true);
            SetDoubleBuffering(taskbarSc,true);
            SetDoubleBuffering(wallpaperSc,true);
            SetDoubleBuffering(cursorSc,true);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panel1.SuspendLayout();
            pMain.SuspendLayout();
            panel1.BackgroundImage = Properties.Resources._5;
            panel1.BackgroundImageLayout = ImageLayout.Stretch;
            pMain.Controls.Add(homeSc);
            panel1.ResumeLayout(true);
            pMain.ResumeLayout(true);
        }


        private void wpbtn_Click(object sender, EventArgs e)
        {
            panel1.SuspendLayout();
            pMain.SuspendLayout();
            panel1.BackgroundImage = Properties.Resources._1;
            pMain.Controls.Clear();
            pMain.Controls.Add(wallpaperSc);
            panel1.ResumeLayout(true);
            pMain.ResumeLayout(true);
        }

        private void tbbtn_Click(object sender, EventArgs e)
        {
            panel1.SuspendLayout();
            pMain.SuspendLayout();
            panel1.BackgroundImage = Properties.Resources._2;
            pMain.Controls.Clear();
            pMain.Controls.Add(taskbarSc);
            panel1.ResumeLayout(true);
            pMain.ResumeLayout(true);
        }

        private void wdbtn_Click(object sender, EventArgs e)
        {
            panel1.SuspendLayout();
            pMain.SuspendLayout();
            panel1.BackgroundImage = Properties.Resources._3;
            pMain.Controls.Clear();
            pMain.Controls.Add(windowSc);
            panel1.ResumeLayout(true);
            pMain.ResumeLayout(true);
        }

        private void csbtn_Click(object sender, EventArgs e)
        {
            panel1.SuspendLayout();
            pMain.SuspendLayout();
            panel1.BackgroundImage = Properties.Resources._4;
            pMain.Controls.Clear();
            pMain.Controls.Add(cursorSc);
            panel1.ResumeLayout(true);
            pMain.ResumeLayout(true);
        }

        private void homebtn_Click(object sender, EventArgs e)
        {
            panel1.SuspendLayout();
            pMain.SuspendLayout();
            panel1.BackgroundImage = Properties.Resources._5;
            pMain.Controls.Clear();
            pMain.Controls.Add(homeSc);
            panel1.ResumeLayout(true);
            pMain.ResumeLayout(true);
        }

    }
    
}
