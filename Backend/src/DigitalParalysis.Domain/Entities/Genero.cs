using DigitalParalysis.Domain.Validations;

namespace DigitalParalysis.Domain.Entities;

public class Genero
{
    public int Id { get; private set; }
    public string Nombre { get; private set; } = string.Empty;
    public string? Descripcion { get; private set; }

    public ICollection<ObraGenero> ObraGeneros { get; private set; } = [];

    private Genero() { }

    public Genero(string nombre, string? descripcion = null)
    {
        Nombre = ValidacionesDominio.TextoObligatorio(nombre, nameof(nombre), 2);
        Descripcion = ValidacionesDominio.TextoOpcional(descripcion, nameof(descripcion), 2);
    }

    public void Actualizar(string nombre, string? descripcion)
    {
        Nombre = ValidacionesDominio.TextoObligatorio(nombre, nameof(nombre), 2);
        Descripcion = ValidacionesDominio.TextoOpcional(descripcion, nameof(descripcion), 2);
    }
}
