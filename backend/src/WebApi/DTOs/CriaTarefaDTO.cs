using System.ComponentModel.DataAnnotations;

namespace backend.src.WebApi.DTOs
{
    public class CriaTarefaDTO
    {
        [Required(ErrorMessage = "O título é obrigatório.")]
        [MaxLength(100, ErrorMessage = "O título não pode ter mais que 100 caracteres.")]
        public string Titulo { get; set; }

        [MaxLength(500, ErrorMessage = "A descrição não pode ter mais que 500 caracteres.")]
        public string? Descricao { get; set; }
        public DateTime? DataConclusao { get; set; }

        [Required(ErrorMessage = "O status é obrigatório.")]
        public StatusTarefaDTO Status { get; set; }
    }
}
