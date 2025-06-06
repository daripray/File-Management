using System;

namespace File_Management_v2.Helper
{
    internal static class FileStatus
    {
        internal static class Action
        {
            public const string None = "None";
            public const string Scan = "Scan";
            public const string Copy = "Copy";
            public const string Move = "Move";
        }
        internal static class Process
        {
            public const string Pending = "Pending";
            public const string Running = "Running";
            public const string Completed = "Completed";
            public const string Skipped = "Skipped";
            public const string Failed = "Failed";
            public const string Canceled = "Canceled";

            public const string Scanning = "Scanning";
            public const string Copying = "Copying";
            public const string Moving = "Moving";
            public const string Stopping = "Stopping";
            public const string Error = "Error";
        }
        internal static class Scan
        {
            public const string Ok = "Ok";
            public const string Display = "Display";
            public const string Corrupt = "Corrupt";
            public const string Error = "Error";
            public const string Empty = "Empty";
        }
        internal static class Original
        {
            public const string All = "All";
            public const string Ori = "Ori";
            public const string NonOri = "NonOri";
        }
        internal static class FileType
        {
            public const string Image = "Image";
            public const string Video = "Video";
            public const string Document = "Document";
            public const string Other = "Other";
        }
        internal static class Result
        {
            public const string None = "None";
            public const string Success = "Success";
            public const string Failed = "Failed";
            public const string Error = "Error";
            public const string Exist = "Exist";
            public const string Copied = "Copied";
            public const string Moved = "Moved";
            public const string Renamed = "Renamed";
            public const string Skipped = "Skipped";
        }
    }
}
