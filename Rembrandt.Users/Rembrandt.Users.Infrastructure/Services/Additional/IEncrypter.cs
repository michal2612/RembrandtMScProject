namespace Rembrandt.Users.Infrastructure.Services
{
    public interface IEncrypter
    {
        string GetSalt();
        
        string GetHash(string value, string salt);
    }
}