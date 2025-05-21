using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace client
{
    internal class CodePractice // 코드 연습할 수 있도록 코드 추가, 공유함에 올리는 것도 포함
    {
        public string userID {  get; set; }
        public string codeID { get; set; }

        public string nickname {  get; set; }
        public string title {  get; set; }
        public byte[] ProfileImageData { get; set; } // DB 저장용
        public int Level { get; set; }

        public int status { get; set; } // 1일때 업로드 0일때 임시저장

        public List<string> CodeExplanation { get; set; }
        public List<string> Code { get; set; }

        // 실제 사용 용도
        [System.NonSerialized]
        private Image _profileImage;

        public Image ProfileImage
        {
            get
            {
                if (_profileImage == null && ProfileImageData != null)
                    using (var ms = new MemoryStream(ProfileImageData))
                        _profileImage = Image.FromStream(ms);
                return _profileImage;
            }
            set
            {
                _profileImage = value;
                if (value != null)
                {
                    using (var ms = new MemoryStream())
                    {
                        value.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                        ProfileImageData = ms.ToArray();
                    }
                }
            }
        }
    }
}

