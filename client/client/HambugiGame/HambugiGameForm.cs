using client.classes;
using client.HambugiGame.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.Design.AxImporter;


namespace client.HambugiGame
{
    public partial class HambugiGameForm : Form
    {
        IngredientBlockUI 케첩 = new IngredientBlockUI(Properties.Resources.ketchup, IngredientType.Ketchup);
        IngredientBlockUI 빵아래 = new IngredientBlockUI(Properties.Resources.bread_bottom, IngredientType.BunBottom);
        IngredientBlockUI 덜익은패티 = new IngredientBlockUI(Properties.Resources.patty_raw, IngredientType.PattyRaw);
        IngredientBlockUI 치즈 = new IngredientBlockUI(Properties.Resources.cheese, IngredientType.Cheese);
        IngredientBlockUI 양상추 = new IngredientBlockUI(Properties.Resources.lettuce, IngredientType.Lettuce);
        IngredientBlockUI 토마토 = new IngredientBlockUI(Properties.Resources.tomato, IngredientType.Tomato);
        IngredientBlockUI 양파 = new IngredientBlockUI(Properties.Resources.onion, IngredientType.Onion);
        IngredientBlockUI 피클 = new IngredientBlockUI(Properties.Resources.pickle, IngredientType.Pickle);
        IngredientBlockUI 빵위 = new IngredientBlockUI(Properties.Resources.bread_top, IngredientType.BunTop);
        IngredientBlockUI 마요네즈 = new IngredientBlockUI(Properties.Resources.mayo, IngredientType.Mayonnaise);
        IngredientBlockUI 머스타드 = new IngredientBlockUI(Properties.Resources.mustard, IngredientType.Mustard);
        IngredientBlockUI 데리야끼소스 = new IngredientBlockUI(Properties.Resources.deriyakki, IngredientType.TeriyakiSauce);
        IngredientBlockUI 바베큐소스 = new IngredientBlockUI(Properties.Resources.bbq, IngredientType.BarbecueSauce);


        PlaceIngredientBlockUI 올리기블록 = new PlaceIngredientBlockUI();
        RepeatBlockUI 반복하기블록 = new RepeatBlockUI();
        WaitBlockUI 기다리기블록 = new WaitBlockUI();
        AssembleBlockUI 조립하기블록 = new AssembleBlockUI();
        GrillBlockUI 가열하기블록 = new GrillBlockUI();

        List<Order> orders = new List<Order>();
        OrderGenerator orderGen = new OrderGenerator();

        public static Image bugerimage = Properties.Resources.hamburger_cheap;

        private Control _selectedBlock;

        Order selected = null;

        private PictureBox _lastSelectedPB;
        const int boxWidth = 60;
        const int boxHeight = 60;

        private const int WM_USER = 0x0400;
        private const int PBM_SETSTATE = WM_USER + 16;
        private const int PBM_SETBARCOLOR = WM_USER + 9;
        private const int PBST_NORMAL = 1;
        private const int PBST_ERROR = 2;
        private const int PBST_PAUSED = 3;

        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr w, IntPtr l);

        [DllImport("uxtheme.dll", CharSet = CharSet.Unicode)]
        private static extern int SetWindowTheme(IntPtr hWnd, string pszSubAppName, string pszSubIdList);

        private const int TotalSec = 3000;
        private int _remain = TotalSec;

        private readonly Dictionary<Control, Color> _origColor = new Dictionary<Control, Color>();

