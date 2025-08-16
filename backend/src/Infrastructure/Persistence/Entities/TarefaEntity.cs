using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using backend.src.Domain.Enums;

namespace backend.src.Infrastructure.Persistence.Entities
{
    [Table("tarefas")]
    public class TarefaEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Titulo { get; set; } = null!;

        public string? Descricao { get; set; }

        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;

        public DateTime? DataConclusao { get; set; }

        public StatusTarefa Status { get; set; } = StatusTarefa.Pendente;

        public TarefaEntity(
            int Id,
            string Titulo,
            string? Descricao,
            DateTime DataCriacao,
            DateTime? DataConclusao,
            StatusTarefa Status
            )
        {
            this.Id = Id;
            this.Titulo = Titulo;
            this.Descricao = Descricao;
            this.DataCriacao = DataCriacao;
            this.DataConclusao = DataConclusao;
            this.Status = Status;
        }
    }
}
