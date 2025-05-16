using client.classes.NetworkManager;
using client.menuControl;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using static Guna.UI2.Native.WinApi;
using client.classes.NetworkManager;

namespace client
{
    public partial class Form1 : Form
    {
        private Guna2BorderlessForm borderlessForm;
        private menuControl.홈 홈 = new menuControl.홈();
        private new menuControl.미니게임 미니게임 = new menuControl.미니게임();
        private menuControl.코드연습 코드연습 = new menuControl.코드연습();
        private menuControl.환경설정 환경설정 = new menuControl.환경설정();
        private new menuControl.PVP PVP = new menuControl.PVP();
        private new menuControl.초기화면 초기화면 = new menuControl.초기화면();
        private Guna.UI2.WinForms.Guna2Button currentSelectedButton = null;
        public Form1()
        {
            InitializeComponent();

            borderlessForm = new Guna2BorderlessForm();
            borderlessForm.ContainerControl = this;
            borderlessForm.BorderRadius = 10;
            borderlessForm.HasFormShadow = false;
            borderlessForm.TransparentWhileDrag = false;
            borderlessForm.DockIndicatorTransparencyValue = 0.0f;
            borderlessForm.ResizeForm = false;

            guna2Panel1.Controls.Add(PVP);
            guna2Panel1.Controls.Add(미니게임);
            guna2Panel1.Controls.Add(코드연습);
            guna2Panel1.Controls.Add(홈);
            guna2Panel1.Controls.Add(환경설정);
            guna2Panel1.Controls.Add(초기화면);

            초기화면.LoginSuccess += LoginPage_LoginSuccess; // 로그인 이벤트 핸들러 설정

            // 폼 크기 고정
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;

        }

        private void 나가기_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 내림_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void 홈_Click(object sender, EventArgs e)
        {
            홈.BringToFront();
            홈.Show();
            메뉴버튼_Click(sender, e);
        }

        private void 코드연습_Click(object sender, EventArgs e)
        {
            코드연습.BringToFront();
            코드연습.Show();
            메뉴버튼_Click(sender, e);
        }

        private void PVP_Click(object sender, EventArgs e)
        {
            PVP.BringToFront();
            PVP.Show();
            메뉴버튼_Click(sender, e);
        }

        private void 미니게임_Click(object sender, EventArgs e)
        {
            미니게임.BringToFront();
            미니게임.Show();
            메뉴버튼_Click(sender, e);
        }

        private void 환경설정_Click(object sender, EventArgs e)
        {
            환경설정.BringToFront();
            환경설정.Show();
            메뉴버튼_Click(sender, e);
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                await NetworkManager.Instance.ConnectAsync("127.0.0.1", 5000);

                // 연결 성공 시 초기화면 표시 및 메뉴 비활성화
                초기화면.BringToFront();
                초기화면.Show();
                DisableMenuButtons();
            }
            catch (Exception ex)
            {
                MessageBox.Show("서버 연결 실패: " + ex.Message);
                // 연결 실패 처리: 재접속 유도 or 앱 종료 등
            }

        }

        private void 메뉴버튼_Click(object sender, EventArgs e)
        {
            var clickedButton = sender as Guna.UI2.WinForms.Guna2Button;

            if (currentSelectedButton != null && currentSelectedButton != clickedButton)
            {
                currentSelectedButton.ForeColor = Color.DimGray;
            }

            clickedButton.ForeColor = Color.Orange;
            currentSelectedButton = clickedButton;
        }

        private void DisableMenuButtons()
        {
            btn홈.Enabled = false;
            btnPVP.Enabled = false;
            btn미니게임.Enabled = false;
            btn코드연습.Enabled = false;
            btn환경설정.Enabled = false;
        }

        private void EnableMenuButtons()
        {
            btn홈.Enabled = true;
            btnPVP.Enabled = true;
            btn미니게임.Enabled = true;
            btn코드연습.Enabled = true;
            btn환경설정.Enabled = true;
        }

        private void LoginPage_LoginSuccess(object sender, EventArgs e)
        {
            EnableMenuButtons();

            btn홈.PerformClick();
        }

    }
}
