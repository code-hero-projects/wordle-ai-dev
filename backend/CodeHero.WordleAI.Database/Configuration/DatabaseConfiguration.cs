namespace CodeHero.WordleAI.Database.Configuration
{
    public class DatabaseConfiguration
    {
        public DatabaseType Type { get; set; }
        public string ConnectionString { get; set; }
        public TimeSpan InitializeRetryDelay { get; set; } = TimeSpan.FromMinutes(0.1);
    }
}
