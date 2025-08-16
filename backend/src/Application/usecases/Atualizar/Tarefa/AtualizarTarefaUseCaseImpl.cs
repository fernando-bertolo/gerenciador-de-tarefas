using backend.src.Application.UseCases.Atualizar.Tarefa;
using backend.src.Domain.Exceptions;
using backend.src.Domain.Gateways;

namespace backend.src.Application.UseCases.Atualizar.Tarefa
{
    public class AtualizarTarefaUseCaseImpl : IAtualizarTarefaUseCase
    {
        private readonly ITarefaGateway _tarefaGateway;

        public AtualizarTarefaUseCaseImpl(ITarefaGateway tarefaGateway)
        {
            _tarefaGateway = tarefaGateway;
        }
        
        public async Task Execute(int codigo, AtualizarTarefaInput atualizarTarefaInput)
        {
            var tarefa = await this._tarefaGateway.BuscarTarefaPorId(codigo);

            if (tarefa == null)
            {
                throw new TarefaNaoEncontradaException("Tarefa não encontrada");
            }

            tarefa.AtualizarStatus(atualizarTarefaInput.Status);
            tarefa.AtualizarInformacoes(atualizarTarefaInput.Titulo, atualizarTarefaInput.Descricao);
            await this._tarefaGateway.AtualizarTarefa(tarefa);
        }
    }
}