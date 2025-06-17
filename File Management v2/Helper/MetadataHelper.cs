using MetadataExtractor;
using MetadataExtractor.Formats.Exif;
using MetadataExtractor.Formats.FileSystem;
using MetadataExtractor.Formats.FileType;
using MetadataExtractor.Formats.Iptc;
using MetadataExtractor.Formats.Jpeg;
using MetadataExtractor.Formats.QuickTime;
using Microsoft.WindowsAPICodePack.Shell;
using System;
using System.IO;
using System.Reflection;

// Alias untuk menghindari konflik dengan System.IO.Directory
using MetadataDirectory = MetadataExtractor.Directory;

namespace File_Management_v2.Helper
{
    public class MetadataHelper
    {
        // Metadata properties
        public string FilePath { get; set; } = "";
        public string FileName { get; set; } = "";
        public long? FileSizeBytes { get; set; } = null;
        public string FileExtension { get; set; } = "";
        public string MimeType { get; set; } = "";
        public DateTime? DateCreated { get; set; } = null;
        public DateTime? DateModified { get; set; } = null;

        // EXIF SubIFD
        public DateTime? DateTaken { get; set; } = null;
        public int? Iso { get; set; } = null;
        public string ExposureTime { get; set; } = "";
        public string Aperture { get; set; } = "";

        // EXIF IFD0
        public string CameraMake { get; set; } = "";
        public string CameraModel { get; set; } = "";
        public string Orientation { get; set; } = "";

        // GPS
        public string Latitude { get; set; } = "";
        public string Longitude { get; set; } = "";

        // IPTC
        public string Author { get; set; } = "";
        public string Caption { get; set; } = "";

        // QuickTime
        public DateTime? MediaCreated { get; set; } = null;
        public double? DurationSeconds { get; set; } = null;

        // Shell properties
        public string Title { get; set; } = "";
        public string Subject { get; set; } = "";
        public string Rating { get; set; } = "";
        public string Tags { get; set; } = "";

        public MetadataHelper() { }

        public MetadataHelper(string filePath)
        {
            Set(filePath);
        }

        public void Set(string filePath)
        {
            Clear();

            if (!File.Exists(filePath)) return;

            FilePath = filePath;
            //FileName = Path.GetFileName(filePath);
            //FileSizeBytes = new FileInfo(filePath).Length;
            DateCreated = new FileInfo(filePath).CreationTime;
            //DateModified = new FileInfo(filePath).LastWriteTime.ToString();

            var directories = ImageMetadataReader.ReadMetadata(filePath);

            foreach (var dir in directories)
            {
                switch (dir)
                {
                    // File metadata
                    case FileMetadataDirectory fileMeta:
                        FileName = fileMeta.GetDescription(FileMetadataDirectory.TagFileName);
                        FileSizeBytes = TryGetLong(fileMeta, FileMetadataDirectory.TagFileSize);
                        DateModified = fileMeta.GetDateTime(FileMetadataDirectory.TagFileModifiedDate);
                        break;

                    // File system metadata
                    case FileTypeDirectory fileType:
                        FileExtension = fileType.GetDescription(FileTypeDirectory.TagExpectedFileNameExtension);
                        var detectedType = fileType.GetDescription(FileTypeDirectory.TagDetectedFileTypeName);
                        MimeType = GetMimeTypeFromExtension(FileExtension);
                        break;

                    // EXIF metadata
                    case ExifSubIfdDirectory exifSub:
                        DateTaken = TryGetDateTime(exifSub, ExifDirectoryBase.TagDateTimeOriginal);
                        Iso = TryGetInt(exifSub, ExifDirectoryBase.TagIsoEquivalent);
                        ExposureTime = exifSub.GetDescription(ExifDirectoryBase.TagExposureTime);
                        Aperture = exifSub.GetDescription(ExifDirectoryBase.TagFNumber);
                        break;

                    // EXIF IFD0 metadata
                    case ExifIfd0Directory exif0:
                        CameraMake = exif0.GetDescription(ExifDirectoryBase.TagMake);
                        CameraModel = exif0.GetDescription(ExifDirectoryBase.TagModel);
                        Orientation = exif0.GetDescription(ExifDirectoryBase.TagOrientation);
                        break;

                    // GPS metadata
                    case GpsDirectory gps:
                        var loc = gps.GetGeoLocation();
                        if (loc != null)
                        {
                            Latitude = loc.Latitude.ToString("F6");
                            Longitude = loc.Longitude.ToString("F6");
                        }
                        break;

                    // Jpeg metadata
                    case IptcDirectory iptc:
                        Author = iptc.GetDescription(IptcDirectory.TagByLine);
                        Caption = iptc.GetDescription(IptcDirectory.TagCaption);
                        break;

                    // QuickTime metadata
                    case QuickTimeMovieHeaderDirectory qt:
                        if (qt.ContainsTag(QuickTimeMovieHeaderDirectory.TagCreated))
                            MediaCreated = qt.GetDateTime(QuickTimeMovieHeaderDirectory.TagCreated);

                        if (qt.ContainsTag(QuickTimeMovieHeaderDirectory.TagDuration))
                        {
                            var raw = qt.GetObject(QuickTimeMovieHeaderDirectory.TagDuration);

                            if (raw is TimeSpan ts)
                            {
                                DurationSeconds = ts.TotalSeconds;
                            }
                            else if (raw is double d)
                            {
                                DurationSeconds = d;
                            }
                            else if (double.TryParse(raw?.ToString(), out double dParsed))
                            {
                                DurationSeconds = dParsed;
                            }
                        }
                        break;
                }
            }

            // Windows Shell (untuk title, subject, rating, tags)
            try
            {
                using var shell = ShellObject.FromParsingName(filePath);
                Title = shell.Properties.System.Title.Value;
                Subject = shell.Properties.System.Subject.Value;
                Tags = shell.Properties.System.Keywords.Value != null ? string.Join(", ", shell.Properties.System.Keywords.Value) : null;
                Rating = shell.Properties.System.Rating.Value?.ToString();
            }
            catch
            {
                // Shell metadata not available or file type not supported
            }
        }

