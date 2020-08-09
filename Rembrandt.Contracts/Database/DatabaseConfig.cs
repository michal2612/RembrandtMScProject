using System.IO;
using Newtonsoft.Json.Linq;

namespace Rembrandt.Contracts.Database
{
    public static class DatabaseConfig
    {
        public static string Host { get { return GetHost(); } }

        public static string Port { get { return GetPort(); } }

        public static string User { get { return GetUser(); } }

        public static string Password { get { return GetPassword(); } }

        private static readonly string jsonFile = File.ReadAllText("database.json");
        
        private static readonly JObject _databaseJson = JObject.Parse(jsonFile);

        static string GetHost()
            => _databaseJson["Host"].ToString();

        static string GetPort()
            => _databaseJson["Port"].ToString();

        static string GetUser()
            => _databaseJson["User"].ToString();

        static string GetPassword()
            => _databaseJson["Password"].ToString();
    }
}