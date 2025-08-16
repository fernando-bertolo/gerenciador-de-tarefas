using System;

namespace backend.src.Domain.Exceptions
{
    public class DataConclusaoMenorQueDataCriacaoException : Exception
    {
        public DataConclusaoMenorQueDataCriacaoException() : base() {}
        public DataConclusaoMenorQueDataCriacaoException(string message) : base(message) { }
    }
}
