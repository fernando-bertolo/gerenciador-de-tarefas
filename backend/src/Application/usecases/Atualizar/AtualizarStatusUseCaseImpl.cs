using backend.src.Application.UseCases.Atualizar;
using backend.src.Domain.Exceptions;
using backend.src.Domain.Gateways;

namespace backend.src.Application.UseCases.Atualizar
{
    public class AtualizarStatusUseCaseImpl : IAtualizarStatusUseCase
    {

        private readonly ITarefaGateway _tarefaGateway;

        public AtualizarStatusUseCaseImpl(ITarefaGateway tarefaGateway)
        {
            _tarefaGateway = tarefaGateway;
        }
        public async Task Execute(int codigo, AtualizarStatusInput atualizarStatusInput)
        {
            var tarefa = await this._tarefaGateway.BuscarTarefaPorId(codigo);

            if (tarefa == null)
            {
                throw new TarefaNaoEncontradaException("Tarefa não encontrada");
            }

            tarefa.AtualizarStatus(atualizarStatusInput.Status);
            await this._tarefaGateway.AtualizarStatus(tarefa);
        }
    }
}