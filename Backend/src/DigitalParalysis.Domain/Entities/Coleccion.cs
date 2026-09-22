using DigitalParalysis.Domain.Validations;

namespace DigitalParalysis.Domain.Entities;

public class Coleccion
{
    public int Id { get; private set; }
    public int IdUsuario { get; private set; }
    public string Nombre { get; private set; } = string.Empty;

    public Usuario Usuario { get; private set; } = null!;
    public ICollection<ObraColeccion> ObraColecciones { get; private set; } = [];

    private Coleccion() { }

    public Coleccion(int idUsuario, string nombre)
    {
        IdUsuario = ValidacionesDominio.IdPositivo(idUsuario, nameof(idUsuario));
        Nombre = ValidacionesDominio.TextoObligatorio(nombre, nameof(nombre));
    }

    public void Renombrar(string nombre)
    {
        Nombre = ValidacionesDominio.TextoObligatorio(nombre, nameof(nombre));
    }
}
