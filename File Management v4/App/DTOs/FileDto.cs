using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File_Management_v4.App.DTOs
{
    public class FileDto
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public bool IsOriginal { get; set; }
    }
}
