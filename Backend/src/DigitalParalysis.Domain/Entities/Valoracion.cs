using DigitalParalysis.Domain.Validations;

namespace DigitalParalysis.Domain.Entities;

public class Valoracion
{
    public int Id { get; private set; }
    public int IdObra { get; private set; }
    public int IdUsuario { get; private set; }
    public int Puntuacion { get; private set; }
    public string? Resenia { get; private set; }

    public Obra Obra { get; private set; } = null!;
    public Usuario Usuario { get; private set; } = null!;

    private Valoracion() { }

    public Valoracion(int idObra, int idUsuario, int puntuacion, string? resenia = null)
    {
        IdObra = ValidacionesDominio.IdPositivo(idObra, nameof(idObra));
        IdUsuario = ValidacionesDominio.IdPositivo(idUsuario, nameof(idUsuario));
        Puntuacion = ValidarPuntuacion(puntuacion);
        Resenia = ValidacionesDominio.TextoOpcional(resenia, nameof(resenia));
    }

    public void Actualizar(int puntuacion, string? resenia)
    {
        Puntuacion = ValidarPuntuacion(puntuacion);
        Resenia = ValidacionesDominio.TextoOpcional(resenia, nameof(resenia));
    }

    private static int ValidarPuntuacion(int puntuacion)
    {
        if (puntuacion is < 1 or > 10)
        {
            throw new ArgumentOutOfRangeException(
                nameof(puntuacion),
                "La puntuación debe estar entre 1 y 10.");
        }

        return puntuacion;
    }
}
