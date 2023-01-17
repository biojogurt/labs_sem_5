using static lab_os_3.SnapshotManager;
using static lab_os_3.ToolhelpImport;

namespace lab_os_3
{
    internal class ResultThread
    {
        private UpdateLabel UpdateLabel { get; }
        private int MaxLists { get; }
        private int MaxHeaps { get; }

        public ResultThread(UpdateLabel updateLabel, int maxLists, int maxHeaps)
        {
            Thread thread = new Thread(Run)
            {
                IsBackground = true
            };

            UpdateLabel = updateLabel;
            MaxLists = maxLists;
            MaxHeaps = maxHeaps;

            thread.Start();
        }

        private void Run()
        {
            try
            {
                IntPtr snapshot = GetSnapshot(0, SnapshotFlags.Process);

                try
                {
                    PROCESS_ENTRY_32 processWithBiggestHeap = new PROCESS_ENTRY_32();
                    HEAP_ENTRY_32 biggestHeap = new HEAP_ENTRY_32();

                    foreach (PROCESS_ENTRY_32 process in GetProcesses(snapshot))
                    {
                        IntPtr snapshotProcess = GetSnapshot(process.th32ProcessID, SnapshotFlags.HeapList);

                        try
                        {
                            foreach (HEAP_ENTRY_32 heap in GetHeaps(snapshotProcess, MaxLists, MaxHeaps))
                            {
                                if (heap.dwFlags == HeapFlags.Fixed
                                    && (biggestHeap.dwSize == IntPtr.Zero
                                        || heap.dwBlockSize.ToInt64() > biggestHeap.dwBlockSize.ToInt64()))
                                {
                                    biggestHeap = heap;
                                    processWithBiggestHeap = process;
                                }
                            }
                        }
                        catch
                        {
                            throw;
                        }
                        finally
                        {
                            CloseHandle(snapshotProcess);
                        }
                    }

                    UpdateLabel(processWithBiggestHeap.dwSize == 0 || biggestHeap.dwSize == IntPtr.Zero ?
                        "Ни одного блока кучи не было найдено" :
                        $"Самым большим объемом с фиксированной памятью в {biggestHeap.dwSize} байт обладает {processWithBiggestHeap.szExeFile}");
                }
                catch
                {
                    throw;
                }
                finally
                {
                    CloseHandle(snapshot);
                }
            }
            catch (Exception ex)
            {
                UpdateLabel(ex.Message);
            }
        }
    }
}