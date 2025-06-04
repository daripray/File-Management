using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File_Management_v1.Helper
{
    internal class Parameters
    {
        public string SourcePath { get; set; }
        public List<string> Extensions { get; set; }
        public List<string> IncludeKeywords { get; set; }
        public List<string> ExcludeKeywords { get; set; }
        public bool FilterOri { get; set; }
        public bool FilterNonOri { get; set; }
    }
}
