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
                userID = "kurisu",
                codeID = "growth001",
                nickname = "마키세 크리스",
                title = "L-시스템 기반 나무 성장 시뮬레이션",
                Level = 4,
                CodeExplanation = new List<string>
                {
                    "L-시스템은 문자열의 반복 규칙을 통해 복잡한 패턴을 시뮬레이션할 수 있는 알고리즘입니다.",
                    "식물의 가지 구조, 프랙탈 구조 등을 모델링할 때 자주 사용됩니다.",
                    "이 예시는 'F → F[+F]F[-F]F' 규칙을 기반으로 나무의 성장을 구현합니다."
                },
                Code = new List<string>
                {
                    "// L-시스템 나무 성장 알고리즘",
                    "string axiom = \"F\";",
                    "Dictionary<char, string> rules = new() { { 'F', \"F[+F]F[-F]F\" } };",
                    "string Generate(int iterations, string input)",
                    "{",
                    "    for (int i = 0; i < iterations; i++)",
                    "    {",
                    "        var output = new StringBuilder();",
                    "        foreach (char c in input)",
                    "            output.Append(rules.ContainsKey(c) ? rules[c] : c.ToString());",
                    "        input = output.ToString();",
                    "    }",
                    "    return input;",
                    "}",
                    "void SimulateGrowth()",
                    "{",
                    "    var result = Generate(3, axiom);",
                    "    Console.WriteLine(\"성장된 나무 구조:\");",
                    "    Console.WriteLine(result);",
                    "}"
                }
            };
            default1.SaveToFile();

            var default6 = new ShareCodeSave
            {
                userID = "csuser",
                codeID = "algo001",
                nickname = "알고리즘 수련생",
                title = "이진 탐색 알고리즘",
                Level = 1,
                CodeExplanation = new List<string>
                {
                    "이진 탐색은 정렬된 배열에서 값을 효율적으로 찾는 알고리즘입니다.",
                    "중앙값을 기준으로 범위를 절반씩 줄여나가며 검색합니다.",
                    "시간 복잡도는 O(log n)입니다."
                },
                Code = new List<string>
                {
                    "// 정렬된 배열에서 target을 찾는다",
                    "int BinarySearch(int[] arr, int target)",
                    "{",
                    "    int left = 0, right = arr.Length - 1;",
                    "    while (left <= right)",
                    "    {",
                    "        int mid = (left + right) / 2;",
                    "        if (arr[mid] == target) return mid;",
                    "        else if (arr[mid] < target) left = mid + 1;",
                    "        else right = mid - 1;",
                    "    }",
                    "    return -1; // not found",
                    "}"
                }
            };
            default6.SaveToFile();

            var default7 = new ShareCodeSave
            {
                userID = "csuser",
                codeID = "algo002",
                nickname = "알고리즘 수련생",
                title = "너비 우선 탐색 (BFS)",
                Level = 2,
                CodeExplanation = new List<string>
                {
                    "BFS는 그래프에서 가까운 노드부터 탐색하는 알고리즘입니다.",
                    "주로 큐(Queue)를 사용하여 구현하며, 최단 거리 탐색에 유용합니다.",
                    "시간 복잡도는 O(V + E)입니다."
                },
                Code = new List<string>
                {
                    "// 인접 리스트 기반 BFS 구현",
                    "void BFS(Dictionary<int, List<int>> graph, int start)",
                    "{",
                    "    var visited = new HashSet<int>();",
                    "    var queue = new Queue<int>();",
                    "    queue.Enqueue(start);",
                    "    visited.Add(start);",
                    "    while (queue.Count > 0)",
                    "    {",
                    "        int node = queue.Dequeue();",
                    "        Console.WriteLine($\"방문: {node}\");",
                    "        foreach (var neighbor in graph[node])",
                    "        {",
                    "            if (!visited.Contains(neighbor))",
                    "            {",
                    "                visited.Add(neighbor);",
                    "                queue.Enqueue(neighbor);",
                    "            }",
                    "        }",
                    "    }",
                    "}"
                }
            };
            default7.SaveToFile();

            var default8 = new ShareCodeSave
            {
                userID = "csuser",
                codeID = "algo003",
                nickname = "알고리즘 수련생",
                title = "다익스트라 최단 거리 알고리즘",
                Level = 4,
                CodeExplanation = new List<string>
                {
                    "다익스트라 알고리즘은 가중 그래프에서 출발점으로부터 각 정점까지의 최단 거리를 구합니다.",
                    "우선순위 큐를 사용하여 최소 비용을 가진 정점을 반복적으로 선택합니다.",
                    "음수 가중치가 없는 경우에만 정확하게 동작합니다."
                },
                Code = new List<string>
                {
                    "// 다익스트라 최단 거리",
                    "void Dijkstra(Dictionary<int, List<(int to, int weight)>> graph, int start)",
                    "{",
                    "    var dist = new Dictionary<int, int>();",
                    "    var pq = new PriorityQueue<int, int>();",
                    "    foreach (var node in graph.Keys)",
                    "        dist[node] = int.MaxValue;",
                    "    dist[start] = 0;",
                    "    pq.Enqueue(start, 0);",
                    "    while (pq.Count > 0)",
                    "    {",
                    "        var current = pq.Dequeue();",
                    "        foreach (var (next, weight) in graph[current])",
                    "        {",
                    "            int cost = dist[current] + weight;",
                    "            if (cost < dist[next])",
                    "            {",
                    "                dist[next] = cost;",
                    "                pq.Enqueue(next, cost);",
                    "            }",
                    "        }",
                    "    }",
                    "    foreach (var (node, d) in dist)",
                    "        Console.WriteLine($\"노드 {node}까지 거리: {d}\");",
                    "}"
                }
            };
            default8.SaveToFile();



        }


    }
}
