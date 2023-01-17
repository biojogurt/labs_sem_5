namespace lab_os_1
{
    internal class ConsumerThread : ThreadAbstract
    {
        public ConsumerThread(ThreadBuffer buffer, ProgessUpdateDelegate updateActions, ProgessUpdateDelegate updateStartStop, RemoveThreadDelegate removeThread, int datacount, int threadName, object _lock) 
            : base(buffer, updateActions, updateStartStop, removeThread, datacount, threadName, _lock)
        {
        }

        protected override void Run()
        {
            UpdateStartStop($"Потребитель {ThreadName} начался");

            Random random = new Random();
            while (DataCount != 0)
            {
                Monitor.Enter(Lock);
                Monitor.Exit(Lock);

                bool result = ThreadBuffer.TryPop(out int num);

                if (result)
                {
                    DataCount--;
                    UpdateActions($"Потребитель {ThreadName} взял цифру {num}\r\nБуфер {ThreadBuffer.BufferName}: {ThreadBuffer.Count} из {ThreadBuffer.MaxSize}");
                }

                Monitor.Enter(Lock);
                Monitor.Exit(Lock);

                if (DataCount != 0)
                {
                    Thread.Sleep(random.Next(1000, 3001));
                }
            }

            RemoveThread(this);
            UpdateStartStop($"Потребитель {ThreadName} остановился");
        }
    }
}