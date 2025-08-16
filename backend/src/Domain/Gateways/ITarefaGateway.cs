using backend.src.Domain.Entities;

namespace backend.src.Domain.Gateways
{
    public interface ITarefaGateway
    {
        Task<Tarefa?> CriarTarefa(Tarefa tarefa);
        Task<List<Tarefa>> ListarTarefas();
        Task RemoverTarefaPorId(Tarefa tarefa);
        Task<Tarefa?> BuscarTarefaPorId(int Id);
    }
}