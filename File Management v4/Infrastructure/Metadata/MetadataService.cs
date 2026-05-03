using File_Management_v4.Core.Interfaces;
using File_Management_v4.Core.Models;
using File_Management_v4.Helper;

namespace File_Management_v4.Infrastructure.Metadata
{
    // Ini MetadataService yang akan mengimplementasikan IMetadataServices untuk mengekstrak informasi metadata dari file.
    /// <summary>
    /// Provides functionality to extract metadata information from files.
    /// </summary>
    /// <remarks>The MetadataService class offers methods for retrieving file metadata, such as name, path,
    /// extension, size, and timestamps. It is intended for use in scenarios where file attribute information is
    /// required for processing or display purposes.</remarks>
    public class MetadataService : IMetadataServices
    {
        public FileItem Extract(string filePath)
        {
            var meta = new MetadataHelper(filePath);
            return new FileItem
            {
                Path = filePath,
                DirName = Path.GetDirectoryName(filePath),
                Name = meta.FileName ?? Path.GetFileName(filePath),
                Extension = meta.FileExtension ?? Path.GetExtension(filePath).TrimStart('.'),
                Size = meta.FileSizeBytes ?? 0,

                DateCreated = meta.DateCreated,
                DateModified = meta.DateModified,
                DateTaken = meta.DateTaken,
                MediaCreated = meta.MediaCreated,
                MimeType = meta.MimeType,
                CameraMake = meta.CameraMake,
                CameraModel = meta.CameraModel,
                DurationSeconds = meta.DurationSeconds
            };
        }
    }
}
