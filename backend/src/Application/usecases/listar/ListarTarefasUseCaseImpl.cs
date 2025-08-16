using backend.src.Domain.Gateways;

namespace backend.src.Application.usecases.listar
{ 
    
    public class ListarTarefasUseCaseImpl : IListarTarefasUseCase
    {
        private readonly ITarefaGateway _tarefaGateway;

        public ListarTarefasUseCaseImpl(ITarefaGateway tarefaGateway)
        {
            _tarefaGateway = tarefaGateway;
        }
        
        public async Task<List<ListarTarefasOutput>> Execute()
        {
            var tarefas = await _tarefaGateway.ListarTarefas();

            return tarefas.Select(t => new ListarTarefasOutput
            {
                Codigo = t.Codigo ?? 0,
                Titulo = t.Titulo,
                Descricao = t.Descricao,
                Status = t.Status,
                DataConclusao = t.DataConclusao
            }).ToList();
        }
    }
}
