using DigitalParalysis.Domain.Validations;

namespace DigitalParalysis.Domain.Entities;

public class Comentario
{
    public int Id { get; private set; }
    public int IdUsuario { get; private set; }
    public int IdForo { get; private set; }
    public string Contenido { get; private set; } = string.Empty;
    public DateTime FechaComentario { get; private set; }

    public Usuario Usuario { get; private set; } = null!;
    public Foro Foro { get; private set; } = null!;
    public ICollection<Like> Likes { get; private set; } = [];

    private Comentario() { }

    public Comentario(int idUsuario, int idForo, string contenido)
    {
        IdUsuario = ValidacionesDominio.IdPositivo(idUsuario, nameof(idUsuario));
        IdForo = ValidacionesDominio.IdPositivo(idForo, nameof(idForo));
        Contenido = ValidacionesDominio.TextoObligatorio(contenido, nameof(contenido));
        FechaComentario = DateTime.UtcNow;
    }

    public void Editar(string contenido)
    {
        Contenido = ValidacionesDominio.TextoObligatorio(contenido, nameof(contenido));
    }
}
