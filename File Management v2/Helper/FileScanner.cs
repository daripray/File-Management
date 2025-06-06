using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Microsoft.WindowsAPICodePack.Shell;

namespace File_Management_v2.Helper
{
    public class FileMetadata
    {
        public DateTime? DateTaken { get; set; }
        public DateTime? MediaCreated { get; set; }
        //public string FileStatus { get; set; }
    }
    public class FileScanResult
    {
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string Directory { get; set; }
        public long SizeBytes { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public DateTime? DateTaken { get; set; }
        public DateTime? MediaCreated { get; set; }
        public string FileStatus { get; set; }
        public bool IsOri { get; set; }
        public int TotalFiles { get; set; }
        public int Index { get; set; }

    }

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


        /// <summary>
        /// Mengambil metadata DateTaken dan MediaCreated dari file.
        /// </summary>
        public static FileMetadata GetFileMetadata(string filePath)
        {
            try
            {
                using (var shell = ShellObject.FromParsingName(filePath))
                {
                    return new FileMetadata
                    {
                        DateTaken = shell.Properties.System.Photo.DateTaken?.Value,
                        MediaCreated = shell.Properties.System.Media.DateEncoded?.Value
                    };
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[SKIP] Error reading metadata from: {filePath} => {ex.Message}");
                return new FileMetadata();
            }
        }

        /// <summary>
        /// Menghasilkan hasil scan lengkap dalam bentuk FileScanResult.
        /// </summary>
        public static FileScanResult Result(string filePath)
        {
            try
            {
                var fileInfo = new FileInfo(filePath);
                var metadata = GetFileMetadata(filePath);

                return new FileScanResult
                {
                    FileName = fileInfo.Name,
                    FilePath = fileInfo.FullName,
                    Directory = fileInfo.DirectoryName ?? "",
                    SizeBytes = fileInfo.Length,
                    DateCreated = fileInfo.CreationTime,
                    DateModified = fileInfo.LastWriteTime,
                    DateTaken = metadata.DateTaken,
                    MediaCreated = metadata.MediaCreated
                };
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[SKIP] Error building FileScanResult: {filePath} => {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// Mengecek status file apakah valid, kosong, atau corrupt.
        /// </summary>
        public static string GetFileStatus(string filePath, List<string> imageExts, List<string> videoExts, List<string> documentExts)
        {
            try
            {
                var ext = Path.GetExtension(filePath).ToUpperInvariant();

                var fi = new FileInfo(filePath);
                if (fi.Length == 0)
                    return FileStatus.Scan.Empty;

                // Cek file gambar (load Image)
                if (imageExts.Contains(ext))
                {
                    using var img = System.Drawing.Image.FromFile(filePath);
                    return FileStatus.Scan.Ok;
                }

                // Cek file video (cek apakah file bisa dibuka saja)
                if (videoExts.Contains(ext))
                {
                    using var fs = File.OpenRead(filePath);
                    return FileStatus.Scan.Ok;
                }

                // Cek file dokumen (cek apakah file bisa dibaca atau tidak corrupt)
                if (documentExts.Contains(ext))
                {
                    using var fs = File.OpenRead(filePath);
                    return FileStatus.Scan.Ok;
                }

                return FileStatus.Scan.Ok; // default kalau tidak termasuk kategori khusus
            }
            catch
            {
                return FileStatus.Scan.Corrupt;
            }
        }

    }
}
