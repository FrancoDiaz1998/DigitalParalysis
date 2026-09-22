namespace DigitalParalysis.Application.Common.Exceptions;

public sealed class RecursoDuplicadoException : Exception
{
    public RecursoDuplicadoException(string message)
        : base(message)
    {
    }

    public RecursoDuplicadoException(string message, Exception innerException) : base(message, innerException)
    {
    }
}