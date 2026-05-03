using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using File_Management_v4.Core.Interfaces;
using File_Management_v4.Core.Models;

namespace File_Management_v4.App.Services
{
    public class ProcessService
    {
        private readonly IFileSystem _fileSystem;
        public ProcessService(IFileSystem fileSystem)
        {
            _fileSystem = fileSystem;
        }

        public void Copy(FileItem file, string destination)
        {
            _fileSystem.CreateDirectory(destination);

            var destPath = Path.Combine(destination, file.Name);

            if (_fileSystem.Exists(destPath))
                return;

            _fileSystem.Copy(file.Path, destPath);
        }

        public void Move(FileItem file, string destination)
        {
            _fileSystem.CreateDirectory(destination);

            var destPath = Path.Combine(destination, file.Name);

            if (_fileSystem.Exists(destPath))
                return;

            _fileSystem.Move(file.Path, destPath);
        }
        public void Delete(FileItem file)
        {
            _fileSystem.Delete(file.Path);
        }
    }
}
