using backend.src.Domain.Enums;

namespace backend.src.Application.UseCases.Atualizar.Tarefa
{
    public class AtualizarTarefaInput
    {
        public string Titulo { get; set; }
        public string? Descricao { get; set; }
        public StatusTarefa Status { get; set; }
    }
}