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
    public abstract partial class BlockBase : UserControl
    {
        // 전역 FocusManager가 나를 가리키면 true
        public bool IsFocused => FocusManager.Current == this;

        protected BlockBase()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer, true);
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            FocusManager.Set(this);   // 이제 정상 컴파일
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            var back = IsFocused ? Brushes.Gold : Brushes.LightGray;
            e.Graphics.FillRectangle(back, ClientRectangle);

            TextRenderer.DrawText(e.Graphics, Text, Font, ClientRectangle, Color.Black, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }
        // Drag 시작: MouseDown 저장 → MouseMove 거리체크
    }

    public class ActionBlock : BlockBase
    {
        public enum ActionType { Grill, Chop, Wait, Assemble, Repeat }
        public ActionType Type { get; }
        public int Parameter { get; set; }  // Wait 초, Repeat 횟수
        public ActionBlock(ActionType type) => (Type, Text) = (type, type.ToString());
    }

    public class IngredientBlock : BlockBase
    {
        public IngredientType Ingredient { get; }
        public IngredientBlock(IngredientType ing)
        {
            Ingredient = ing;
            Text = ing.ToString();
        }
    }
}