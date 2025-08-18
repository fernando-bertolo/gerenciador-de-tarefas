using backend.src.Domain.Enums;

namespace backend.src.Application.usecases.listar
{
    public class FiltroListagemInput
    {
        public StatusTarefa? Status { get; set; }
        public string? Search { get; set; }
    }
}