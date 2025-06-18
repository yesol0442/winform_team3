using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace client.HambugiGame.Controls
{
    public partial class RepeatBlockUI : UserControl, ICloneable
    {
        public bool CanDrag { get; set; } = true;
        public string DragTag { get; protected set; } = "RepeatBlockUI";

        public RepeatBlockUI()
        {
            InitializeComponent();

            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;

            MouseDown += OnMouseDownStartDrag;

            DragEnter += A_DragEnter;
            DragLeave += (s, e) => Invalidate();
            DragDrop += A_DragDrop;
        }

        private void OnMouseDownStartDrag(object sender, MouseEventArgs e)
        {
            if (!CanDrag) return;
            if (e.Button != MouseButtons.Left) return;

            var data = new DataObject();
            data.SetData(DataFormats.StringFormat, DragTag);
            data.SetData(typeof(ICloneable), this);

            DoDragDrop(data, DragDropEffects.Copy);
        }
        public object Clone() => new RepeatBlockUI();

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!CanDrag) return;
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void A_DragEnter(object sender, DragEventArgs e)
        {
            if (CanDrag) return;
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
            if (CanDrag) return;
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
