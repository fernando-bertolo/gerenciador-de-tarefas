using System.ComponentModel.DataAnnotations;
using backend.src.WebApi.DTOs;

namespace Name
{
    public class AtualizarTarefaDTO
    {
        [Required(ErrorMessage = "O título é obrigatório.")]
        [MaxLength(100, ErrorMessage = "O título não pode ter mais que 100 caracteres.")]
        public string Titulo { get; set; }

        [MaxLength(500, ErrorMessage = "A descrição não pode ter mais que 500 caracteres.")]
        public string? Descricao { get; set; }

        [Required(ErrorMessage = "O status é obrigatório.")]
        public StatusTarefaDTO Status { get; set; }
    }
}