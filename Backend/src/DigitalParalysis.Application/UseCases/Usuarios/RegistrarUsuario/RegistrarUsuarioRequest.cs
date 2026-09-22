namespace DigitalParalysis.Application.UseCases.Usuarios.RegistrarUsuario;

public class RegistrarUsuarioRequest
{
    public string Nombre { get; init; } = string.Empty;

    public string Apellido { get; init; } = string.Empty;

    public string NombreUsuario { get; init; } = string.Empty;

    public string Email { get; init; } = string.Empty;

    public string Password { get; init; } = string.Empty;

    public DateOnly FechaNacimiento { get; init; }
}