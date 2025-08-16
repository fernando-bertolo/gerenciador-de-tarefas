namespace backend.src.Application.UseCases.Atualizar.Status
{
    public interface IAtualizarStatusUseCase
    {
        public Task Execute(int codigo, AtualizarStatusInput atualizarStatusInput);
    }

}