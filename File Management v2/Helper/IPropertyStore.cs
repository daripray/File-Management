using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace File_Management_v2.Helper
{
    [ComImport]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("886d8eeb-8cf2-4446-8d02-cdba1dbdcf99")]
    internal interface IPropertyStore
    {
        uint GetCount(out uint propertyCount);
        uint GetAt(uint propertyIndex, out PropertyKey key);
        uint GetValue(ref PropertyKey key, out PropVariant pv);
        uint SetValue(ref PropertyKey key, ref PropVariant pv);
        uint Commit();
    }

    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct PropertyKey
    {
        public Guid fmtid;
        public uint pid;

        public PropertyKey(Guid formatId, uint propertyId)
        {
            fmtid = formatId;
            pid = propertyId;
        }
    }

    [StructLayout(LayoutKind.Explicit)]
    public struct PropVariant
    {
        [FieldOffset(0)] public ushort vt;
        [FieldOffset(8)] public long hVal;

        public static PropVariant FromDateTime(DateTime dateTime)
        {
            return new PropVariant
            {
                vt = 64, // VT_FILETIME
                hVal = dateTime.ToFileTime()
            };
        }
    }

    static class NativeMethods
    {
        [DllImport("propsys.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern int SHGetPropertyStoreFromParsingName(
            [In][MarshalAs(UnmanagedType.LPWStr)] string pszPath,
            [In] IntPtr zeroWorks,
            [In] GETPROPERTYSTOREFLAGS flags,
            [In] ref Guid iid,
            [Out] out IPropertyStore propertyStore);
    }

    [Flags]
    public enum GETPROPERTYSTOREFLAGS
    {
        DEFAULT = 0,
        HANDLERPROPERTIESONLY = 0x1,
        READWRITE = 0x2,
        TEMPORARY = 0x4,
        FASTPROPERTIESONLY = 0x8,
        OPENSLOWITEM = 0x10,
        DELAYCREATION = 0x20,
        BESTEFFORT = 0x40,
        NO_OPLOCK = 0x80,
        PREFERQUERYPROPERTIES = 0x100,
        EXTRINSICPROPERTIES = 0x200,
        EXTRINSICPROPERTIESONLY = 0x400,
        VOLATILEPROPERTIES = 0x800,
        VOLATILEPROPERTIESONLY = 0x1000
    }
}
