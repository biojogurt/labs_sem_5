using static lab_os_4.Imports;

namespace lab_os_4
{
    public class Manager
    {
        public Queue<uint> Queue { get; } = new Queue<uint>();
        public uint ID { get; internal set; }
        private Thread Thread { get; }
        private bool Busy { get; set; } = false;
        private bool IsPaused { get; set; } = false;
        public bool IsReady { get; internal set; } = false;

        public Manager()
        {
            Thread = new Thread(Run)
            {
                IsBackground = true,
                Name = "Manager"
            };
        }

        public void Start()
        {
            Thread.Start();
        }

        public void Pause()
        {
            IsPaused = true;
        }

        public void Unpause()
        {
            IsPaused = false;
        }

        private void Run()
        {
            ID = GetCurrentThreadId();
            PeekMessage(out MSG message, IntPtr.Zero, 0, 0, 0x0000);
            IsReady = true;

            while (true)
            {
                while (IsPaused)
                { }

                if (PeekMessage(out message, new IntPtr(-1), 0, 0, 0x0001))
                {
                    switch (message.message)
                    {
                        case Messages.WM_REQUEST:
                            while (IsPaused)
                            { }

                            if (!Busy)
                            {
                                PostThreadMessage((uint) message.wParam, (uint) Messages.WM_GRANTED, IntPtr.Zero, IntPtr.Zero);
                                Busy = true;
                            }
                            else
                            {
                                PostThreadMessage((uint) message.wParam, (uint) Messages.WM_WAIT, IntPtr.Zero, IntPtr.Zero);
                                lock (Queue)
                                {
                                    Queue.Enqueue((uint) message.wParam);
                                }
                            }

                            while (IsPaused)
                            { }

                            break;

                        case Messages.WM_FINISHED:
                            while (IsPaused)
                            { }

                            lock (Queue)
                            {
                                if (Queue.Count != 0)
                                {
                                    PostThreadMessage(Queue.Dequeue(), (uint) Messages.WM_GRANTED, IntPtr.Zero, IntPtr.Zero);
                                }
                                else
                                {
                                    Busy = false;
                                }
                            }

                            while (IsPaused)
                            { }

                            break;

                        default:
                            while (IsPaused)
                            { }
                            break;
                    }
                }
            }
        }
    }
}