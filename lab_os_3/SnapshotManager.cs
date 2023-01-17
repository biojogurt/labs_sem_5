using System.ComponentModel;
using System.Runtime.InteropServices;
using static lab_os_3.ToolhelpImport;

namespace lab_os_3
{
    internal class SnapshotManager
    {
        internal static IntPtr GetSnapshot(uint processID, SnapshotFlags flags)
        {
            IntPtr shapshot = CreateToolhelp32Snapshot(flags, processID);

            return shapshot == INVALID_HANDLE_VALUE
                ? throw new Win32Exception(Marshal.GetLastWin32Error())
                : shapshot;
        }

        private static IEnumerable<HEAP_LIST_32> GetHeapLists(IntPtr shapshot, int maxLists)
        {
            HEAP_LIST_32 findData = new HEAP_LIST_32
            {
                dwSize = (IntPtr) Marshal.SizeOf(typeof(HEAP_LIST_32))
            };

            if (!Heap32ListFirst(shapshot, ref findData))
            {
                throw new Win32Exception(Marshal.GetLastWin32Error());
            }

            int countLists = 0;

            do
            {
                countLists++;
                yield return findData;
            }
            while (countLists < maxLists && Heap32ListNext(shapshot, out findData));
        }

        internal static IEnumerable<HEAP_ENTRY_32> GetHeaps(IntPtr shapshot, int maxLists, int MaxHeaps)
        {
            foreach (HEAP_LIST_32 heapList in GetHeapLists(shapshot, maxLists))
            {
                HEAP_ENTRY_32 findData = new HEAP_ENTRY_32
                {
                    dwSize = (IntPtr) Marshal.SizeOf(typeof(HEAP_ENTRY_32))
                };

                if (!Heap32First(ref findData, heapList.th32ProcessID, heapList.th32HeapID))
                {
                    throw new Win32Exception(Marshal.GetLastWin32Error());
                }

                int countEntries = 0;

                do
                {
                    countEntries++;
                    yield return findData;
                }
                while (countEntries < MaxHeaps && Heap32Next(out findData));
            }
        }

        internal static IEnumerable<PROCESS_ENTRY_32> GetProcesses(IntPtr shapshot)
        {
            PROCESS_ENTRY_32 findData = new PROCESS_ENTRY_32
            {
                dwSize = (uint) Marshal.SizeOf(typeof(PROCESS_ENTRY_32))
            };

            if (!Process32First(shapshot, ref findData))
            {
                throw new Win32Exception(Marshal.GetLastWin32Error());
            }

            do
            {
                yield return findData;
            }
            while (Process32Next(shapshot, out findData));
        }
    }
}