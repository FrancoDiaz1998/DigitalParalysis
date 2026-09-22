namespace DigitalParalysis.Application.Common.Exceptions;

public sealed class CredencialesInvalidasException : Exception
{
    private const string DefaultMessage = "El email o la contraseña son incorrectos.";

    public CredencialesInvalidasException(): base(DefaultMessage)
    {
    }
}