        public void Clear()
        {
            FilePath = FileName = FileExtension = MimeType = CameraMake = CameraModel = Orientation =
            Latitude = Longitude = Author = Caption = ExposureTime = Aperture = null;

            FileSizeBytes = null;
            DateTaken = MediaCreated = DateCreated = DateModified = null;
            Iso = null;
            DurationSeconds = null;
        }

        // Safe Getter Helpers
        private DateTime? TryGetDateTime(MetadataDirectory dir, int tag)
        {
            return dir.ContainsTag(tag) ? dir.GetDateTime(tag) : null;
        }

        private int? TryGetInt(MetadataDirectory dir, int tag)
        {
            return dir.ContainsTag(tag) ? dir.GetInt32(tag) : null;
        }

        private long? TryGetLong(MetadataDirectory dir, int tag)
        {
            if (dir.ContainsTag(tag))
            {
                var obj = dir.GetObject(tag);
                if (obj is long l) return l;
                if (long.TryParse(obj?.ToString(), out long parsed)) return parsed;
            }
            return null;
        }

        private double? TryGetDouble(MetadataDirectory dir, int tag)
        {
            if (dir.ContainsTag(tag))
            {
                var obj = dir.GetObject(tag);
                if (obj is double d) return d;
                if (double.TryParse(obj?.ToString(), out double parsed)) return parsed;
            }
            return null;
        }
        private string GetMimeTypeFromExtension(string ext)
        {
            ext = ext?.ToLowerInvariant().Trim('.');

            return ext switch
            {
                // Images
                "jpg" or "jpeg" => "image/jpeg",
                "png" => "image/png",
                "gif" => "image/gif",
                "bmp" => "image/bmp",
                "tiff" or "tif" => "image/tiff",
                "webp" => "image/webp",
                "heic" => "image/heic",
                "heif" => "image/heif",
                "raw" => "image/x-raw",
                "cr2" => "image/x-canon-cr2",
                "nef" => "image/x-nikon-nef",
                "orf" => "image/x-olympus-orf",
                "sr2" => "image/x-sony-sr2",
                "arw" => "image/x-sony-arw",
                "dng" => "image/x-adobe-dng",
                "psd" => "image/vnd.adobe.photoshop",
                "ico" => "image/x-icon",
                "svg" => "image/svg+xml",

                // Videos
                "mp4" => "video/mp4",
                "mov" => "video/quicktime",
                "avi" => "video/x-msvideo",
                "mkv" => "video/x-matroska",
                "flv" => "video/x-flv",
                "wmv" => "video/x-ms-wmv",
                "m4v" => "video/x-m4v",
                "webm" => "video/webm",
                "mpg" or "mpeg" => "video/mpeg",
                "3gp" => "video/3gpp",
                "mts" or "m2ts" or "ts" => "video/mp2t",
                "ogv" => "video/ogg",

                // Docs
                "doc" => "application/msword",
                "docx" => "application/vnd.openxmlformats-officedocument.wordprocessingml.document",
                "pdf" => "application/pdf",
                "xls" => "application/vnd.ms-excel",
                "xlsx" => "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                "ppt" => "application/vnd.ms-powerpoint",
                "pptx" => "application/vnd.openxmlformats-officedocument.presentationml.presentation",
                "txt" => "text/plain",
                "rtf" => "application/rtf",
                "odt" => "application/vnd.oasis.opendocument.text",
                "ods" => "application/vnd.oasis.opendocument.spreadsheet",
                "odp" => "application/vnd.oasis.opendocument.presentation",
                "csv" => "text/csv",
                "xml" => "application/xml",
                "html" or "htm" => "text/html",
                "json" => "application/json",
                "md" => "text/markdown",
                "log" => "text/plain",

                // Default fallback
                _ => "application/octet-stream",
            };
        }

    }
}
