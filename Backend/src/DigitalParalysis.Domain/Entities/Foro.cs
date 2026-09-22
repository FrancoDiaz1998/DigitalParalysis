using DigitalParalysis.Domain.Validations;

namespace DigitalParalysis.Domain.Entities;

public class Foro
{
    public int Id { get; private set; }
    public int IdUsuario { get; private set; }
    public string Titulo { get; private set; } = string.Empty;
    public string Contenido { get; private set; } = string.Empty;
    public DateTime FechaCreacion { get; private set; }

    public Usuario Usuario { get; private set; } = null!;
    public ICollection<Comentario> Comentarios { get; private set; } = [];

    private Foro() { }

    public Foro(int idUsuario, string titulo, string contenido)
    {
        IdUsuario = ValidacionesDominio.IdPositivo(idUsuario, nameof(idUsuario));
        Titulo = ValidacionesDominio.TextoObligatorio(titulo, nameof(titulo), 3);
        Contenido = ValidacionesDominio.TextoObligatorio(contenido, nameof(contenido));
        FechaCreacion = DateTime.UtcNow;
    }

    public void Actualizar(string titulo, string contenido)
    {
        Titulo = ValidacionesDominio.TextoObligatorio(titulo, nameof(titulo), 3);
        Contenido = ValidacionesDominio.TextoObligatorio(contenido, nameof(contenido));
    }
}
