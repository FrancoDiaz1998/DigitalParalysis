using DigitalParalysis.Domain.Validations;

namespace DigitalParalysis.Domain.Entities;

public class Articulo
{
    public int Id { get; private set; }
    public int IdUsuario { get; private set; }
    public string Titulo { get; private set; } = string.Empty;
    public string Contenido { get; private set; } = string.Empty;
    public DateTime Fecha { get; private set; }

    public Usuario Usuario { get; private set; } = null!;

    private Articulo() { }

    public Articulo(int idUsuario, string titulo, string contenido)
    {
        IdUsuario = ValidacionesDominio.IdPositivo(idUsuario, nameof(idUsuario));
        Titulo = ValidacionesDominio.TextoObligatorio(titulo, nameof(titulo), 3);
        Contenido = ValidacionesDominio.TextoObligatorio(contenido, nameof(contenido));
        Fecha = DateTime.UtcNow;
    }

    public void Actualizar(string titulo, string contenido)
    {
        Titulo = ValidacionesDominio.TextoObligatorio(titulo, nameof(titulo), 3);
        Contenido = ValidacionesDominio.TextoObligatorio(contenido, nameof(contenido));
    }
}
