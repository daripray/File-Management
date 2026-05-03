using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File_Management_v3.Library
{
    internal class Format
    {
        /// <summary>
        /// Format ukuran file dalam byte ke string yang lebih mudah dibaca (KB, MB, GB, dll).
        /// </summary>
        /// <param name="bytes">Ukuran file dalam byte.</param>
        /// <returns>String yang mewakili ukuran file dalam format yang lebih mudah dibaca.</returns>
        public static string FormatSize(long bytes)
        {
            if (bytes < 0) return "0 B";
            if (bytes == 0) return "0 B";
            string[] sizes = { "B", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };
            int order = 0;
            while (bytes >= 1024 && order < sizes.Length - 1)
            {
                order++;
                bytes /= 1024;
            }
            return $"{bytes:0.##} {sizes[order]}";
        }

        // format tanggal menjadi "yyyy-MM-dd HH:mm:ss"
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
            if (DateTime.TryParseExact(input, formats, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out DateTime parsedDate))
            {
                return parsedDate.ToString(Setting.DateFormat);
            }
            if (DateTime.TryParse(input, out DateTime generalParsed))
            {
                return generalParsed.ToString(Setting.DateFormat);
            }
            
            return input; // fallback jika gagal
        }


        public static long? GetFileSizeBytes(string filePath)
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

        public static string FormatSizeOld(long bytes)
        {
            if (bytes >= 1L << 30)
                return (bytes / (double)(1L << 30)).ToString("0.##") + " GB";
            if (bytes >= 1L << 20)
                return (bytes / (double)(1L << 20)).ToString("0.##") + " MB";
            if (bytes >= 1L << 10)
                return (bytes / (double)(1L << 10)).ToString("0.##") + " KB";
            return bytes + " bytes";
        }

        public string ConvertToDotNetDateFormat(string format)
        {
            if (string.IsNullOrWhiteSpace(format))
                return format;

            return format
                .Replace("YYYY", "yyyy") // tahun
                .Replace("YY", "yy")
                .Replace("MM", "MM")     // bulan (sama, tapi biar jelas)
                .Replace("DD", "dd")     // hari
                .Replace("dd", "dd")     // jaga-jaga
                .Replace("HH", "HH")     // jam
                .Replace("mm", "mm")     // menit
                .Replace("ss", "ss");    // detik
        }
    }
}
