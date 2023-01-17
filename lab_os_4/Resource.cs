namespace lab_os_4
{
    public class Resource
    {
        private static Resource? Instance { get; set; }

        private Resource()
        { }

        public static Resource GetInstance()
        {
            return Instance ?? new Resource();
        }
    }
}