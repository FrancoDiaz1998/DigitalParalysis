using System.ComponentModel.DataAnnotations.Schema;
using DigitalParalysis.Domain.Enums;
using DigitalParalysis.Domain.Validations;
using EstadoUsuarioValor = DigitalParalysis.Domain.Enums.EstadoUsuario;

namespace DigitalParalysis.Domain.Entities;

public class Usuario
{
    public int Id { get; private set; }
    public string Nombre { get; private set; } = string.Empty;
    public string Apellido { get; private set; } = string.Empty;
    public string NombreUsuario { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;
    public string ContrasenaHash { get; private set; } = string.Empty;
    public string? Foto { get; private set; }
    public DateOnly FechaNacimiento { get; private set; }
    public RolUsuario Rol { get; private set; }
    public int IdEstado { get; private set; }
    public DateTime FechaRegistro { get; private set; }
    public DateTime? FechaFinSuspension { get; private set; }
    public DateTime? FechaEliminacion { get; private set; }

    public EstadoUsuario EstadoUsuario { get; private set; } = null!;

    [NotMapped]
    public EstadoUsuarioValor Estado => (EstadoUsuarioValor)IdEstado;

    public ICollection<Coleccion> Colecciones { get; private set; } = [];
    public ICollection<Foro> Foros { get; private set; } = [];
    public ICollection<Comentario> Comentarios { get; private set; } = [];
    public ICollection<Like> Likes { get; private set; } = [];
    public ICollection<Valoracion> Valoraciones { get; private set; } = [];
    public ICollection<Articulo> Articulos { get; private set; } = [];

    private Usuario() { }

    public Usuario(string nombre, string apellido, string nombreUsuario, string email, string contrasenaHash,
        DateOnly fechaNacimiento)
    {
        Nombre = ValidacionesDominio.TextoObligatorio(nombre, nameof(nombre), 2);
        Apellido = ValidacionesDominio.TextoObligatorio(apellido, nameof(apellido), 2);
        NombreUsuario = ValidacionesDominio.TextoObligatorio(nombreUsuario, nameof(nombreUsuario), 2);
        Email = ValidacionesDominio.Email(email);
        ContrasenaHash = ValidacionesDominio.TextoObligatorio(contrasenaHash, nameof(contrasenaHash));
        FechaNacimiento = ValidacionesDominio.FechaNoFutura(fechaNacimiento, nameof(fechaNacimiento));
        Rol = RolUsuario.Usuario;
        IdEstado = (int)EstadoUsuarioValor.Activo;
        FechaRegistro = DateTime.UtcNow;
    }

    public void ActualizarPerfil(string nombre, string apellido, DateOnly fechaNacimiento, string? foto)
    {
        Nombre = ValidacionesDominio.TextoObligatorio(nombre, nameof(nombre), 2);
        Apellido = ValidacionesDominio.TextoObligatorio(apellido, nameof(apellido), 2);
        FechaNacimiento = ValidacionesDominio.FechaNoFutura(fechaNacimiento, nameof(fechaNacimiento));
        Foto = ValidacionesDominio.TextoOpcional(foto, nameof(foto));
    }

    public void Suspender(DateTime fechaFin)
    {
        if (Estado == EstadoUsuarioValor.Eliminado)
        {
            throw new InvalidOperationException("No se puede suspender un usuario eliminado.");
        }

        if (fechaFin <= DateTime.UtcNow)
        {
            throw new ArgumentOutOfRangeException(nameof(fechaFin), "El fin de la suspensión debe ser futuro.");
        }

        IdEstado = (int)EstadoUsuarioValor.Suspendido;
        FechaFinSuspension = fechaFin;
        FechaEliminacion = null;
    }

    public void Reactivar()
    {
        if (Estado == EstadoUsuarioValor.Eliminado)
        {
            throw new InvalidOperationException("No se puede reactivar un usuario eliminado.");
        }

        IdEstado = (int)EstadoUsuarioValor.Activo;
        FechaFinSuspension = null;
    }

    public void Eliminar()
    {
        IdEstado = (int)EstadoUsuarioValor.Eliminado;
        FechaFinSuspension = null;
        FechaEliminacion = DateTime.UtcNow;
    }

    public void CambiarFoto(string? foto)
    {
        Foto = ValidacionesDominio.TextoOpcional(foto, nameof(foto));
    }

    public void CambiarNombreUsuario(string nombreUsuario)
    {
        NombreUsuario = ValidacionesDominio.TextoObligatorio(
            nombreUsuario,
            nameof(nombreUsuario),
            2);
    }

    public void CambiarEmail(string email)
    {
        Email = ValidacionesDominio.Email(email);
    }

    public void CambiarContrasenaHash(string contrasenaHash)
    {
        ContrasenaHash = ValidacionesDominio.TextoObligatorio(
            contrasenaHash,
            nameof(contrasenaHash));
    }

    public void CambiarRol(RolUsuario rol)
    {
        if (!Enum.IsDefined(rol))
        {
            throw new ArgumentOutOfRangeException(nameof(rol), "El rol indicado no es válido.");
        }

        Rol = rol;
    }
}
