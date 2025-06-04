using Shell32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.WindowsAPICodePack.Shell;

namespace File_Management_v2.Helper
{
    internal static class FileProperty
    {
        /// <summary>
        /// Mengambil properti file dari Windows Shell berdasarkan nama properti (misal: "Size", "Date taken", "Media created").
        /// </summary>
        /// <param name="filePath">Path lengkap ke file.</param>
        /// <param name="propertyName">Nama properti yang ingin diambil.</param>
        /// <returns>Nilai properti dalam bentuk string, atau null jika tidak ditemukan.</returns>

        public static string GetProperty(string filePath, string propertyName)
        {
            try
            {
                using (ShellObject shell = ShellObject.FromParsingName(filePath))
                {
                    switch (propertyName)
                    {
                        case "Date taken":
                            return shell.Properties.System.Photo.DateTaken?.Value?.ToString(Setting.DateFormat) ?? "";
                        case "Media created":
                            return shell.Properties.System.Media.DateEncoded?.Value?.ToString("yyyy-MM-dd HH:mm:ss") ?? "";
                        case "Date created":
                            return System.IO.File.GetCreationTime(filePath).ToString("yyyy-MM-dd HH:mm:ss");
                        case "Date modified":
                            return System.IO.File.GetLastWriteTime(filePath).ToString("yyyy-MM-dd HH:mm:ss");
                        case "File location":
                            return Path.GetDirectoryName(filePath);
                        default:
                            // Ambil properti berdasarkan nama string seperti "System.Author", "System.Title", dsb
                            var prop = shell.Properties.GetProperty(propertyName);
                            return prop?.ValueAsObject?.ToString() ?? "";
                    }
                }
            }
            catch (Exception ex)
            {
                return ""; // bisa log jika perlu
            }
        }

        public static FileMetadata GetFileMetadata(string filePath)
        {
            var metadata = new FileMetadata();

            try
            {
                // Ambil Date Taken
                string dateTakenStr = FileProperty.GetProperty(filePath, "Date taken");
                if (DateTime.TryParseExact(dateTakenStr, Setting.DateFormat, null, DateTimeStyles.None, out var dateTaken))
                {
                    metadata.DateTaken = dateTaken;
                }

                // Ambil Media Created
                string mediaCreatedStr = FileProperty.GetProperty(filePath, "Media created");
                if (DateTime.TryParseExact(mediaCreatedStr, "yyyy-MM-dd HH:mm:ss", null, DateTimeStyles.None, out var mediaCreated))
                {
                    metadata.MediaCreated = mediaCreated;
                }
            }
            catch
            {
                // Abaikan error
            }

            return metadata;
        }
    }
}
