using client.BlockForm;
using client.classes;
using client.classes.NetworkManager;
using client.menuControl;
using client.RainForm;
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

        private string currentLanguage = "C";

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
            this.환경설정.LanguageChanged += MainForm_LanguageChanged;
            this.미니게임.RainButtonClicked += OnRainGameRequested;
            this.미니게임.BlockButtonClicked += OnBLockGameRequested;

            // 폼 크기 고정
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;

        }

        private void MainForm_LanguageChanged(object sender, LanguageChangedEventArgs e)
        {
            currentLanguage = e.SelectedLanguage;
        }

        private void OnRainGameRequested(object sender, EventArgs e)
        {
            rainMain form = new rainMain(currentLanguage);
            form.Show();
        }

        private void OnBLockGameRequested(object sender, EventArgs e)
        {
            BlockStart form = new BlockStart(currentLanguage);
            form.Show();
        }

        private void 나가기_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 내림_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private async void 홈_Click(object sender, EventArgs e)
        {
            홈.BringToFront();
            홈.Show();

            try
            {
                // 로그인한 사용자 ID로 최신 정보 다시 불러오기
                await 홈.LoadUserStats(UserSession.Instance.UserId);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"홈 화면 정보 갱신 실패: {ex.Message}");
            }

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

        private async void LoginPage_LoginSuccess(object sender, 초기화면.LoginSuccessEventArgs e)
        {
            EnableMenuButtons();

            UserSession.Instance.SetUserId(e.UserId);

            try
            {
                // 로그인 성공 시 UserId 전달해서 초기화 메서드 호출
                await 홈.LoadUserStats(UserSession.Instance.UserId);
                환경설정.currentUserId = UserSession.Instance.UserId;
                await 환경설정.SetCurrentUserIdAsync(UserSession.Instance.UserId);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[클라이언트] 홈 초기화 중 오류 발생: {ex.Message}");
                MessageBox.Show("홈 초기화 중 오류가 발생했습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            btn홈.PerformClick();
        }

    }
}
