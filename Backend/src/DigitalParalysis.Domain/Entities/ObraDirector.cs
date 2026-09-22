using DigitalParalysis.Domain.Validations;

namespace DigitalParalysis.Domain.Entities;

public class ObraDirector
{
    public int IdObra { get; private set; }
    public int IdDirector { get; private set; }

    public Obra Obra { get; private set; } = null!;
    public Director Director { get; private set; } = null!;

    private ObraDirector() { }

    public ObraDirector(int idObra, int idDirector)
    {
        IdObra = ValidacionesDominio.IdPositivo(idObra, nameof(idObra));
        IdDirector = ValidacionesDominio.IdPositivo(idDirector, nameof(idDirector));
    }
}
