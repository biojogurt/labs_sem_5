using static lab_os_4.Imports;

namespace lab_os_4
{
    public enum State
    {
        Idle,
        Requesting,
        Waiting,
        Working
    }

    public class Writer
    {
        private static Random Random { get; } = new Random();
        private uint ManagerID { get; }
        public uint ID { get; private set; }
        private Thread Thread { get; }
        private bool IsPaused { get; set; } = false;
        public bool IsReady { get; private set; } = false;
        public State State { get; private set; }
        public int X { get; }
        public int Y { get; }

        public Writer(uint managerID, int x, int y)
        {
            ManagerID = managerID;
            X = x;
            Y = y;
            Thread = new Thread(Run)
            {
                IsBackground = true
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
            Thread.Name = "Worker " + ID;
            IsReady = true;

            while (true)
            {
                switch (State)
                {
                    case State.Idle:
                        while (IsPaused)
                        { }

                        State = State.Requesting;
                        Thread.Sleep(Random.Next(500, 1000));
                        PostThreadMessage(ManagerID, (uint) Messages.WM_REQUEST, new IntPtr(ID), IntPtr.Zero);
                        State = State.Waiting;

                        while (IsPaused)
                        { }

                        break;

                    case State.Waiting:
                        if (PeekMessage(out MSG message, new IntPtr(-1), 0, 0, 0x0001))
                        {
                            switch (message.message)
                            {
                                case Messages.WM_WAIT:
                                    while (IsPaused)
                                    { }
                                    break;

                                case Messages.WM_GRANTED:
                                    while (IsPaused)
                                    { }

                                    State = State.Working;
                                    Thread.Sleep(Random.Next(3000, 5000));

                                    while (IsPaused)
                                    { }

                                    PostThreadMessage(ManagerID, (uint) Messages.WM_FINISHED, IntPtr.Zero, IntPtr.Zero);
                                    State = State.Idle;
                                    Thread.Sleep(Random.Next(8000, 10000));

                                    while (IsPaused)
                                    { }

                                    break;

                                default:
                                    while (IsPaused)
                                    { }
                                    break;
                            }
                        }
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