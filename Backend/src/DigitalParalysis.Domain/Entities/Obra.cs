using DigitalParalysis.Domain.Validations;

namespace DigitalParalysis.Domain.Entities;

public class Obra
{
    public int Id { get; private set; }
    public int IdTipoObra { get; private set; }
    public string Titulo { get; private set; } = string.Empty;
    public int Anio { get; private set; }
    public string Sinopsis { get; private set; } = string.Empty;
    public int Duracion { get; private set; }
    public string? Foto { get; private set; }
    public string? DatosCuriosos { get; private set; }
    public string PaisOrigen { get; private set; } = string.Empty;

    public TipoObra TipoObra { get; private set; } = null!;
    public ICollection<ObraActor> ObraActores { get; private set; } = [];
    public ICollection<ObraDirector> ObraDirectores { get; private set; } = [];
    public ICollection<ObraGenero> ObraGeneros { get; private set; } = [];
    public ICollection<ObraPlataforma> ObraPlataformas { get; private set; } = [];
    public ICollection<ObraColeccion> ObraColecciones { get; private set; } = [];
    public ICollection<Valoracion> Valoraciones { get; private set; } = [];

    private Obra() { }

    public Obra(int idTipoObra, string titulo, int anio, string sinopsis, int duracion, string? foto, string? datosCuriosos, string paisOrigen)
    {
        IdTipoObra = ValidacionesDominio.IdPositivo(idTipoObra, nameof(idTipoObra));
        Titulo = ValidacionesDominio.TextoObligatorio(titulo, nameof(titulo));
        Anio = ValidarAnio(anio);
        Sinopsis = ValidacionesDominio.TextoObligatorio(sinopsis, nameof(sinopsis));
        Duracion = ValidarDuracion(duracion);
        Foto = ValidacionesDominio.TextoOpcional(foto, nameof(foto));
        DatosCuriosos = ValidacionesDominio.TextoOpcional(datosCuriosos, nameof(datosCuriosos));
        PaisOrigen = ValidacionesDominio.TextoObligatorio(paisOrigen, nameof(paisOrigen));
    }

    public void CambiarFoto(string? foto)
    {
        Foto = ValidacionesDominio.TextoOpcional(foto, nameof(foto));
    }

    public void CambiarTipo(int idTipoObra)
    {
        IdTipoObra = ValidacionesDominio.IdPositivo(idTipoObra, nameof(idTipoObra));
    }

    public void ActualizarDatos(string titulo, int anio, string sinopsis, int duracion, string? datosCuriosos, string paisOrigen)
    {
        Titulo = ValidacionesDominio.TextoObligatorio(titulo, nameof(titulo));
        Anio = ValidarAnio(anio);
        Sinopsis = ValidacionesDominio.TextoObligatorio(sinopsis, nameof(sinopsis));
        Duracion = ValidarDuracion(duracion);
        DatosCuriosos = ValidacionesDominio.TextoOpcional(datosCuriosos, nameof(datosCuriosos));
        PaisOrigen = ValidacionesDominio.TextoObligatorio(paisOrigen, nameof(paisOrigen));
    }

    private static int ValidarAnio(int anio)
    {
        if (anio < 1888)
        {
            throw new ArgumentOutOfRangeException(nameof(anio), "El año no puede ser anterior a 1888.");
        }

        return anio;
    }

    private static int ValidarDuracion(int duracion)
    {
        if (duracion <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(duracion), "La duración debe ser mayor que cero.");
        }

        return duracion;
    }
}
