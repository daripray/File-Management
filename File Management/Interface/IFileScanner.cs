using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File_Management.Interface
{
    internal interface IFileScanner
    {
        List<string> GetAllFiles(string rootPath, string[] extensions);
    }
}
