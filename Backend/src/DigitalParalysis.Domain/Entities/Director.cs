using DigitalParalysis.Domain.Validations;

namespace DigitalParalysis.Domain.Entities;

public class Director
{
    public int Id { get; private set; }
    public string Nombre { get; private set; } = string.Empty;
    public string Apellido { get; private set; } = string.Empty;
    public string Pais { get; private set; } = string.Empty;
    public string? Biografia { get; private set; }
    public string? Foto { get; private set; }
    public DateOnly FechaNacimiento { get; private set; }

    public ICollection<ObraDirector> ObraDirectores { get; private set; } = [];

    private Director() { }

    public Director(string nombre, string apellido, string pais, DateOnly fechaNacimiento, string? biografia = null, string? foto = null)
    {
        Nombre = ValidacionesDominio.TextoObligatorio(nombre, nameof(nombre), 2);
        Apellido = ValidacionesDominio.TextoObligatorio(apellido, nameof(apellido), 2);
        Pais = ValidacionesDominio.TextoObligatorio(pais, nameof(pais));
        FechaNacimiento = ValidacionesDominio.FechaNoFutura(fechaNacimiento, nameof(fechaNacimiento));
        Biografia = ValidacionesDominio.TextoOpcional(biografia, nameof(biografia));
        Foto = ValidacionesDominio.TextoOpcional(foto, nameof(foto));
    }

    public void Actualizar(string nombre, string apellido, string pais, DateOnly fechaNacimiento, string? biografia, string? foto)
    {
        Nombre = ValidacionesDominio.TextoObligatorio(nombre, nameof(nombre), 2);
        Apellido = ValidacionesDominio.TextoObligatorio(apellido, nameof(apellido), 2);
        Pais = ValidacionesDominio.TextoObligatorio(pais, nameof(pais));
        FechaNacimiento = ValidacionesDominio.FechaNoFutura(fechaNacimiento, nameof(fechaNacimiento));
        Biografia = ValidacionesDominio.TextoOpcional(biografia, nameof(biografia));
        Foto = ValidacionesDominio.TextoOpcional(foto, nameof(foto));
    }
}
