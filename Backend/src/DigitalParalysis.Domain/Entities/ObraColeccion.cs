using DigitalParalysis.Domain.Validations;

namespace DigitalParalysis.Domain.Entities;

public class ObraColeccion
{
    public int IdObra { get; private set; }
    public int IdColeccion { get; private set; }

    public Obra Obra { get; private set; } = null!;
    public Coleccion Coleccion { get; private set; } = null!;

    private ObraColeccion() { }

    public ObraColeccion(int idObra, int idColeccion)
    {
        IdObra = ValidacionesDominio.IdPositivo(idObra, nameof(idObra));
        IdColeccion = ValidacionesDominio.IdPositivo(idColeccion, nameof(idColeccion));
    }
}
