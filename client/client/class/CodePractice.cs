using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace client
{
    internal class CodePractice
    {
        public string userID {  get; set; }
        public string title {  get; set; }
        public byte[] ProfileImageData { get; set; } // DB 저장용
        public int Level { get; set; }
        public string UploaderName { get; set; }

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

