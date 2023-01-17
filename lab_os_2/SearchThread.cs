using static lab_os_2.FileManager;

namespace lab_os_2
{
    internal class SearchThread
    {
        private UpdateResult UpdateResult { get; }
        private string Path { get; }
        private ulong MinSize { get; }

        public SearchThread(UpdateResult updateResult, string path, ulong minSize)
        {
            Thread thread = new Thread(Run);
            thread.Name = path;
            thread.IsBackground = true;

            UpdateResult = updateResult;
            Path = path;
            MinSize = minSize;

            thread.Start();
        }

        private void Run()
        {
            int result = 0;

            foreach (ulong sum in GetQualifiedSums(Path, MinSize))
            {
                result++;
            }

            UpdateResult(result);
        }
    }
}