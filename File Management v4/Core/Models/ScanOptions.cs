using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File_Management_v4.Core.Models
{
    public class ScanOptions
    {
        public string SourcePath { get; set; }
        public List<string> Extensions { get; set; } = new();
        public List<string> IncludeKeywords { get; set; } = new();
        public List<string> ExcludeKeywords { get; set; } = new();
        public bool OnlyOriginals { get; set; } = false;
    }
}
