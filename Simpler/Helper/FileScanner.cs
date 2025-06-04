using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace File_Management_v1.Helper
{
    internal static class FileScanner
    {
        public static List<string> GetAllFiles(string rootPath, string[] extensions)
        {
            List<string> files = new List<string>();

            try
            {
                // Ambil file di direktori saat ini
                files.AddRange(Directory
                    .EnumerateFiles(rootPath)
                    .Where(f => extensions.Contains(Path.GetExtension(f), StringComparer.OrdinalIgnoreCase)));

                // Proses semua subdirektori
                foreach (string dir in Directory.EnumerateDirectories(rootPath))
                {
                    try
                    {
                        files.AddRange(GetAllFiles(dir, extensions)); // rekursif
                    }
                    catch (UnauthorizedAccessException ex)
                    {
                        Debug.WriteLine($"[SKIP] Access denied to folder: {dir} => {ex.Message}");
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine($"[SKIP] Error accessing folder: {dir} => {ex.Message}");
                    }
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                Debug.WriteLine($"[SKIP] Access denied to root folder: {rootPath} => {ex.Message}");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[SKIP] Error accessing root folder: {rootPath} => {ex.Message}");
            }

            return files;
        }
    }
}
