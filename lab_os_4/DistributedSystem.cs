namespace lab_os_4
{
    public class DistributedSystem
    {
        private static DistributedSystem? Instance { get; set; }
        public Manager? Manager { get; private set; }
        public List<Writer>? Writers { get; private set; }
        public Thread? Thread { get; private set; }

        private DistributedSystem()
        { }

        public static DistributedSystem GetInstance()
        {
            if (Instance == null)
            {
                Instance = new DistributedSystem();
                Instance.Thread = new Thread(Instance.Run);
                Instance.Thread.Start();
            }

            return Instance;
        }

        private void Run()
        {
            Resource.GetInstance();

            Manager = new Manager();
            Manager.Start();
            while (!Manager.IsReady)
            { }

            Writers = new List<Writer>
            {
                new Writer(Manager.ID, 37, 25),
                new Writer(Manager.ID, 37, 65),
                new Writer(Manager.ID, 37, 105),
                new Writer(Manager.ID, 37, 145),
                new Writer(Manager.ID, 37, 185),
                new Writer(Manager.ID, 37, 225),
                new Writer(Manager.ID, 37, 265)
            };

            foreach (var writer in Writers)
            {
                writer.Start();
            }
            while (!Writers.All(x => x.IsReady));
        }
    }
}