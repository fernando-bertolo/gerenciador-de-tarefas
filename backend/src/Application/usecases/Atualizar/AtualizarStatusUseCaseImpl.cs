using backend.src.Application.UseCases.Atualizar;
using backend.src.Domain.Exceptions;
using backend.src.Domain.Gateways;

namespace backend.src.Application.UseCases.Atualizar
{
    public class AtualizarStatusUseCaseImpl : IAtualizarStatusUseCase
    {

        private readonly ITarefaGateway _tarefaGateway;

        public AtualizarStatusUseCaseImpl(ITarefaGateway tarefaGateway)
        {
            _tarefaGateway = tarefaGateway;
        }
        public async Task Execute(int codigo, AtualizarStatusInput atualizarStatusInput)
        {
            System.Console.WriteLine("To aqui");
            var tarefa = await this._tarefaGateway.BuscarTarefaPorId(codigo);

            if (tarefa == null)
            {
                throw new TarefaNaoEncontradaException("Tarefa não encontrada");
            }


            System.Console.WriteLine("To aqui 2");
            tarefa.AtualizarStatus(atualizarStatusInput.Status);
            System.Console.WriteLine("To aqui 3");
            await this._tarefaGateway.AtualizarStatus(tarefa);
        }
    }
}