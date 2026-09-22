using DigitalParalysis.Domain.Validations;

namespace DigitalParalysis.Domain.Entities;

public class TipoObra
{
    public int Id { get; private set; }
    public string Nombre { get; private set; } = string.Empty;
    public string? Descripcion { get; private set; }

    public ICollection<Obra> Obras { get; private set; } = [];

    private TipoObra() { }

    public TipoObra(string nombre, string? descripcion = null)
    {
        Nombre = ValidacionesDominio.TextoObligatorio(nombre, nameof(nombre));
        Descripcion = ValidacionesDominio.TextoOpcional(descripcion, nameof(descripcion));
    }

    public void Actualizar(string nombre, string? descripcion)
    {
        Nombre = ValidacionesDominio.TextoObligatorio(nombre, nameof(nombre));
        Descripcion = ValidacionesDominio.TextoOpcional(descripcion, nameof(descripcion));
    }
}
