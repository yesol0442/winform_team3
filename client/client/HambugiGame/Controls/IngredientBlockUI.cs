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
    public partial class IngredientBlockUI : UserControl
    {
        public IngredientBlockUI(Image image)
        {
            InitializeComponent();
            pictureBox1.Image = image;
        }
    }
}
