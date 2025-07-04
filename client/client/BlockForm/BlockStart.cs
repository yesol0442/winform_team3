﻿using Guna.UI2.WinForms.Enums;
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
    public partial class BlockStart : Form
    {
        private string lang;
        Form1 parentForm;

        public BlockStart(Form1 main, string language)
        {
            InitializeComponent();
            parentForm = main;
            lang = language;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            BlockGame blockGame = new BlockGame(parentForm, lang);
            blockGame.Show();
        }

        private void btnTutorial_Click(object sender, EventArgs e)
        {
            BlockTutorial tutorial = new BlockTutorial();
            tutorial.Owner = this;
            tutorial.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
