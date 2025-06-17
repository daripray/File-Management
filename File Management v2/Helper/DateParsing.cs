using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace File_Management_v2.Helper
{
    /** Kelas ini bertanggung jawab untuk parsing tanggal dari nama file video
     * dan mengisi metadata yang hilang seperti tanggal rilis, produser, dan penerbit.
     * Juga mengatur waktu pembuatan, modifikasi, dan akses file sesuai dengan metadata.
     * cara pakai:
     * FillMissingMetadata(@"D:\Video\VID20170104111805.mp4");
     */
    internal class DateParsing
    {
        public static DateTime? ParseDateFromFileName(string filePath)
        {
            string fileName = Path.GetFileNameWithoutExtension(filePath);

            // Pola 1: VID_YYYYMMDD_HHMMSS (contoh: VID_20160815_001416)
            var match1 = Regex.Match(fileName, @"VID[_-]?(\d{8})[_-]?(\d{6})");

            // Pola 2: VIDYYYYMMDDHHMMSS (contoh: VID20170104111805)
            var match2 = Regex.Match(fileName, @"VID(\d{14})");

            // Pola 3: VID-YYYYMMDD-HHMMSS (contoh: VID-20230101-235959)
            var match3 = Regex.Match(fileName, @"VID-(\d{8})-(\d{6})");

            // Pola 4: Epoch milidetik (contoh: 1595510863283)
            if (long.TryParse(fileName, out long epochMillis))
            {
                try
                {
                    DateTimeOffset dto = DateTimeOffset.FromUnixTimeMilliseconds(epochMillis);
                    return dto.LocalDateTime;
                }
                catch (ArgumentOutOfRangeException)
                {
                    // Invalid timestamp
                }
            }

            // Pola 5: YYYYMMDD_HHMMSS_mmm (contoh: 20250326_123654_808)
            var match5 = Regex.Match(fileName, @"(\d{8})_(\d{6})_(\d{3})");
            if (match5.Success)
            {
                string dateTime = match5.Groups[1].Value + match5.Groups[2].Value + match5.Groups[3].Value; // yyyyMMddHHmmssfff
                if (DateTime.TryParseExact(dateTime, "yyyyMMddHHmmssfff", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsed))
                    return parsed;
            }

            // Pola 6: VID-YYYYMMDD-WAXXXX (contoh: VID-20190208-WA0005)
            var match6 = Regex.Match(fileName, @"VID-(\d{8})-WA\d+");
            if (match6.Success)
            {
                string date = match6.Groups[1].Value;
                if (DateTime.TryParseExact(date, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsed))
                {
                    return parsed; // waktu 00:00:00 default
                    return parsed.Date; // Return tanggal saja, jam=0
                }
            }

            if (match1.Success)
            {
                string dateTime = match1.Groups[1].Value + match1.Groups[2].Value;
                if (DateTime.TryParseExact(dateTime, "yyyyMMddHHmmss", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsed))
                    return parsed;
            }
            else if (match2.Success)
            {
                string dateTime = match2.Groups[1].Value;
                if (DateTime.TryParseExact(dateTime, "yyyyMMddHHmmss", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsed))
                    return parsed;
            }
            else if (match3.Success)
            {
                string dateTime = match3.Groups[1].Value + match3.Groups[2].Value;
                if (DateTime.TryParseExact(dateTime, "yyyyMMddHHmmss", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsed))
                    return parsed;
            }

            return null;
        }


        public static void SetReleaseDate(string filePath, DateTime date)
        {
            var PKEY_Media_ReleaseDate = new PropertyKey(new Guid("DE41CC29-6971-4290-B472-F59F2E2F31E2"), 15);
            SetShellPropertyDateTime(filePath, PKEY_Media_ReleaseDate, date);
        }

        public static void SetProducer(string filePath, string producer)
        {
            var PKEY_Media_Producer = new PropertyKey(new Guid("F487F8EA-37C3-4FB0-9F44-816AB744F671"), 100);
            SetShellPropertyString(filePath, PKEY_Media_Producer, producer);
        }

        public static void SetPublisher(string filePath, string publisher)
        {
            var PKEY_Media_Publisher = new PropertyKey(new Guid("DDECC9A5-6221-4C69-8898-DF54D38F3E10"), 100);
            SetShellPropertyString(filePath, PKEY_Media_Publisher, publisher);
        }

        public static void FillMissingMetadata(string filePath)
        {
            string mediaCreated = FileProperty.GetProperty(filePath, "Media created");

            if (string.IsNullOrWhiteSpace(mediaCreated))
            {
                var parsedDate = ParseDateFromFileName(filePath);
                if (parsedDate.HasValue)
                {
                    Console.WriteLine("Mengisi metadata berdasarkan nama file: " + parsedDate.Value);

                    SetReleaseDate(filePath, parsedDate.Value);
                    SetProducer(filePath, "Daripray");
                    SetPublisher(filePath, "Daripray");

                    File.SetCreationTime(filePath, parsedDate.Value);
                    File.SetLastWriteTime(filePath, parsedDate.Value);
                    File.SetLastAccessTime(filePath, parsedDate.Value);
                }
                else
                {
                    Console.WriteLine("Gagal parsing tanggal dari nama file.");
                }
            }
            else
            {
                Console.WriteLine("Metadata 'Media created' sudah ada: " + mediaCreated);
            }
        }


        # region Helper Methods

        // / Helper method to set a DateTime property in the shell
        public static void SetShellPropertyDateTime(string filePath, PropertyKey key, DateTime value)
        {
            var iid = typeof(IPropertyStore).GUID;
            int hr = NativeMethods.SHGetPropertyStoreFromParsingName(
                filePath, IntPtr.Zero, GETPROPERTYSTOREFLAGS.READWRITE, ref iid, out var propertyStore);

            if (hr != 0 || propertyStore == null) return;

            var pv = PropVariant.FromDateTime(value);
            propertyStore.SetValue(ref key, ref pv);
            propertyStore.Commit();
        }

        public static void SetShellPropertyString(string filePath, PropertyKey key, string value)
        {
            var iid = typeof(IPropertyStore).GUID;
            int hr = NativeMethods.SHGetPropertyStoreFromParsingName(
                filePath, IntPtr.Zero, GETPROPERTYSTOREFLAGS.READWRITE, ref iid, out var propertyStore);

            if (hr != 0 || propertyStore == null) return;

            using var pv = new PropVariantString(value);
            propertyStore.SetValue(ref key, ref pv.Variant);
            propertyStore.Commit();
        }
        public sealed class PropVariantString : IDisposable
        {
            public PropVariant Variant;

            public PropVariantString(string value)
            {
                Variant = new PropVariant
                {
                    vt = 31, // VT_LPWSTR
                };

                Variant.hVal = Marshal.StringToCoTaskMemUni(value).ToInt64();
            }

            public void Dispose()
            {
                if (Variant.hVal != 0)
                {
                    Marshal.FreeCoTaskMem(new IntPtr(Variant.hVal));
                    Variant.hVal = 0;
                }
            }
        }
        # endregion Helper Methods 

    }
}
