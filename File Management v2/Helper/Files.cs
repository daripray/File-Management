using Microsoft.WindowsAPICodePack.Shell;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File_Management_v2.Helper
{
    internal class Files
    {
            public DateTime? DateTaken { get; set; }
            public DateTime? MediaCreated { get; set; }
            public DateTime? DateCreated { get; set; }
            public DateTime? DateModified { get; set; }
            public string FileLocation { get; set; }
            public string CameraModel { get; set; }
            // Tambah properti lain sesuai kebutuhan
        

        public static Files GetFileMetadata(string filePath)
        {
            var metadata = new Files();

            try
            {
                using (ShellObject shell = ShellObject.FromParsingName(filePath))
                {
                    var dateTakenStr = shell.Properties.System.Photo.DateTaken?.Value?.ToString(Setting.DateFormat);
                    if (DateTime.TryParseExact(dateTakenStr, Setting.DateFormat, null, DateTimeStyles.None, out var dateTaken))
                        metadata.DateTaken = dateTaken;

                    var mediaCreatedStr = shell.Properties.System.Media.DateEncoded?.Value?.ToString("yyyy-MM-dd HH:mm:ss");
                    if (DateTime.TryParseExact(mediaCreatedStr, "yyyy-MM-dd HH:mm:ss", null, DateTimeStyles.None, out var mediaCreated))
                        metadata.MediaCreated = mediaCreated;

                    metadata.DateCreated = System.IO.File.GetCreationTime(filePath);
                    metadata.DateModified = System.IO.File.GetLastWriteTime(filePath);
                    metadata.FileLocation = Path.GetDirectoryName(filePath);

                    //metadata.CameraModel = shell.Properties.System.Camera.Model?.Value?.ToString() ?? "";
                }
            }
            catch
            {
                // Optional: log error
            }

            return metadata;
        }

    }
}
