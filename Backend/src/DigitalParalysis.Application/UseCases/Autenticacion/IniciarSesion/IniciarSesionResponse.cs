namespace DigitalParalysis.Application.UseCases.Autenticacion.IniciarSesion;

public sealed class IniciarSesionResponse
{
    public string AccessToken { get; init; } = string.Empty;

    public string TokenType { get; init; } = "Bearer";

    public DateTime ExpiresAtUtc { get; init; }

    public int UsuarioId { get; init; }

    public string NombreUsuario { get; init; } = string.Empty;

    public string Rol { get; init; } = string.Empty;
}
