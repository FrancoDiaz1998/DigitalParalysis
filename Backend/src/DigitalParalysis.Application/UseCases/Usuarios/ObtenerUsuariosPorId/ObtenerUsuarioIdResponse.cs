using DigitalParalysis.Domain.Enums;

namespace DigitalParalysis.Application.UseCases.Usuarios.ObtenerUsuariosPorId;


public class ObtenerUsuarioIdResponse
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Apellido { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public DateOnly FechaNacimiento { get; set; }
    public string? Foto { get;  set; }
    public RolUsuario Rol { get; set; }
    public EstadoUsuario Estado { get; set; }
    public DateTime? FechaRegistro { get; set; }
    public DateTime? FechaFinSuspension { get; set; }
    public DateTime? FechaEliminacion { get; set; }
}