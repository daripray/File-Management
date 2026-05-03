using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File_Management_v4.Core.Interfaces
{
    public interface IFileScanner
    {
        IEnumerable<string> GetFiles(string path);
    }
}
