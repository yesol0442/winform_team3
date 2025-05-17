using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client
{
    internal class UserCodeList
{
        public string userID { get; set; }

        public List<CodeItem> cid_title_list { get; set; }
        public class CodeItem
        {
            public string CodeID { get; set; }
            public string Title { get; set; }

            public int status { get; set; } // 1일때 업로드 0일때 임시저장

            public override string ToString()
            {
                return Title;
            }
        }
    }
}
