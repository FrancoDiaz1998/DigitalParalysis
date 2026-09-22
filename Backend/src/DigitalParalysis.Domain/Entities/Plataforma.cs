using DigitalParalysis.Domain.Validations;

namespace DigitalParalysis.Domain.Entities;

public class Plataforma
{
    public int Id { get; private set; }
    public string Nombre { get; private set; } = string.Empty;
    public string Pais { get; private set; } = string.Empty;
    public string? Biografia { get; private set; }
    public string? Foto { get; private set; }
    public DateOnly? FechaFundacion { get; private set; }

    public ICollection<ObraPlataforma> ObraPlataformas { get; private set; } = [];

    private Plataforma() { }

    public Plataforma(
        string nombre,
        string pais,
        string? biografia = null,
        string? foto = null,
        DateOnly? fechaFundacion = null)
    {
        Nombre = ValidacionesDominio.TextoObligatorio(nombre, nameof(nombre), 2);
        Pais = ValidacionesDominio.TextoObligatorio(pais, nameof(pais));
        Biografia = ValidacionesDominio.TextoOpcional(biografia, nameof(biografia));
        Foto = ValidacionesDominio.TextoOpcional(foto, nameof(foto));
        FechaFundacion = ValidarFechaFundacion(fechaFundacion);
    }

    public void Actualizar(
        string nombre,
        string pais,
        string? biografia,
        string? foto,
        DateOnly? fechaFundacion)
    {
        Nombre = ValidacionesDominio.TextoObligatorio(nombre, nameof(nombre), 2);
        Pais = ValidacionesDominio.TextoObligatorio(pais, nameof(pais));
        Biografia = ValidacionesDominio.TextoOpcional(biografia, nameof(biografia));
        Foto = ValidacionesDominio.TextoOpcional(foto, nameof(foto));
        FechaFundacion = ValidarFechaFundacion(fechaFundacion);
    }

    private static DateOnly? ValidarFechaFundacion(DateOnly? fechaFundacion)
    {
        return fechaFundacion is null
            ? null
            : ValidacionesDominio.FechaNoFutura(fechaFundacion.Value, nameof(fechaFundacion));
    }
}
