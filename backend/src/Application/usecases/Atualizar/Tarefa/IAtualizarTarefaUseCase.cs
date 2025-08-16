namespace backend.src.Application.UseCases.Atualizar.Tarefa
{
    public interface IAtualizarTarefaUseCase
    {
        public Task Execute(int codigo, AtualizarTarefaInput atualizarTarefaInput);
    }
}
