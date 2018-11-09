namespace CommonData.ClassLib.Settings
{
    public class HttpSettings
    {
        public const string Address = "http://localhost:8888/testhttpserver/";
    }

    public class TestSettings : ISettings
    {
        public TestSettings()
        {
            Address = "http://localhost:8888/testhttpserver/";
        }

        public string Address { get; set; }
    }
}