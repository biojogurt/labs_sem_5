namespace lab_os_2
{
    internal delegate void UpdateResult(int result);

    internal class ResultThread
    {
        private UpdateLabel UpdateLabel { get; }
        private string Path1 { get; }
        private string Path2 { get; }
        private ulong MinSize { get; }
        private int Result1 { get; set; }
        private int Result2 { get; set; }
        private object Lock1 { get; }
        private object Lock2 { get; }

        public ResultThread(string path1, string path2, ulong minSize, UpdateLabel updateLabel)
        {
            Thread thread = new Thread(Run);
            thread.IsBackground = true;

            UpdateLabel = updateLabel;
            Path1 = path1;
            Path2 = path2;
            MinSize = minSize;
            Lock1 = new object();
            Lock2 = new object();

            thread.Start();
        }

        private void Run()
        {
            Monitor.Enter(Lock1);
            Monitor.Enter(Lock2);

            SearchThread search1 = new SearchThread(UpdateResult1, Path1, MinSize);
            SearchThread search2 = new SearchThread(UpdateResult2, Path2, MinSize);

            Monitor.Wait(Lock1);
            Monitor.Wait(Lock2);

            if (Result1 == Result2)
            {
                UpdateLabel("Одинаковое количество подкаталогов");
            }
            else if (Result1 > Result2)
            {
                UpdateLabel($"В каталоге 1 больше подкаталогов на {Result1 - Result2}");
            }
            else
            {
                UpdateLabel($"В каталоге 2 больше подкаталогов на {Result2 - Result1}");
            }

            Monitor.Exit(Lock1);
            Monitor.Exit(Lock2);
        }

        private void UpdateResult1(int result)
        {
            Monitor.Enter(Lock1);

            Result1 = result;

            Monitor.Pulse(Lock1);
            Monitor.Exit(Lock1);
        }

        private void UpdateResult2(int result)
        {
            Monitor.Enter(Lock2);

            Result2 = result;

            Monitor.Pulse(Lock2);
            Monitor.Exit(Lock2);
        }
    }
}