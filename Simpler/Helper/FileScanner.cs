using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Simpler.Helper
{
    internal static class FileScanner
    {
        public static List<string> GetAllFiles(string rootPath, string[] extensions)
        {
            List<string> files = new List<string>();

            try
            {
                foreach (string file in Directory.GetFiles(rootPath))
                {
                    if (extensions.Contains(Path.GetExtension(file), StringComparer.OrdinalIgnoreCase))
                        files.Add(file);
                }

                foreach (string dir in Directory.GetDirectories(rootPath))
                {
                    try
                    {
                        files.AddRange(GetAllFiles(dir, extensions)); // rekursif aman
                    }
                    catch (UnauthorizedAccessException ex)
                    {
                        Debug.WriteLine($"[SKIP] Access denied to folder: {dir} => {ex.Message}");
                    }
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                Debug.WriteLine($"[SKIP] Access denied to root folder: {rootPath} => {ex.Message}");
            }

            return files;
        }
    }
}
