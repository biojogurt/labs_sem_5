namespace lab_os_1
{
    internal class ThreadBuffer
    {
        private Stack<int> Stack { get; }
        public int MaxSize { get; }
        public int Count { get => Stack.Count; }
        public int BufferName { get; }

        public ThreadBuffer(int maxsize, int count)
        {
            Stack = new Stack<int>(maxsize);
            MaxSize = maxsize;
            BufferName = count;
        }

        public bool TryPop(out int data)
        {
            Monitor.Enter(this);

            if (Stack.Count == 0)
            {
                data = 0;
                Monitor.Exit(this);
                return false;
            }

            data = Stack.Pop();
            Monitor.Exit(this);
            return true;
        }

        public bool TryPush(int data)
        {
            Monitor.Enter(this);

            if (Stack.Count == MaxSize)
            {
                Monitor.Exit(this);
                return false;
            }

            Stack.Push(data);
            Monitor.Exit(this);
            return true;
        }
    }
}