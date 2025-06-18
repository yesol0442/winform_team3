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
    public partial class PlaceIngredientBlockUI : UserControl, ICloneable
    {
        public bool CanDrag { get; set; } = true;
        public string DragTag { get; protected set; } = "PlaceIngredientBlockUI";
        public PlaceIngredientBlockUI()
        {
            InitializeComponent();
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
        public object Clone() => new PlaceIngredientBlockUI();
    }
}
