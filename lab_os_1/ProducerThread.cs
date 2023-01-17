namespace lab_os_1
{
    internal class ProducerThread : ThreadAbstract
    {
        public ProducerThread(ThreadBuffer buffer, ProgessUpdateDelegate updateActions, ProgessUpdateDelegate updateStartStop, RemoveThreadDelegate removeThread, int datacount, int threadName, object _lock) 
            : base(buffer, updateActions, updateStartStop, removeThread, datacount, threadName, _lock)
        {
        }

        protected override void Run()
        {
            UpdateStartStop($"Поставщик {ThreadName} начался");

            Random random = new Random();
            int num = random.Next();
            while (DataCount != 0)
            {
                Monitor.Enter(Lock);
                Monitor.Exit(Lock);

                bool result = ThreadBuffer.TryPush(num);

                if (result)
                {
                    DataCount--;
                    UpdateActions($"Поставщик {ThreadName} поместил цифру {num}\r\nБуфер {ThreadBuffer.BufferName}: {ThreadBuffer.Count} из {ThreadBuffer.MaxSize}");
                    num = random.Next();
                }

                Monitor.Enter(Lock);
                Monitor.Exit(Lock);

                if (DataCount != 0)
                {
                    Thread.Sleep(random.Next(1000, 3001));
                }
            }

            RemoveThread(this);
            UpdateStartStop($"Поставщик {ThreadName} остановился");
        }
    }
}