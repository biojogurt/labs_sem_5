using System.Runtime.InteropServices;

namespace lab_os_3
{
    internal class ToolhelpImport
    {
        [Flags]
        internal enum SnapshotFlags : uint
        {
            HeapList = 0x00000001,
            Process = 0x00000002,
            Thread = 0x00000004,
            Module = 0x00000008,
            All = HeapList | Process | Thread | Module
        }

        [Flags]
        internal enum HeapFlags : uint
        {
            Fixed = 0x00000001,
            Free = 0x00000002,
            Moveable = 0x00000004
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct PROCESS_ENTRY_32
        {
            internal uint dwSize;
            internal uint cntUsage;
            internal uint th32ProcessID;
            internal IntPtr th32DefaultHeapID;
            internal uint th32ModuleID;
            internal uint cntThreads;
            internal uint th32ParentProcessID;
            internal long pcPriClassBase;
            internal SnapshotFlags dwFlags;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            internal string szExeFile;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        internal struct HEAP_LIST_32
        {
            internal IntPtr dwSize;
            internal uint th32ProcessID;
            internal IntPtr th32HeapID;
            internal uint dwFlags;
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct HEAP_ENTRY_32
        {
            internal IntPtr dwSize;
            internal IntPtr hHandle;
            internal IntPtr dwAddress;
            internal IntPtr dwBlockSize;
            internal HeapFlags dwFlags;
            internal uint dwLockCount;
            internal uint dwResvd;
            internal uint th32ProcessID;
            internal IntPtr th32HeapID;
        }

        [DllImport("kernel32", SetLastError = true)]
        internal static extern IntPtr CreateToolhelp32Snapshot([In] SnapshotFlags dwFlags, [In] uint th32ProcessID);

        [DllImport("kernel32", SetLastError = true)]
        internal static extern bool CloseHandle([In] IntPtr hSnapshot);

        [DllImport("kernel32", SetLastError = true)]
        internal static extern bool Process32First([In] IntPtr hSnapshot, [In, Out] ref PROCESS_ENTRY_32 lppe);

        [DllImport("kernel32", SetLastError = true)]
        internal static extern bool Process32Next([In] IntPtr hSnapshot, [Out] out PROCESS_ENTRY_32 lppe);

        [DllImport("kernel32", SetLastError = true)]
        internal static extern bool Heap32ListFirst([In] IntPtr hSnapshot, [In, Out] ref HEAP_LIST_32 lphl);

        [DllImport("kernel32", SetLastError = true)]
        internal static extern bool Heap32ListNext([In] IntPtr hSnapshot, [Out] out HEAP_LIST_32 lphl);

        [DllImport("kernel32", SetLastError = true)]
        internal static extern bool Heap32First([In, Out] ref HEAP_ENTRY_32 lphe, [In] uint th32ProcessID, [In] IntPtr th32HeapID);

        [DllImport("kernel32", SetLastError = true)]
        internal static extern bool Heap32Next([Out] out HEAP_ENTRY_32 lphe);

        internal static readonly IntPtr INVALID_HANDLE_VALUE = new IntPtr(-1);
    }
}