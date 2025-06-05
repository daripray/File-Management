using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File_Management_v2.Helper
{
    internal static class Status
    {

        internal static class Action
        {
            public const string None = "None";
            public const string Scan = "Scan";
            public const string Copy = "Copy";
            public const string Move = "Move";
            public const string Stop = "Stop";
        }

        internal static class Process
        {
            public const string None = "None";
            public const string Initiating = "Initiating";
            public const string Scanning = "Scanning";
            public const string Copying = "Copying";
            public const string Moving = "Moving";
            public const string Deleting = "Deleting";
            public const string Renaming = "Renaming";
            public const string Stopping = "Stopping";
            public const string Pausing = "Pausing";
            public const string Resuming = "Resuming";
            public const string Error = "Error";
            public const string Done = "Done";
        }

        internal static class Original
        {
            public const string All = "All";
            public const string Ori = "ORI";
            public const string NonOri = "NON ORI";
        }

        internal static class Scan
        {
            public const string Ok = "Ok";
            public const string Display = "Display";
            public const string Corrupt = "Corrupt";
            public const string Error = "Error";
            public const string Empty = "Empty";
        }

        internal static class Copy
        {
            public const string Success = "Success";
            public const string Failed = "Failed";
            public const string Error = "Error";
            public const string Exist = "Exist";
            public const string Copied = "Copied";
            public const string Rename = "Rename";
            public const string Skip = "Skip";
        }

        internal static class Move
        {
            public const string Success = "Success";
            public const string Failed = "Failed";
            public const string Error = "Error";
            public const string Exist = "Exist";
            public const string Moved = "Moved";
            public const string Rename = "Rename";
            public const string Skip = "Skip";
        }
    }
}
