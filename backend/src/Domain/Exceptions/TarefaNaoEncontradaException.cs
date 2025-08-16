using System;

namespace backend.src.Domain.Exceptions
{
    public class TarefaNaoEncontradaException : Exception
    {
        public TarefaNaoEncontradaException() : base() {}
        public TarefaNaoEncontradaException(string message) : base(message) { }
    }
}
