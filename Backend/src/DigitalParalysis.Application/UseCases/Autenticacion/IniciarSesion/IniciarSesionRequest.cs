using System.ComponentModel.DataAnnotations;

namespace DigitalParalysis.Application.UseCases.Autenticacion.IniciarSesion;

public sealed class IniciarSesionRequest
{
    [Required(ErrorMessage = "El email es obligatorio.")]
    [EmailAddress(ErrorMessage = "El formato del email no es válido.")]
    public string Email { get; init; } = string.Empty;

    [Required(ErrorMessage = "La contraseña es obligatoria.")]
    public string Password { get; init; } = string.Empty;
}
