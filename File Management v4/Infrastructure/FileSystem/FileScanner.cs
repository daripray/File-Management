using File_Management_v4.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File_Management_v4.Infrastructure.FileSystem
{
    public class FileScanner : IFileScanner
    {
        public IEnumerable<string> GetFiles(string path)
        {
            //if(!Directory.Exists(path))
            //    return Enumerable.Empty<string>();
            //try
            //{
            //    return Directory.EnumerateFiles(path, "*.*", SearchOption.AllDirectories);

            //}
            //catch (UnauthorizedAccessException ex)
            //{
            //    // Handle folder inaccessible (permission, etc)
            //    Console.WriteLine($"[ERROR] Access denied to folder: {path} => {ex.Message}");
            //    return Enumerable.Empty<string>();
            //}


            if (!Directory.Exists(path))
                yield break;
            var stack = new Stack<string>();
            stack.Push(path);
            while (stack.Count > 0)
            {
                var currentDir = stack.Pop();
                IEnumerable<string> files = Enumerable.Empty<string>();
                try
                {
                    files = Directory.GetFiles(currentDir);
                }
                catch { }

                foreach (var file in files)
                    yield return file;
                try
                {
                    foreach (var dir in Directory.GetDirectories(currentDir))
                        stack.Push(dir);
                }
                catch { }

            }
        }
    }
}
