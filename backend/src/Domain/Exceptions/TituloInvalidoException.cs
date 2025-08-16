using System;

namespace backend.src.Domain.Exceptions
{
    public class TituloInvalidoException : AppException
    {
        public TituloInvalidoException() : base("Titulo inválido", 400) {}
        public TituloInvalidoException(string message) : base(message, 400) { }
    }
}
