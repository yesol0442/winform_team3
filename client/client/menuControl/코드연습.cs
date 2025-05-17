using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace client.menuControl
{
    public partial class 코드연습 : UserControl
    {
        private CodePreacticeControl.ShareControl sharecontrol = new CodePreacticeControl.ShareControl();
        private CodePreacticeControl.CodeExplainControl codecontrol = new CodePreacticeControl.CodeExplainControl();
        private List<ShareCodeSave> sharCodeSaves = new List<ShareCodeSave>();
        public 코드연습()
        {
            InitializeComponent();
            panel2.Controls.Add(sharecontrol);
            panel2.Controls.Add(codecontrol);

        }

        private void 코드연습_Load(object sender, EventArgs e)
        {
            InitializeDefaultFiles();
            loadfile();
            foreach (ShareCodeSave loadcode in sharCodeSaves)
            {
                listBox1.Items.Add(loadcode);
            }
            //로컬DB에서 title 가져와서 listbox에 추가
            sharecontrol.BringToFront();
            sharecontrol.Show();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedCode = listBox1.SelectedItem as ShareCodeSave;
            if (selectedCode != null)
            {
                codecontrol.Initialization_codecontrol(selectedCode);
                codecontrol.BringToFront();
                codecontrol.Show();
            }
        }

        private void loadfile()
        {
            List<string> codeid = ShareCodeSave.GetAllSavedCodeIDs();
            foreach(string id  in codeid)
            {
                ShareCodeSave scs = new ShareCodeSave();
                scs.LoadFromFile(id);
                sharCodeSaves.Add(scs);
            }
        }
        private static void InitializeDefaultFiles()
        {
            // 이미 저장된 게 있으면 스킵

            // 기본 데이터 1
            var default1 = new ShareCodeSave
            {
                userID = "edward",
                codeID = "fma001",
                nickname = "에드워드 엘릭",
                title = "연금술의 기본 원칙",
                Level = 1,
                CodeExplanation = new List<string>
                {
                    "연금술은 등가교환의 법칙을 기반으로 한다.",
                    "무언가를 얻기 위해선 그에 상응하는 대가가 필요하다."
                },
                Code = new List<string>
                {
                    "// 등가교환 공식",
                    "object 결과 = 연금술(재료A + 재료B);",
                    "if (결과 == null) { throw new Exception(\"대가가 부족합니다.\"); }"
                }
            };
            default1.SaveToFile();

            // 기본 데이터 2
            var default2 = new ShareCodeSave
            {
                userID = "shinji",
                codeID = "eva001",
                nickname = "이카리 신지",
                title = "에바 탑승 매뉴얼",
                Level = 1,
                CodeExplanation = new List<string>
                {
                    "에반게리온은 반드시 지정된 파일럿만 탑승할 수 있습니다.",
                    "탑승 전, LCL 충전과 신경 연결이 필요합니다."
                },
                Code = new List<string>
                {
                    "void EvaStart()",
                    "{",
                    "    FillLCL();",
                    "    ConnectNerveSystem();",
                    "    LaunchEvaUnit01();",
                    "}"
                }
            };
            default2.SaveToFile();

            var default3 = new ShareCodeSave
            {
                userID = "levi",
                codeID = "aot001",
                nickname = "리바이",
                title = "입체기동장치 사용법",
                Level = 3,
                CodeExplanation = new List<string>
                {
                    "입체기동장치는 가스 압력을 이용해 고속 이동을 가능하게 합니다.",
                    "중심을 잃지 않고 움직이려면 훈련이 필요합니다.",
                    "목표는 항상 거인의 뒤통수입니다. 망설이지 마십시오."
                },
                Code = new List<string>
                {
                    "void EngageTitan(Titan target)",
                    "{",
                    "    LockAnchor(target.neck);",
                    "    BoostWithGas();",
                    "    if (angle > 90)",
                    "        AdjustTrajectory();",
                    "    Slash(target.neck);",
                    "    RetreatSafely();",
                    "}"
                }
            };
            default3.SaveToFile();

            var default4 = new ShareCodeSave
            {
                userID = "gon",
                codeID = "nen001",
                nickname = "곤 프릭스",
                title = "넨 시스템 기초 수련법",
                Level = 2,
                CodeExplanation = new List<string>
                {
                    "넨은 생명 에너지인 오라(Aura)를 제어하는 기술이다.",
                    "기초 네 단계는 텐(纏), 젠(絶), 렌(練), 핫츠(発)로 구성된다.",
                    "계열은 총 6가지로, 각각의 성향에 따라 오라 활용 방식이 달라진다.",
                    "곤은 직감형에 가까운 '강화계' 넨 능력자이다."
                },
                Code = new List<string>
                {
                    "class NenUser {",
                    "    int aura = 100;",
                    "    string type = \"강화계\";",
                    "    void Ten() => Console.WriteLine(\"텐: 오라를 몸에 두른다\");",
                    "    void Zetsu() => Console.WriteLine(\"젠: 오라 흐름 차단\");",
                    "    void Ren() { aura += 50; Console.WriteLine($\"렌: 오라 증폭 ({aura})\"); }",
                    "    void Hatsu() => Console.WriteLine($\"핫츠: {type} 기술 발동\");",
                    "    void Practice() { Ten(); Zetsu(); Ren(); Hatsu(); }",
                    "    void ChangeType(string newType) {",
                    "        if (IsValidType(newType)) type = newType;",
                    "        else Console.WriteLine(\"유효하지 않은 계열입니다\");",
                    "    }",
                    "    bool IsValidType(string t) => new[]{\"강화계\",\"방출계\",\"조작계\",\"변화계\",\"변환계\",\"특질계\"}.Contains(t);",
                    "    void SenseAura(NenUser target) => Console.WriteLine(\"상대 오라 감지 시도...\");",
                    "    void BlockAura() { aura = 0; Console.WriteLine(\"오라 완전 차단\"); }",
                    "    void ShowStatus() => Console.WriteLine($\"계열: {type}, 오라: {aura}\");",
                    "}"
                }

                };
            default4.SaveToFile();
        }


    }
}
