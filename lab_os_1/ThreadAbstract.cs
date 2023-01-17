namespace lab_os_1
{
    internal abstract class ThreadAbstract
    {
        protected ThreadBuffer ThreadBuffer { get; }
        protected ProgessUpdateDelegate UpdateActions { get; }
        protected ProgessUpdateDelegate UpdateStartStop { get; }
        protected RemoveThreadDelegate RemoveThread { get; }
        protected int DataCount { get; set; }
        protected int ThreadName { get; }
        protected object Lock { get; }

        public ThreadAbstract(ThreadBuffer buffer, ProgessUpdateDelegate updateActions, ProgessUpdateDelegate updateStartStop, RemoveThreadDelegate removeThread, int datacount, int threadName, object _lock)
        {
            Thread thread = new Thread(Run);
            thread.IsBackground = true;
            ThreadBuffer = buffer;
            UpdateActions = updateActions;
            UpdateStartStop = updateStartStop;
            RemoveThread = removeThread;
            DataCount = datacount;
            ThreadName = threadName;
            Lock = _lock;
            thread.Start();
        }

        protected abstract void Run();
    }
}