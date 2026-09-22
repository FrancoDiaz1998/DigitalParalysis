using DigitalParalysis.Domain.Validations;

namespace DigitalParalysis.Domain.Entities;

public class ObraActor
{
    public int IdObra { get; private set; }
    public int IdActor { get; private set; }

    public Obra Obra { get; private set; } = null!;
    public Actor Actor { get; private set; } = null!;

    private ObraActor() { }

    public ObraActor(int idObra, int idActor)
    {
        IdObra = ValidacionesDominio.IdPositivo(idObra, nameof(idObra));
        IdActor = ValidacionesDominio.IdPositivo(idActor, nameof(idActor));
    }
}
