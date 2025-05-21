using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace client
{
    public class ShareCodeSave // 공유함에 있는 코드를 내 코드에 추가하기
    {
        public string userID { get; set; }
        public string codeID { get; set; }

        public string nickname { get; set; }
        public string title { get; set; }
        public int Level { get; set; }

        public List<string> CodeExplanation { get; set; }
        public List<string> Code { get; set; }


        private static string GetSaveFolder()
        {
            string folder = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "CodePracticeFile");

            Directory.CreateDirectory(folder);
            return folder;
        }

        private string GetSavePath()
        {
            return Path.Combine(GetSaveFolder(), $"{codeID}.txt");
        }
     

        public void SaveToFile()
        {
            string path = GetSavePath();
            using (StreamWriter writer = new StreamWriter(path))
            {
                writer.WriteLine(userID);
                writer.WriteLine(codeID);
                writer.WriteLine(nickname);
                writer.WriteLine(title);
                writer.WriteLine(Level);

                writer.WriteLine("[CodeExplanation]");
                foreach (var line in CodeExplanation)
                    writer.WriteLine(line);

                writer.WriteLine("[Code]");
                foreach (var line in Code)
                    writer.WriteLine(line);
            }
        }

        public void LoadFromFile(string codeID)
        {
            this.codeID = codeID; // 코드 ID를 먼저 설정
            string path = GetSavePath();

            if (!File.Exists(path)) return;

            var lines = File.ReadAllLines(path);
            int index = 0;

            userID = lines[index++];
            codeID = lines[index++];
            nickname = lines[index++];
            title = lines[index++];
            Level = int.Parse(lines[index++]);

            CodeExplanation = new List<string>();
            Code = new List<string>();

            string section = "";

            for (; index < lines.Length; index++)
            {
                var line = lines[index];
                if (line == "[CodeExplanation]")
                {
                    section = "explanation";
                    continue;
                }
                else if (line == "[Code]")
                {
                    section = "code";
                    continue;
                }

                if (section == "explanation")
                    CodeExplanation.Add(line);
                else if (section == "code")
                    Code.Add(line);
            }

        }

        public static List<string> GetAllSavedCodeIDs()
        {
            string folder = GetSaveFolder();

            if (!Directory.Exists(folder))
                return new List<string>(); // 폴더 없으면 빈 리스트 반환

            var files = Directory.GetFiles(folder, "*.txt");

            return files.Select(f => Path.GetFileNameWithoutExtension(f)).ToList();
        }

        public override string ToString()
        {
            return title;
        }
    }
}
