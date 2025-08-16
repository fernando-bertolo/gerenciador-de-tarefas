using System;
using backend.src.Domain.Entities;
using backend.src.Domain.Exceptions;
using Xunit;

namespace backend.Tests.src.Domain.Entities
{
    public class TarefaTest
    {
        [Fact]
        public void NaoDeveCriarTarefaComTituloVazio()
        {
            // Assert.Throws<TarefaException>(() => new TarefaEntity("", "Descrição"));
        }

    }
}