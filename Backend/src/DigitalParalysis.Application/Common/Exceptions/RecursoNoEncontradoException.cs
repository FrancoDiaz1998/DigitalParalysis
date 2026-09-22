namespace DigitalParalysis.Application.Common.Exceptions;

public sealed class RecursoNoEncontradoException : Exception
{
    public RecursoNoEncontradoException(string message): base(message)
    {
    }
}