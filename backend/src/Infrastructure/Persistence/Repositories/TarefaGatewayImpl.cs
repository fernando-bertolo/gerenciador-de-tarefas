using backend.src.Domain.Entities;
using backend.src.Domain.Gateways;
using backend.src.Infrastructure.Persistence.Entities;
using Microsoft.EntityFrameworkCore;


namespace backend.src.Infrastructure.Persistence.Repositories
{
    public class TarefaGatewayImpl : ITarefaGateway
    {
        private readonly AppDbContext _context;
        public TarefaGatewayImpl(AppDbContext context)
        {
            _context = context;
        }

        public Tarefa CriarTarefa(Tarefa tarefa)
        {
            _context.Tarefas.Add(
                new TarefaEntity(
                    tarefa.Codigo ?? 0,
                    tarefa.Titulo,
                    tarefa.Descricao,
                    tarefa.DataCriacao,
                    tarefa.DataConclusao,
                    tarefa.Status
                )
            );
            _context.SaveChanges();
            return tarefa;
        }

        public async Task<List<Tarefa>> ListarTarefas()
        {
            return await this._context.Tarefas
                .AsNoTracking()
                .Select(e => Tarefa.Criar(e.Id, e.Titulo, e.Descricao,  e.Status, e.DataConclusao)).ToListAsync();
        }
    }
}
