using System;

namespace backend.src.Domain.Exceptions
{
    public class TarefaNaoEncontradaException : AppException
    {
        public TarefaNaoEncontradaException() : base("Tarefa não encontrada", 404) {}
        public TarefaNaoEncontradaException(string message) : base(message, 404) { }
    }
}
