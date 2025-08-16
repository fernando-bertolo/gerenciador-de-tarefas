using System.ComponentModel.DataAnnotations;

namespace backend.src.WebApi.DTOs
{
    public class AtualizarStatusDTO
    {
        [Required(ErrorMessage = "O status é obrigatório.")]
        public StatusTarefaDTO Status { get; set; }
    }
}
