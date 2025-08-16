using backend.src.Domain.Enums;
using backend.src.Domain.Exceptions;

namespace backend.src.Domain.Entities
{
    public class Tarefa
    {
        public int? Codigo { get; private set; }
        public string Titulo { get; private set; }
        public string? Descricao { get; private set; }
        public StatusTarefa Status { get; private set; }
        public DateTime DataCriacao { get; private set; }
        public DateTime? DataConclusao { get; private set; }

        private Tarefa(
            string titulo,
            string? descricao = null,
            StatusTarefa status = StatusTarefa.Pendente,
            DateTime? dataConclusao = null
        )
        {
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Status = status;
            this.DataCriacao = DateTime.UtcNow;
            this.DataConclusao = dataConclusao;

            this.Validacao();
        }

        public static Tarefa Criar(
            string titulo,
            string? descricao = null,
            StatusTarefa status = StatusTarefa.Pendente,
            DateTime? dataConclusao = null
        )
        {
            Tarefa.VerificaTitulo(titulo);
            return new Tarefa(titulo, descricao, status, dataConclusao);
        }

        private void Validacao()
        {
            this.VerificaDataConclusaoMenorQueDataCriacao();
            this.VerificaDataConclusaoNullComStatusConcluido();
        }

        private void VerificaDataConclusaoMenorQueDataCriacao()
        {
            if (this.DataConclusao.HasValue && this.DataConclusao.Value < this.DataCriacao)
            {
                throw new DataConclusaoMenorQueDataCriacaoException(
                    "Data de conclusão não pode ser anterior à data de criação"
                );
            }
        }

        private void VerificaDataConclusaoNullComStatusConcluido()
        {
            if (this.Status == StatusTarefa.Concluida && !this.DataConclusao.HasValue)
            {
                throw new DataConclusaoNullComStatusConcluidoException("Data de conclusão não pode ser nula");
            }
        }

        private static void VerificaTitulo(string titulo)
        {
            if (string.IsNullOrWhiteSpace(titulo))
            {
                throw new TituloInvalidoException("Título não pode ser vazio ou nulo");
            }
        }


        public void ConcluirTarefa(DateTime dataConclusao)
        {
            this.Validacao();
            this.DataConclusao = dataConclusao;
            this.Status = StatusTarefa.Concluida;
        }
    }
}