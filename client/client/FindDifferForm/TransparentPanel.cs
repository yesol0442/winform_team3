using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace client.FindDifferForm
{
    internal class TransparentPanel:Panel
    {
        public TransparentPanel()
        {
            // 투명 배경 지원 플래그 설정
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.BackColor = Color.Transparent;
        }

        // 윈도우 스타일 확장: WS_EX_TRANSPARENT
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x20; // WS_EX_TRANSPARENT
                return cp;
            }
        }

        // 배경 그리기 생략 → 진짜 투명 효과
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            // 아무것도 그리지 않음
        }
    }
}
