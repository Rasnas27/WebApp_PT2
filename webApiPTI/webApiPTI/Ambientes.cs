namespace webApiPTI
{
    public static class Ambiente
    {
        public static IConfigurationRoot Configuration()
        {
            return new ConfigurationBuilder()
             .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
             .AddJsonFile("appsettings.json")
             .Build();
        }

        public static string DataBaseConnection => Configuration().GetConnectionString("DataBaseConnection");

    }
}
