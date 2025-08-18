using backend.src.Domain.Entities;
using backend.src.Domain.Exceptions;
using backend.src.Domain.Gateways;

namespace backend.src.Application.usecases.deletar
{
    public class DeletarTarefaPorIdUseCaseImpl : IDeletarTarefaPorIdUseCase
    {
        
        private readonly ITarefaGateway _tarefaGateway;

        public DeletarTarefaPorIdUseCaseImpl(ITarefaGateway tarefaGateway)
        {
            _tarefaGateway = tarefaGateway;
        }

        public async Task Execute(int Id)
        {
            var tarefaEncontrada = await this._tarefaGateway.BuscarTarefaPorId(Id);

            if (tarefaEncontrada == null)
            {
                throw new TarefaNaoEncontradaException("Tarefa não encontrada");
            }

            await this._tarefaGateway.RemoverTarefaPorId(Tarefa.Criar(
                tarefaEncontrada.Codigo,
                tarefaEncontrada.Titulo,
                tarefaEncontrada.Descricao,
                tarefaEncontrada.Status,
                tarefaEncontrada.DataConclusao,
                tarefaEncontrada.DataCriacao
            ));
        }
    }
}