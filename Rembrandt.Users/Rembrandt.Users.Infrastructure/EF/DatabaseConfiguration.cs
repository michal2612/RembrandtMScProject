namespace Rembrandt.Users.Infrastructure.EF
{
    public class DatabaseConfiguration : IDatabaseConfiguration
    {
        public string Host { get; set; }

        public string Port { get; set; }

        public string User { get; set; }
        
        public string Password { get; set; }
    }
}