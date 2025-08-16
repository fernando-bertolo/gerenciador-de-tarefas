using System;

namespace backend.src.Domain.Exceptions
{
    public class DataConclusaoMenorQueDataCriacaoException : AppException
    {
        public DataConclusaoMenorQueDataCriacaoException() : base("A data de conclusão não pode ser menor que a data de criação.", 400) {}
        public DataConclusaoMenorQueDataCriacaoException(string message) : base(message, 400) { }
    }
}
