namespace DigitalParalysis.Application.Interfaces;

public interface IPasswordHasher
{
    string Hash(string password);

    bool Verify(string password, string hash);
}