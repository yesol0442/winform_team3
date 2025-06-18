using client.HambugiGame.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace client.HambugiGame
{
    public partial class HambugiGameForm : Form
    {
        AssembleBlockUI 조립하기블록 = new AssembleBlockUI();
        GrillBlockUI 가열하기블록 = new GrillBlockUI();
        IngredientBlockUI 케첩 = new IngredientBlockUI(Properties.Resources.ketchup, IngredientType.Ketchup);
        PlaceIngredientBlockUI 올리기블록 = new PlaceIngredientBlockUI();
        RepeatBlockUI 반복하기블록 = new RepeatBlockUI();
        WaitBlockUI 기다리기블록 = new WaitBlockUI();

        public HambugiGameForm()
        {
            InitializeComponent();
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.DragEnter += A_DragEnter;
            flowLayoutPanel1.DragLeave += (s, e) => Invalidate();
            flowLayoutPanel1.DragDrop += A_DragDrop;
        }

        void controlInit()
        {




        }

        private void A_DragEnter(object sender, DragEventArgs e)
        {
            bool isOk = false;

            if (e.Data.GetDataPresent(DataFormats.StringFormat))
            {
                string tag = e.Data.GetData(DataFormats.StringFormat) as string;
                isOk = (tag != "IngredientBlockUI");
            }

            e.Effect = isOk ? DragDropEffects.Copy : DragDropEffects.None;
            if (isOk) Invalidate();
        }

        private void A_DragDrop(object sender, DragEventArgs e)
        {
            Invalidate();

            string tag = e.Data.GetData(DataFormats.StringFormat) as string;
            if (tag == "IngredientBlockUI") return;


            var src = e.Data.GetData(typeof(ICloneable)) as ICloneable;
            var copy = src.Clone() as Control;
            flowLayoutPanel1.Controls.Add(copy);


            Point pt = PointToClient(new Point(e.X, e.Y));
            pt.Offset(-copy.Width / 2, -copy.Height / 2);
            copy.Location = pt;
            flowLayoutPanel1.Controls.Add(copy);
        }
    }
}
