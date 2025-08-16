namespace backend.src.Application.UseCases.Atualizar
{
    public interface IAtualizarStatusUseCase
    {
        public Task Execute(int codigo, AtualizarStatusInput atualizarStatusInput);
    }

}