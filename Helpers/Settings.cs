namespace team_double_trouble_backend.Helpers
{
    //settings class contains properties defined in the appsettings.json file and is used for accessing application settings via objects that are injected into classes using the .NET 5.0 dependency injection (DI) system. For example the users controller accesses app settings via an IOptions<Settings> Settings object that is injected into its constructor.
    public class Settings
    {
        public string Secret { get; set; }
    }
}