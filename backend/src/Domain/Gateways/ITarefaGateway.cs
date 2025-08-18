using backend.src.Application.usecases.listar;
using backend.src.Domain.Entities;

namespace backend.src.Domain.Gateways
{
    public interface ITarefaGateway
    {
        Task<Tarefa?> CriarTarefa(Tarefa tarefa);
        Task<List<Tarefa>> ListarTarefas(FiltroListagemInput filtro);
        Task RemoverTarefaPorId(Tarefa tarefa);
        Task<Tarefa?> BuscarTarefaPorId(int Id);
        Task AtualizarStatus(Tarefa tarefa);
        Task AtualizarTarefa(Tarefa tarefa);
    }
}