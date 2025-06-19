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
    public partial class AssembleBlockUI : UserControl, ICloneable, IDataGettable, IDraggableBlock
    {
        public bool CanDrag { get; set; } = true;
        public string DragTag { get; protected set; } = "Default";

        public AssembleBlockUI()
        {
            InitializeComponent();
            DragTag = "AssembleBlockUI";
            MouseDown += OnMouseDownStartDrag;
            label1.MouseDown += OnMouseDownStartDrag;
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
        public object Clone() => new AssembleBlockUI();

        public void GetData()
        {
            UserBlockParser.Ham.Add("| Assemble |");
        }

    }
}

