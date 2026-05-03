using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File_Management_v4.Core.Interfaces
{
    public interface IFileSystem
    {
        void Copy(string source, string destination);
        void Move(string source, string destination);
        void Delete(string source);
        bool Exists(string path);
        void CreateDirectory(string path);
    }
}
