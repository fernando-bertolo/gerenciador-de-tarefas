using backend.src.Domain.Entities;

namespace backend.src.Domain.Gateways
{
    public interface ITarefaGateway
    {
        Tarefa CriarTarefa(Tarefa tarefa);
    }
}