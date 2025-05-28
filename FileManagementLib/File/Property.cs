using Shell32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using TagLib;

namespace Lib.File
{
    internal interface IFileProperty
    {
        /// <summary>
        /// Mengambil properti file dari Windows Shell berdasarkan nama properti (misal: "Size", "Date taken", "Media created").
        /// </summary>
        /// <param name="filePath">Path lengkap ke file.</param>
        /// <param name="propertyName">Nama properti yang ingin diambil.</param>
        /// <returns>Nilai properti dalam bentuk string, atau null jika tidak ditemukan.</returns>
        string GetProperty(string filePath, string propertyName);
        long? GetFileSizeBytes(string filePath); // nilainya bisa null jika gagal
        string FormatSize(long bytes); // nilainya bisa null jika gagal
    }

    internal class Property : IFileProperty
    {
        /// <summary>
        /// Mengambil properti file dari Windows Shell berdasarkan nama properti (misal: "Size", "Date taken", "Media created").
        /// </summary>
        /// <param name="filePath">Path lengkap ke file.</param>
        /// <param name="propertyName">Nama properti yang ingin diambil.</param>
        /// <returns>Nilai properti dalam bentuk string, atau null jika tidak ditemukan.</returns>
        public string GetProperty(string filePath, string propertyName)
        {
            try
            {
                Shell shell = new Shell();
                Folder folder = shell.NameSpace(Path.GetDirectoryName(filePath));
                FolderItem item = folder?.ParseName(Path.GetFileName(filePath));

                if (folder == null || item == null)
                    return null;

                for (int i = 0; i < short.MaxValue; i++)
                {
                    string key = folder.GetDetailsOf(null, i);
                    if (key == propertyName)
                    {
                        Console.WriteLine($"✔ propertyName : {propertyName}");
                        string value = folder.GetDetailsOf(item, i);
                        //return string.IsNullOrWhiteSpace(value) ? null : value;

                        if (propertyName == "Date created"
                            || propertyName == "Date modified")
                        {
                            if (!string.IsNullOrWhiteSpace(value) && value.Contains(":"))
                            {
                                // Format: "10/25/2025 10:15 AM" → "2024-05-25 10:15:00"
                                string normalized = NormalizeDateString(value);
                                value = normalized ?? value; // gunakan nilai yang sudah dinormalisasi jika tidak null
                            }
                        }
                        if (propertyName == "Date taken")
                        {
                            if (!string.IsNullOrWhiteSpace(value) && value.Contains(":"))
                            {
                                // Format: "10/25/2025 10:15 AM" → "2024-05-25 10:15:00"
                                //string normalized = NormalizeDateString(value);
                                //value = normalized ?? value; // gunakan nilai yang sudah dinormalisasi jika tidak null
                                value = GetExifDateTaken(filePath) ?? value; // gunakan nilai dari EXIF jika ada
                            }
                        }
                        if (propertyName == "Media created")
                        {
                            if (!string.IsNullOrWhiteSpace(value) && value.Contains(":"))
                            {
                                // Format: "10/25/2025 10:15 AM" → "2024-05-25 10:15:00"
                                //string normalized = NormalizeDateString(value);
                                //value = normalized ?? value; // gunakan nilai yang sudah dinormalisasi jika tidak null
                                //value = File.GetCreationTime(filePath).ToString("yyyy-MM-dd HH:mm:ss");

                                // Replace the problematic line with the correct usage of File.GetCreationTime
                                value = System.IO.File.GetCreationTime(filePath).ToString("yyyy-MM-dd HH:mm:ss");
                            }
                        }
                        return string.IsNullOrWhiteSpace(value) ? null : value;
                    }
                }
            }
            catch { }
            return null;
        }

        public static string GetExifDateTaken(string filePath)
        {
            try
            {
                using (var img = Image.FromFile(filePath))
                {
                    const int PropertyTagExifDTOrig = 0x9003; // "Date taken"
                    if (img.PropertyIdList.Contains(PropertyTagExifDTOrig))
                    {
                        var propItem = img.GetPropertyItem(PropertyTagExifDTOrig);
                        string dateStr = Encoding.ASCII.GetString(propItem.Value).Trim('\0');

                        if (DateTime.TryParseExact(dateStr, "yyyy:MM:dd HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out var parsed))
                            return parsed.ToString("yyyy-MM-dd HH:mm:ss");
                        return dateStr;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"✘ EXIF error: {ex.Message}");
            }

            return null;
        }

        public static string NormalizeDateString(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return null;

            string[] formats = new[] {
                "M/d/yyyy h:mm tt",
                "M/d/yyyy hh:mm tt",
                "MM/dd/yyyy h:mm tt",
                "MM/dd/yyyy hh:mm tt",
                "MM/dd/yyyy hh:mm:ss tt",
                "yyyy:MM:dd HH:mm:ss",
                "yyyy-MM-dd HH:mm:ss",
                "dd/MM/yyyy HH:mm:ss",
                "dd-MM-yyyy HH:mm:ss",
                "M/dd/yyyy H:m:s tt",
                "M/d/yyyy H:m:s tt"
            };

            //string dateTakenStr = Encoding.Unicode.GetString(input.);

            Console.WriteLine($"INPUT: {input}");
            Console.WriteLine($"Raw Bytes: {BitConverter.ToString(Encoding.Default.GetBytes(input))}");

            input = input.Replace("?", "");

            if (DateTime.TryParseExact(input, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate))
            {
                Console.WriteLine($"✔ Cocok format: {formats}");
                return parsedDate.ToString("yyyy-MM-dd HH:mm:ss");
            }

            if (DateTime.TryParse(input, out DateTime generalParsed))
            {
                Console.WriteLine($"✔ Sukses parse");
                return generalParsed.ToString("yyyy-MM-dd HH:mm:ss");
            }
            Console.WriteLine($"✘ Gagal parse: {input}");
            return input; // fallback jika gagal
        }


        public long? GetFileSizeBytes(string filePath)
        {
            try
            {
                FileInfo fi = new FileInfo(filePath);
                return fi.Exists ? fi.Length : 0;
            }
            catch
            {
                return null;
            }
        }
        public string FormatSize(long bytes)
        {
            if (bytes >= 1L << 30)
                return (bytes / (double)(1L << 30)).ToString("0.##") + " GB";
            if (bytes >= 1L << 20)
                return (bytes / (double)(1L << 20)).ToString("0.##") + " MB";
            if (bytes >= 1L << 10)
                return (bytes / (double)(1L << 10)).ToString("0.##") + " KB";
            return bytes + " bytes";
        }
    }
}
