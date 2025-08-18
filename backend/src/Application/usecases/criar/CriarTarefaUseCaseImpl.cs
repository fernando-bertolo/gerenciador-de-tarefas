using backend.src.Domain.Entities;
using backend.src.Domain.Gateways;

namespace backend.src.Application.usecases.criar
{
    public class CriarTarefaUseCaseImpl : ICriarTarefaUseCase
    {
        private readonly ITarefaGateway _tarefaGateway;

        public CriarTarefaUseCaseImpl(ITarefaGateway tarefaGateway)
        {
            _tarefaGateway = tarefaGateway;
        }

        public async Task Execute(CriarTarefaInput input)
        {
            await this._tarefaGateway.CriarTarefa(Tarefa.Criar(null, input.Titulo, input.Descricao, input.Status, input.DataConclusao));
        }
    }
}
