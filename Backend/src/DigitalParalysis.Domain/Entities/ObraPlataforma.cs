using DigitalParalysis.Domain.Validations;

namespace DigitalParalysis.Domain.Entities;

public class ObraPlataforma
{
    public int IdObra { get; private set; }
    public int IdPlataforma { get; private set; }

    public Obra Obra { get; private set; } = null!;
    public Plataforma Plataforma { get; private set; } = null!;

    private ObraPlataforma() { }

    public ObraPlataforma(int idObra, int idPlataforma)
    {
        IdObra = ValidacionesDominio.IdPositivo(idObra, nameof(idObra));
        IdPlataforma = ValidacionesDominio.IdPositivo(idPlataforma, nameof(idPlataforma));
    }
}
