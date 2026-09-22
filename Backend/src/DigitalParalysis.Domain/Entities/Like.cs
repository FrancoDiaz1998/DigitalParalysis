using DigitalParalysis.Domain.Validations;

namespace DigitalParalysis.Domain.Entities;

public class Like
{
    public int IdUsuario { get; private set; }
    public int IdComentario { get; private set; }

    public Usuario Usuario { get; private set; } = null!;
    public Comentario Comentario { get; private set; } = null!;

    private Like() { }

    public Like(int idUsuario, int idComentario)
    {
        IdUsuario = ValidacionesDominio.IdPositivo(idUsuario, nameof(idUsuario));
        IdComentario = ValidacionesDominio.IdPositivo(idComentario, nameof(idComentario));
    }
}
