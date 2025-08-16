using System;

namespace backend.src.Domain.Exceptions
{
    public class TituloInvalidoException : Exception
    {
        public TituloInvalidoException() : base() {}
        public TituloInvalidoException(string message) : base(message) { }
    }
}
