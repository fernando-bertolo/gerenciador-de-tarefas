namespace backend.src.Application.usecases.criar
{
    public interface ICriarTarefaUseCase
    {
        public Task Execute(CriarTarefaInput input);
    }
}
