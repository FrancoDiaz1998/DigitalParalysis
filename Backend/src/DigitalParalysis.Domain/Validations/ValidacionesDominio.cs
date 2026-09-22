using System.Net.Mail;

namespace DigitalParalysis.Domain.Validations;

internal static class ValidacionesDominio
{
    public static int IdPositivo(int id, string nombre)
    {
        if (id <= 0)
        {
            throw new ArgumentOutOfRangeException(nombre, "El identificador debe ser mayor que cero.");
        }

        return id;
    }

    public static string TextoObligatorio(string? valor, string nombre, int longitudMinima = 1)
    {
        if (string.IsNullOrWhiteSpace(valor))
        {
            throw new ArgumentException($"El campo {nombre} es obligatorio.", nombre);
        }

        var valorNormalizado = valor.Trim();

        if (valorNormalizado.Length < longitudMinima)
        {
            throw new ArgumentException(
                $"El campo {nombre} debe tener al menos {longitudMinima} caracteres.",
                nombre);
        }

        return valorNormalizado;
    }

    public static string? TextoOpcional(string? valor, string nombre, int longitudMinima = 1)
    {
        if (string.IsNullOrWhiteSpace(valor))
        {
            return null;
        }

        var valorNormalizado = valor.Trim();

        if (valorNormalizado.Length < longitudMinima)
        {
            throw new ArgumentException(
                $"El campo {nombre} debe tener al menos {longitudMinima} caracteres cuando se informa.",
                nombre);
        }

        return valorNormalizado;
    }

    public static DateOnly FechaNoFutura(DateOnly fecha, string nombre)
    {
        if (fecha > DateOnly.FromDateTime(DateTime.UtcNow))
        {
            throw new ArgumentOutOfRangeException(nombre, "La fecha no puede ser futura.");
        }

        return fecha;
    }

    public static string Email(string? email)
    {
        var emailNormalizado = TextoObligatorio(email, nameof(email));

        if (!MailAddress.TryCreate(emailNormalizado, out var direccion)
            || !string.Equals(direccion.Address, emailNormalizado, StringComparison.OrdinalIgnoreCase))
        {
            throw new ArgumentException("El email no tiene un formato válido.", nameof(email));
        }

        return emailNormalizado.ToLowerInvariant();
    }
}
