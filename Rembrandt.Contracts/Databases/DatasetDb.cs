using System.IO;
using Newtonsoft.Json.Linq;

namespace Rembrandt.Contracts.Databases
{
    public class DatabaseAccess
    {
        public  string Host { get { return GetHost(); } }
        public  string Port { get { return GetPort(); } }
        public  string User { get { return GetUser(); } }
        public  string Password { get { return GetPassword(); } }
        public  string Database {get {return GetDatabase(); } }

        private readonly string jsonFile = File.ReadAllText(Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\Rembrandt.Contracts\Databases\databases.json")));

        private JToken DatabaseJson;

        public DatabaseAccess(string databaseName)
        {
            DatabaseJson = JObject.Parse(jsonFile)[databaseName];
        }
        
        private  string GetHost()
            => DatabaseJson["Host"].ToString();

        private  string GetPort()
            => DatabaseJson["Port"].ToString();

        private  string GetUser()
            => DatabaseJson["User"].ToString();

        private  string GetPassword()
            => DatabaseJson["Password"].ToString();

        private  string GetDatabase()
            => DatabaseJson["Database"].ToString();
    }
}