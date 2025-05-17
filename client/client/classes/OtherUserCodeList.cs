using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client
{
    internal class OtherUserCodeList
    {
        public string userID { get; set; }
        public List<CodeItem> cid_title_list { get; set;}
        public class CodeItem
        {
            public string CodeID { get; set; }
            public string Title { get; set; }

            public override string ToString()
            {
                return Title;
            }
        }

    }
}
