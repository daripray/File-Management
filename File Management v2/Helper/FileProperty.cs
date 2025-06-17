using MetadataExtractor;
using Microsoft.WindowsAPICodePack.Shell;
using Microsoft.WindowsAPICodePack.Shell.PropertySystem;
using Shell32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


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

        public static Dictionary<string, string> GetAllProperties(string filePath)
        {
            var metadata = new Dictionary<string, string>();

            try
            {
                using (ShellObject shell = ShellObject.FromParsingName(filePath))
                {
                    // Ambil semua properti metadata
                    var props = shell.Properties.DefaultPropertyCollection;

                    foreach (IShellProperty prop in shell.Properties.DefaultPropertyCollection)
                    {
                        try
                        {
                            string name = prop.CanonicalName;
                            if (name == "System.SharedWith")
                                continue;
                            string value = prop.ValueAsObject?.ToString();

                            if (!string.IsNullOrWhiteSpace(name) && !string.IsNullOrWhiteSpace(value))
                                metadata[name] = value;
                        }
                        catch (Exception innerEx)
                        {
                            // Skip property yang error tanpa menghentikan loop
                            metadata[$"Error reading {prop?.CanonicalName}"] = innerEx.Message;
                        }
                    }


                    // Tambah properti sistem file
                    metadata["Date created"] = File.GetCreationTime(filePath).ToString("yyyy-MM-dd HH:mm:ss");
                    metadata["Date modified"] = File.GetLastWriteTime(filePath).ToString("yyyy-MM-dd HH:mm:ss");
                    metadata["File location"] = Path.GetDirectoryName(filePath);
                }
            }
            catch (Exception ex)
            {
                metadata["Error"] = ex.Message;
            }

            return metadata;
        }

        public static Dictionary<string, string> GetAllMetadata(string filePath)
        {
            var metadata = new Dictionary<string, string>();

            try
            {
                var directories = ImageMetadataReader.ReadMetadata(filePath);

                foreach (var directory in directories)
                {
                    foreach (var tag in directory.Tags)
                    {
                        string key = $"{directory.Name}.{tag.Name}".Replace(" ", "");
                        string value = tag.Description?.Trim();

                        if (!string.IsNullOrWhiteSpace(key) && !string.IsNullOrWhiteSpace(value))
                            metadata[key] = value;
                    }

                    // Jika ada error dalam directory, bisa juga ditambahkan
                    foreach (var error in directory.Errors)
                    {
                        metadata[$"{directory.Name}.Error"] = error;
                    }
                }
            }
            catch (Exception ex)
            {
                metadata["ReadMetadata.Error"] = ex.Message;
            }

            return metadata;
        }
    }
}
