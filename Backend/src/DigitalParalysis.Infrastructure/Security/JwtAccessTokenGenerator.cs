using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DigitalParalysis.Application.Common.Security;
using DigitalParalysis.Application.Interfaces;
using DigitalParalysis.Domain.Entities;
using Microsoft.IdentityModel.Tokens;

namespace DigitalParalysis.Infrastructure.Security;

public sealed class JwtAccessTokenGenerator : IAccessTokenGenerator
{
    public const string RoleClaimName = "role";

    private readonly JwtOptions _options;
    private readonly JwtSecurityTokenHandler _tokenHandler = new();
    private readonly SigningCredentials _signingCredentials;

    public JwtAccessTokenGenerator(JwtOptions options)
    {
        _options = options;

        var securityKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(options.Key));

        _signingCredentials = new SigningCredentials(
            securityKey,
            SecurityAlgorithms.HmacSha256);
    }

    public AccessTokenResult Generate(Usuario usuario)
    {
        ArgumentNullException.ThrowIfNull(usuario);

        var issuedAtUtc = DateTime.UtcNow;
        var expiresAtUtc = issuedAtUtc.AddMinutes(_options.ExpirationMinutes);

        var claims = new[]
        {
            new Claim(
                JwtRegisteredClaimNames.Sub,
                usuario.Id.ToString(CultureInfo.InvariantCulture)),
            new Claim(
                JwtRegisteredClaimNames.UniqueName,
                usuario.NombreUsuario),
            new Claim(
                JwtRegisteredClaimNames.Email,
                usuario.Email),
            new Claim(
                RoleClaimName,
                usuario.Rol.ToString()),
            new Claim(
                JwtRegisteredClaimNames.Jti,
                Guid.NewGuid().ToString())
        };

        var token = new JwtSecurityToken(
            issuer: _options.Issuer,
            audience: _options.Audience,
            claims: claims,
            notBefore: issuedAtUtc,
            expires: expiresAtUtc,
            signingCredentials: _signingCredentials);

        return new AccessTokenResult(
            _tokenHandler.WriteToken(token),
            expiresAtUtc);
    }
}
