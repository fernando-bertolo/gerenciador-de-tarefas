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

        public void Execute(CriarTarefaInput input)
        {
            this._tarefaGateway.CriarTarefa(Tarefa.Criar(input.Titulo, input.Descricao, input.Status, input.DataConclusao));
        }
    }
}
