using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client.classes
{
    public class LanguageChangedEventArgs : EventArgs
    {
        public string SelectedLanguage { get; }

        public LanguageChangedEventArgs(string selectedLanguage)
        {
            SelectedLanguage = selectedLanguage;
        }
    }
}
