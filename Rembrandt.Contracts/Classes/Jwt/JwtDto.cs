namespace Rembrandt.Contracts.Classes.Jwt
{
    public class JwtDto
    {
        public string Token { get; set; }
        
        public long Expiry { get; set; }
    }
}