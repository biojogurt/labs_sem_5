namespace lab_os_1
{
    internal delegate void RemoveThreadDelegate(ThreadAbstract thread);

    internal class ThreadManager
    {
        private ProgessUpdateDelegate UpdateActions { get; }
        private ProgessUpdateDelegate UpdateStartStop { get; }
        private List<ConsumerThread> ConsumerThreads { get; } = new List<ConsumerThread>();
        private List<ProducerThread> ProducerThreads { get; } = new List<ProducerThread>();
        private object Lock { get; } = new object();

        public ThreadManager(ProgessUpdateDelegate updateActions, ProgessUpdateDelegate updateStartStop)
        {
            Thread thread = new Thread(Run);
            thread.IsBackground = true;
            UpdateActions = updateActions;
            UpdateStartStop = updateStartStop;
            thread.Start();
        }

        private void Run()
        {
            Random random = new Random();
            int count = 1;
            while (true)
            {
                Monitor.Enter(Lock);
                Monitor.Exit(Lock);

                int num = random.Next(5, 20);
                ThreadBuffer threadBuffer = new ThreadBuffer(num, count);

                Monitor.Enter(Lock);
                Monitor.Exit(Lock);

                Monitor.Enter(ConsumerThreads);
                ConsumerThreads.Add(new ConsumerThread(threadBuffer, UpdateActions, UpdateStartStop, RemoveConsumerThread, num, count, Lock));
                Monitor.Exit(ConsumerThreads);
                Thread.Sleep(random.Next(5000, 10001));

                Monitor.Enter(Lock);
                Monitor.Exit(Lock);

                Monitor.Enter(ProducerThreads);
                ProducerThreads.Add(new ProducerThread(threadBuffer, UpdateActions, UpdateStartStop, RemoveProducerThread, num, count, Lock));
                Monitor.Exit(ProducerThreads);
                Thread.Sleep(random.Next(5000, 10001));

                count++;
            }
        }

        private void RemoveConsumerThread(ThreadAbstract thread)
        {
            Monitor.Enter(ConsumerThreads);
            ConsumerThreads.Remove((ConsumerThread)thread);
            Monitor.Exit(ConsumerThreads);
        }

        private void RemoveProducerThread(ThreadAbstract thread)
        {
            Monitor.Enter(ProducerThreads);
            ProducerThreads.Remove((ProducerThread)thread);
            Monitor.Exit(ProducerThreads);
        }

        public void PauseAll()
        {
            Monitor.Enter(Lock);
        }

        public void ResumeAll()
        {
            Monitor.Exit(Lock);
        }
    }
}