using DigitalParalysis.Application.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace DigitalParalysis.Infrastructure.Security;

public sealed class PasswordHasher : IPasswordHasher
{
    private static readonly object UserMarker = new();

    private readonly PasswordHasher<object> _passwordHasher;

    public PasswordHasher(IOptions<PasswordHasherOptions> options)
    {
        _passwordHasher = new PasswordHasher<object>(options);
    }

    public string Hash(string password)
    {
        ArgumentException.ThrowIfNullOrEmpty(password);

        return _passwordHasher.HashPassword(UserMarker, password);
    }

    public bool Verify(string password, string hash)
    {
        if (string.IsNullOrEmpty(password) ||
            string.IsNullOrEmpty(hash))
        {
            return false;
        }

        var result = _passwordHasher.VerifyHashedPassword(UserMarker, hash, password);

        return result is PasswordVerificationResult.Success
            or PasswordVerificationResult.SuccessRehashNeeded;
    }
}