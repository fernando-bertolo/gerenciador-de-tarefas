using backend.src.Domain.Enums;

namespace backend.src.Application.usecases.criar
{
    public class CriarTarefaInput
    {
        public string Titulo { get; set; }
        public string? Descricao { get; set; }
        public StatusTarefa Status { get; set; }
        public DateTime? DataConclusao { get; set; }
    }
}
