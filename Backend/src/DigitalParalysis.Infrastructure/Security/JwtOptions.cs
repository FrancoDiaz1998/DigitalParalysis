using System.Globalization;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace DigitalParalysis.Infrastructure.Security;

public sealed class JwtOptions
{
    public const string SectionName = "Jwt";
    private const int MinimumKeySizeInBytes = 32;

    private JwtOptions(
        string issuer,
        string audience,
        string key,
        int expirationMinutes)
    {
        Issuer = issuer;
        Audience = audience;
        Key = key;
        ExpirationMinutes = expirationMinutes;
    }

    public string Issuer { get; }

    public string Audience { get; }

    public string Key { get; }

    public int ExpirationMinutes { get; }

    public static JwtOptions FromConfiguration(IConfiguration configuration)
    {
        var section = configuration.GetSection(SectionName);

        var issuer = section[nameof(Issuer)];
        var audience = section[nameof(Audience)];
        var key = section[nameof(Key)];
        var expirationValue = section[nameof(ExpirationMinutes)];

        if (string.IsNullOrWhiteSpace(issuer))
        {
            throw new InvalidOperationException(
                $"No se configuró '{SectionName}:{nameof(Issuer)}'.");
        }

        if (string.IsNullOrWhiteSpace(audience))
        {
            throw new InvalidOperationException(
                $"No se configuró '{SectionName}:{nameof(Audience)}'.");
        }

        if (string.IsNullOrWhiteSpace(key))
        {
            throw new InvalidOperationException(
                $"No se configuró '{SectionName}:{nameof(Key)}'. " +
                "Guardá la clave JWT en User Secrets o en una variable de entorno.");
        }

        if (Encoding.UTF8.GetByteCount(key) < MinimumKeySizeInBytes)
        {
            throw new InvalidOperationException(
                $"La configuración '{SectionName}:{nameof(Key)}' debe tener " +
                $"al menos {MinimumKeySizeInBytes} bytes.");
        }

        if (!int.TryParse(
                expirationValue,
                NumberStyles.None,
                CultureInfo.InvariantCulture,
                out var expirationMinutes) ||
            expirationMinutes is < 1 or > 1440)
        {
            throw new InvalidOperationException(
                $"La configuración '{SectionName}:{nameof(ExpirationMinutes)}' " +
                "debe ser un número entre 1 y 1440.");
        }

        return new JwtOptions(
            issuer,
            audience,
            key,
            expirationMinutes);
    }
}