        public HambugiGameForm()
        {
            InitializeComponent();
            SoundManager.PlaySoundLoop(@"..\..\Resources\hamburger.wav");
            this.DoubleBuffered = true;
            EnableDoubleBufferRecursive(this);
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
            button1.Enabled = false;

            button1.BackgroundImage = Properties.Resources.button_enable;
            button1.BackgroundImageLayout = ImageLayout.Stretch;
            음식만들기Bt.BackgroundImage = Properties.Resources.button_enable;
            음식만들기Bt.BackgroundImageLayout = ImageLayout.Stretch;

            말풍선P.BackgroundImage = Properties.Resources.bubble;
            말풍선P.BackgroundImageLayout = ImageLayout.Stretch;
            orderPanel.BackgroundImage = Properties.Resources.order;
            orderPanel.BackgroundImageLayout = ImageLayout.Stretch;
            BackgroundImage = Properties.Resources.burger_background;
            BackgroundImageLayout = ImageLayout.Stretch;

            flowLayoutPanel1.WrapContents = false;
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.AllowDrop = true;
            flowLayoutPanel1.ControlAdded += FlowPanel_Changed;
            flowLayoutPanel1.ControlRemoved += FlowPanel_Changed;
            orderQueue.FlowDirection = FlowDirection.LeftToRight;
            IngredientBP.FlowDirection = FlowDirection.TopDown;
            actionBP.FlowDirection = FlowDirection.TopDown;

            flowLayoutPanel1.DragEnter += A_DragEnter;
            flowLayoutPanel1.DragLeave += (s, e) => Invalidate();
            flowLayoutPanel1.DragDrop += A_DragDrop;

            controlInit();


            timerProgress.Tick += timerProgress_Tick;
        }
        private void EnableDoubleBufferRecursive(Control root)
        {
            if (root is Panel)
            {
                PropertyInfo pi = root.GetType().GetProperty(
                    "DoubleBuffered",
                    BindingFlags.Instance | BindingFlags.NonPublic);

                if (pi != null)
                    pi.SetValue(root, true, null);
            }

            foreach (Control child in root.Controls)
                EnableDoubleBufferRecursive(child);
        }
        private void HambugiGameForm_Load(object sender, EventArgs e)
        {
            InitProgressBar();
        }

        private void InitProgressBar()
        {
            _remain = TotalSec;

            progressBar.Minimum = 0;
            progressBar.Maximum = TotalSec;
            progressBar.Value = TotalSec;
            progressBar.Style = ProgressBarStyle.Continuous;
            progressBar.RightToLeft = RightToLeft.Yes;
            progressBar.RightToLeftLayout = true;

            SetWindowTheme(progressBar.Handle, "", "");


            Color lightGreen = Color.FromArgb(0x66, 0xCC, 0x66);
            SendMessage(progressBar.Handle, PBM_SETBARCOLOR,
                        IntPtr.Zero, (IntPtr)ColorRef(lightGreen));


            timerProgress.Start();
        }

