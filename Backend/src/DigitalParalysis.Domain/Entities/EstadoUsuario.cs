using DigitalParalysis.Domain.Validations;

namespace DigitalParalysis.Domain.Entities;

public class EstadoUsuario
{
    public int Id { get; private set; }
    public string Nombre { get; private set; } = string.Empty;

    public ICollection<Usuario> Usuarios { get; private set; } = [];

    private EstadoUsuario() { }

    public EstadoUsuario(string nombre)
    {
        Nombre = ValidacionesDominio.TextoObligatorio(nombre, nameof(nombre));
    }

    public void ActualizarNombre(string nombre)
    {
        Nombre = ValidacionesDominio.TextoObligatorio(nombre, nameof(nombre));
    }
}
