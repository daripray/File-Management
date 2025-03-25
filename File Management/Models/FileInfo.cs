using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File_Management.Models
{
    class FileInfo
    {
        string filepath;

        public FileInfo(string filePath)
        {
            filepath = filePath;
        }

        public String FileName()
        {
            return Path.GetFileName(filepath);
        }

        public DateTime CreationTime()
        {
            return File.GetCreationTime(filepath);
        }
        public DateTime LastWriteTime()
        {
            return File.GetLastWriteTime(filepath);
        }
    }
}
