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
    public partial class IngredientBlockUI : UserControl, ICloneable
    {
        public bool CanDrag { get; set; } = true;
        public string DragTag { get; protected set; } = "IngredientBlockUI";
        public Image image = null;
        public IngredientBlockUI(Image im)
        {
            InitializeComponent();
            pictureBox1.Image = im;
            MouseDown += OnMouseDownStartDrag;
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
        public object Clone() => new IngredientBlockUI(image);
    }
}
