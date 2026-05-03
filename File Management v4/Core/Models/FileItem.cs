namespace File_Management_v4.Core.Models;

public class FileItem
{
    public string Path { get; set; } = string.Empty;
    public string? DirName { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Extension { get; set; } = string.Empty;
    public long? Size { get; set; }
    public string MimeType { get; set; } = string.Empty;
    public DateTime? DateCreated { get; set; }
    public DateTime? DateModified { get; set; }

    public DateTime? DateTaken { get; set; }
    public DateTime? MediaCreated { get; set; }
    public string CameraMake { get; set; } = string.Empty;
    public string CameraModel { get; set; } = string.Empty;

    public double? DurationSeconds { get; set; }

    public bool IsOriginal =>
        DateTaken != null || MediaCreated != null;
    public DateTime? BestDate =>
        DateTaken ?? MediaCreated ?? DateCreated ?? DateModified;
    public string Category =>
    MimeType?.StartsWith("image") == true ? "IMAGE" :
    MimeType?.StartsWith("video") == true ? "VIDEO" :
    MimeType?.StartsWith("application") == true ? "DOC" :
    "OTHER";
}