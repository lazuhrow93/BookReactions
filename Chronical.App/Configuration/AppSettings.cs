namespace Chronical.App.Configuration
{
    public class AppSettings
    {
        public ConnectionString? ConnectionString { get; set; }
    }

    public class ConnectionString
    {
        public string? DbName { get; set; }
    }
}
