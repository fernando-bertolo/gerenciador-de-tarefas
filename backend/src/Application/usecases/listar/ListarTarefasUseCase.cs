namespace backend.src.Application.usecases.listar 
{
    public interface IListarTarefasUseCase
    {
        Task<List<ListarTarefasOutput>> Execute();
        
    }
}