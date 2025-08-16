namespace backend.src.Domain.Exceptions
{
    public class DataConclusaoNullComStatusConcluidoException : AppException
    {
        public DataConclusaoNullComStatusConcluidoException() : base("A data de conclusão não pode ser null quando a tarefa for concluida", 400) {}
        public DataConclusaoNullComStatusConcluidoException(string message) : base(message, 400) { }
    }
    
}