using backend.src.Domain.Enums;

namespace backend.src.Application.usecases.listar
{
    public class ListarTarefasOutput
    {
        public int Codigo { get; set; }
        public string Titulo { get; set; }
        public string? Descricao { get; set; }
        public StatusTarefa Status { get; set; }
        public DateTime? DataConclusao { get; set; }
    }
}
