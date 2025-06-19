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
    public partial class GrillBlockUI : UserControl, ICloneable, IDataGettable, IDraggableBlock
    {

        public bool CanDrag { get; set; } = true;
        public string DragTag { get; protected set; } = "GrillBlockUI";
        public IngredientType Ingredient = 0;
        public GrillBlockUI()
        {
            InitializeComponent();
            MouseDown += OnMouseDownStartDrag;
            label1.MouseDown += OnMouseDownStartDrag;
            pictureBox1.MouseDown += OnMouseDownStartDrag;
            AllowDrop = true;

            DragEnter += A_DragEnter;
            DragLeave += (s, e) => Invalidate();
            DragDrop += A_DragDrop;

            pictureBox1.DragEnter += A_DragEnter;
            pictureBox1.DragLeave += (s, e) => Invalidate();
            pictureBox1.DragDrop += A_DragDrop;

            label1.DragEnter += A_DragEnter;
            label1.DragLeave += (s, e) => Invalidate();
            label1.DragDrop += A_DragDrop;
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
        public object Clone() => new GrillBlockUI();

        private void A_DragEnter(object sender, DragEventArgs e)
        {
            if (CanDrag) return;
            bool isOk = false;

            if (e.Data.GetDataPresent(DataFormats.StringFormat))
            {
                string tag = e.Data.GetData(DataFormats.StringFormat) as string;
                isOk = tag == "IngredientBlockUI";
            }

            e.Effect = isOk ? DragDropEffects.Copy : DragDropEffects.None;
            if (isOk) Invalidate();
        }

        private void A_DragDrop(object sender, DragEventArgs e)
        {
            if (CanDrag) return;
            Invalidate();

            string tag = e.Data.GetData(DataFormats.StringFormat) as string;
            if (tag != "IngredientBlockUI") return;

            var cloneable = e.Data.GetData(typeof(ICloneable)) as ICloneable;
            if (cloneable == null) return;

            var src = cloneable.Clone() as IngredientBlockUI;
            if (src == null) return;

            pictureBox1.Image = src.image;
            Ingredient = src.IngredientName;
        }
        public void GetData()
        {
            UserBlockParser.Ham.Add("| Grill " + Ingredient.ToString() + " |");
        }


    }
}

