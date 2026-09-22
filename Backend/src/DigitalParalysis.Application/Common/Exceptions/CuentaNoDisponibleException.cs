namespace DigitalParalysis.Application.Common.Exceptions;

public sealed class CuentaNoDisponibleException : Exception
{
    public CuentaNoDisponibleException(string message): base(message)
    {
    }
}
