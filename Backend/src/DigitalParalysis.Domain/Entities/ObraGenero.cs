using DigitalParalysis.Domain.Validations;

namespace DigitalParalysis.Domain.Entities;

public class ObraGenero
{
    public int IdObra { get; private set; }
    public int IdGenero { get; private set; }

    public Obra Obra { get; private set; } = null!;
    public Genero Genero { get; private set; } = null!;

    private ObraGenero() { }

    public ObraGenero(int idObra, int idGenero)
    {
        IdObra = ValidacionesDominio.IdPositivo(idObra, nameof(idObra));
        IdGenero = ValidacionesDominio.IdPositivo(idGenero, nameof(idGenero));
    }
}
