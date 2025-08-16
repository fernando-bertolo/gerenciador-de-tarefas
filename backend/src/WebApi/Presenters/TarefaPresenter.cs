using backend.src.Application.usecases.listar;
using backend.src.WebApi.DTOs;

namespace backend.src.WebApi.Presenters
{
    public class TarefaPresenter
    {

        public static List<TarefaResponseDTO> ToTarefaResponseDTO(List<ListarTarefasOutput> tarefas)
        {
            return tarefas.Select(tarefa => new TarefaResponseDTO
            {
                Codigo = tarefa.Codigo,
                Titulo = tarefa.Titulo,
                Descricao = tarefa.Descricao,
                Status = tarefa.Status.ToString(),
                DataConclusao = tarefa.DataConclusao?.ToString("dd/MM/yyyy"),
            }).ToList();
        }
        
    }
}
