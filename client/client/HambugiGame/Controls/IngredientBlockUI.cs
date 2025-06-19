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
    public partial class IngredientBlockUI : UserControl, ICloneable, IDraggableBlock
    {
        public bool CanDrag { get; set; } = true;
        public string DragTag { get; protected set; } = "IngredientBlockUI";
        public Image image = null;
        public IngredientType IngredientName = 0;
        public IngredientBlockUI(Image im, IngredientType ingredientName)
        {
            InitializeComponent();
            pictureBox1.Image = im;
            image = im;
            MouseDown += OnMouseDownStartDrag;
            pictureBox1.MouseDown += OnMouseDownStartDrag;
            IngredientName = ingredientName;
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
        public object Clone() => new IngredientBlockUI(image, IngredientName);
    }
}