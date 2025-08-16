namespace backend.src.WebApi.DTOs
{
    public class TarefaResponseDTO
    {
        public int Codigo { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Status { get; set; }
        public string? DataConclusao { get; set; }
    }
}