        private void timerProgress_Tick(object sender, EventArgs e)
        {
            if (--_remain < 0)
            {
                timerProgress.Stop();

                int earned = 0;
                if (int.TryParse(new string(수입금TB.Text.Where(char.IsDigit).ToArray()), out int v))
                {
                    earned = v;
                }

                string msg = (earned >= 10_000)
                    ? $"총 수입 {earned}원!\n   성공!   "
                    : "게임 실패!";

                MessageBox.Show(msg, "게임 결과", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                this.Close();
                return;
            }

            progressBar.Value = _remain;

            if (_remain <= 10)
            {
                SetThemeAndState("Explorer", PBST_ERROR);
            }
            else if (_remain <= 30)
            {
                SetThemeAndState("Explorer", PBST_PAUSED);
            }
            else
            {

            }
        }

        private void SetThemeAndState(string theme, int state)
        {
            SetWindowTheme(progressBar.Handle, theme, null);
            SendMessage(progressBar.Handle, PBM_SETSTATE, (IntPtr)state, IntPtr.Zero);
        }

        private int ColorRef(Color c) => c.R | (c.G << 8) | (c.B << 16);


        private void FlowPanel_Changed(object sender, ControlEventArgs e)
        {
            RefreshCookButton();
        }

        private void RefreshCookButton()
        {
            bool anyBlock = flowLayoutPanel1.Controls.OfType<Control>().Any();

            음식만들기Bt.Enabled = anyBlock;
            button1.Enabled = anyBlock;
            if (음식만들기Bt.Enabled == true)
            {
                음식만들기Bt.BackgroundImage = Properties.Resources.button;
            }
            else
            {
                음식만들기Bt.BackgroundImage = Properties.Resources.button_enable;
            }
            if (button1.Enabled == true)
            {
                button1.BackgroundImage = Properties.Resources.button;
            }
            else
            {
                button1.BackgroundImage = Properties.Resources.button_enable;
            }
        }

        void controlInit()
        {
            for (int i = 0; i < 5; i++)
            {
                var pb = new PictureBox
                {
                    Width = boxWidth,
                    Height = boxHeight,
                    BorderStyle = BorderStyle.FixedSingle,
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Tag = i,
                    Image = Properties.Resources.order,
                    BackgroundImageLayout = ImageLayout.Stretch
                };
                pb.Click += OrderSlot_Click;
                orderQueue.Controls.Add(pb);
                orders.Add(orderGen.getOrder());
            }

            IngredientBP.FlowDirection = FlowDirection.LeftToRight;
            IngredientBP.WrapContents = true;
            IngredientBP.AutoScroll = true;
            IngredientBP.Padding = new Padding(2);
            var ingredientBlocks = new[]
            {
                빵아래, 덜익은패티, 치즈, 양상추, 토마토,
                양파, 피클, 빵위, 케첩, 마요네즈, 머스타드, 데리야끼소스, 바베큐소스
            };
            IngredientBP.SuspendLayout();
            foreach (var block in ingredientBlocks)
            {
                block.Margin = new Padding(2);
                IngredientBP.Controls.Add(block);
            }
            IngredientBP.ResumeLayout();

            actionBP.FlowDirection = FlowDirection.LeftToRight;
            actionBP.WrapContents = true;
            actionBP.AutoScroll = true;
            actionBP.Padding = new Padding(2);

            Control[] actionBlocks =
            {
                올리기블록, 반복하기블록, 기다리기블록, 조립하기블록, 가열하기블록
            };

            actionBP.SuspendLayout();
            foreach (var block in actionBlocks)
            {
                block.Margin = new Padding(4);
                actionBP.Controls.Add(block);
            }
            actionBP.ResumeLayout();
            RefreshCookButton();

            if (orderQueue.Controls.Count > 0)
            {
                var firstPB = orderQueue.Controls[0] as PictureBox;
                OrderSlot_Click(firstPB, EventArgs.Empty);
            }
        }

        private void OrderSlot_Click(object sender, EventArgs e)
        {
            var pb = sender as PictureBox;
            int index = (int)pb.Tag;

            if (index < 0 || index >= orders.Count) return;

            if (_lastSelectedPB != null && _lastSelectedPB != pb)
            {
                _lastSelectedPB.BorderStyle = BorderStyle.FixedSingle;
            }
            pb.BorderStyle = BorderStyle.Fixed3D;

            _lastSelectedPB = pb;

            selected = orders[index];
            ShowOrderInfo(selected);
        }
        private void ShowOrderInfo(Order order)
        {

            lblPrice.Text = $"{order.BasePrice}" + "원";
            lblComment.Text = order.Comment;

        }

        private void A_DragEnter(object sender, DragEventArgs e)
        {
            bool isOk = false;

            if (e.Data.GetDataPresent(DataFormats.StringFormat))
            {
                string tag = e.Data.GetData(DataFormats.StringFormat) as string;
                isOk = (tag != "IngredientBlockUI");
            }

            e.Effect = isOk ? DragDropEffects.Copy : DragDropEffects.None;
            if (isOk) Invalidate();
        }

        private void A_DragDrop(object sender, DragEventArgs e)
        {
            Invalidate();

            string tag = e.Data.GetData(DataFormats.StringFormat) as string;
            if (tag == "IngredientBlockUI") return;


            var src = e.Data.GetData(typeof(ICloneable)) as ICloneable;
            var copy = src.Clone() as Control;

            if (copy is IDraggableBlock b) b.CanDrag = false;

            copy.Click += Block_Click;
            flowLayoutPanel1.Controls.Add(copy);

            Point pt = PointToClient(new Point(e.X, e.Y));
            pt.Offset(-copy.Width / 2, -copy.Height / 2);
            copy.Location = pt;
            flowLayoutPanel1.Controls.Add(copy);
        }
        private void Block_Click(object sender, EventArgs e)
        {
            var ctrl = (Control)sender;

            if (_selectedBlock != null && _selectedBlock != ctrl)
            {
                _selectedBlock.Padding = Padding.Empty;
                _selectedBlock.BackColor = _origColor[_selectedBlock];
            }

            _selectedBlock = ctrl;

            if (!_origColor.ContainsKey(ctrl)) 
                _origColor[ctrl] = ctrl.BackColor;

            _selectedBlock.Padding = new Padding(2);
            _selectedBlock.BackColor = Color.DeepSkyBlue;
        }
        private async void 음식만들기Bt_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in flowLayoutPanel1.Controls)
            {
                if (ctrl is IDataGettable data)
                    data.GetData();
            }

            List<string> hamLines = UserBlockParser.Ham;

