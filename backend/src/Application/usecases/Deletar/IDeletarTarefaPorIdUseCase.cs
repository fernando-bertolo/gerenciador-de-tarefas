namespace backend.src.Application.usecases.deletar
{
    public interface IDeletarTarefaPorIdUseCase {
        Task Execute(int Id);
    }
}