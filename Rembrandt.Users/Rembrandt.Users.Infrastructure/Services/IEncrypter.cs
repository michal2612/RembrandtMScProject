namespace Rembrandt.Users.Infrastructure.Services
{
    public interface IEncrypter
    {
        string GetSalt();
        string GetHashValue(string value, string salt);
    }
}