            List<Command> commands = HamParser.Parse(hamLines);
            Burger burger = HamExecutor.Cook(commands);

            var (earned, comment) = ScoringEngine.Evaluate(selected, burger); // 채점

            foreach (Control c in flowLayoutPanel1.Controls.OfType<Control>().ToArray())
                c.Dispose();
            flowLayoutPanel1.Controls.Clear();


            PrintBurgerLayers(burger);

            await PlayBurgerAnimationAsync();

            FinishCurrentOrder();

            수입금TB.Text = (int.Parse(수입금TB.Text) + earned).ToString();
            ShowBalloon(comment, earned);

            UserBlockParser.Ham.Clear();

            var hideTimer = new System.Windows.Forms.Timer
            {
                Interval = 2000   // 밀리초
            };
            hideTimer.Tick += (s, ev) =>
            {
                말풍선P.Visible = false;
                hideTimer.Stop();
                hideTimer.Dispose();
            };
            hideTimer.Start();
        }


        private static void PrintBurgerLayers(Burger b)
        {
            Console.WriteLine("완성 버거 레이어(아래→위)-------");
            for (int i = 0; i < b.Layers.Count; i++)
            {
                var ing = b.Layers[i];
                Console.WriteLine($"{i}: {ing.Type} ({ing.CookState})");
            }
        }

        private async Task PlayBurgerAnimationAsync()
        {
            var pb = new PictureBox
            {
                Image = bugerimage,
                SizeMode = PictureBoxSizeMode.StretchImage,
                BackColor = Color.Transparent,
                Size = new Size(200, 200)
            };
            this.Controls.Add(pb);
            pb.SendToBack();

            int startX = (this.ClientSize.Width - pb.Width) / 2;
            int endX = this.ClientSize.Width;
            int posY = (this.ClientSize.Height - pb.Height) / 2;

            pb.Location = new Point(startX, posY);

            const int duration = 3000;
            const int interval = 15;
            int steps = duration / interval;
            double dx = (double)(endX - startX) / steps;

            for (int i = 0; i < steps; i++)
            {
                pb.Left = (int)Math.Round(startX + dx * i);
                await Task.Delay(interval);
            }

            this.Controls.Remove(pb);
            pb.Dispose();
        }
        private void ShowBalloon(string comment, int earned)
        {
            말풍선P.SuspendLayout();
            말풍선P.Controls.Clear();

            var lblComment = new Label
            {
                AutoSize = false,
                MaximumSize = new Size(말풍선P.Width - 20, 0),
                Font = new Font("Segoe UI", 13),
                Text = comment,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
            };


            말풍선P.Controls.Add(lblComment);
            말풍선P.Visible = true;
            말풍선P.ResumeLayout();
        }
        void FinishCurrentOrder()
        {
            if (selected == null) return;

            int idx = orders.IndexOf(selected);
            if (idx >= 0)
            {
                orders.RemoveAt(idx);
                orderQueue.Controls.RemoveAt(idx);
            }

            for (int i = 0; i < orderQueue.Controls.Count; i++)
                orderQueue.Controls[i].Tag = i;

            if (orders.Count == 0)
            {
                orders.Clear();
                orderQueue.Controls.Clear();

                for (int i = 0; i < 5; i++)
                {
                    var pb = new PictureBox
                    {
                        Width = boxWidth,
                        Height = boxHeight,
                        BorderStyle = BorderStyle.FixedSingle,
                        SizeMode = PictureBoxSizeMode.Zoom,
                        Tag = i,
                        Image = Properties.Resources.shareBee1
                    };
                    pb.Click += OrderSlot_Click;
                    orderQueue.Controls.Add(pb);

                    orders.Add(orderGen.getOrder());
                }

                var first = orderQueue.Controls[0] as PictureBox;
                OrderSlot_Click(first, EventArgs.Empty);
            }
            else
            {
                var first = orderQueue.Controls[0] as PictureBox;
                OrderSlot_Click(first, EventArgs.Empty);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DeleteSelectedBlock();
        }
        private void DeleteSelectedBlock()
        {
            if (_selectedBlock == null) return;

            flowLayoutPanel1.Controls.Remove(_selectedBlock);
            _selectedBlock.Dispose();
            _selectedBlock = null;

            RefreshCookButton();
        }
        private void HambugiGameForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            SoundManager.StopSound();
        }
    }
}
