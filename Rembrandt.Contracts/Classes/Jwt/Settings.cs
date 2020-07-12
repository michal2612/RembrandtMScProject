namespace Rembrandt.Contracts.Classes.Jwt
{
    public class Settings
    {
        //JWT
        public string Issuer { get; set; }
        public bool ValidateAudience { get; set; }
        public string IssuerSigningKey { get; set; }
        public int ExpiryMinutes { get; set; }

        //TESTS
        public bool SeedData { get; set; }
    }
}