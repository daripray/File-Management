using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using File_Management_v4.Core.Interfaces;

namespace File_Management_v4.Infrastructure.FileSystem
{
    public class FileSystemService : IFileSystem
    {
        public void Copy(string source, string destination)
        {
            File.Copy(source, destination);
        }
        public void Move(string source, string destination)
        {
            File.Move(source, destination);
        }
        public bool Exists(string path)
        {
            return File.Exists(path);
        }
        public void CreateDirectory(string path)
        {
            Directory.CreateDirectory(path);
        }
        public void Delete(string source)
        {
            File.Delete(source);
        }
    }
}
