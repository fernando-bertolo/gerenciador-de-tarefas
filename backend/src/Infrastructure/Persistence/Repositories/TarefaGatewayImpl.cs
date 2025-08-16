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

        public async Task<Tarefa> CriarTarefa(Tarefa tarefa)
        {
            await _context.Tarefas.AddAsync(
                new TarefaEntity(
                    tarefa.Codigo ?? 0,
                    tarefa.Titulo,
                    tarefa.Descricao,
                    tarefa.DataCriacao,
                    tarefa.DataConclusao,
                    tarefa.Status
                )
            );
            await _context.SaveChangesAsync();
            return tarefa;
        }

        public async Task<List<Tarefa>> ListarTarefas()
        {
            return await this._context.Tarefas
                .AsNoTracking()
                .Select(e => Tarefa.Criar(e.Id, e.Titulo, e.Descricao, e.Status, e.DataConclusao, e.DataCriacao)).ToListAsync();
        }


        public async Task RemoverTarefaPorId(Tarefa tarefa)
        {
            _context.Tarefas.Remove(new TarefaEntity(
                tarefa.Codigo ?? 0,
                tarefa.Titulo,
                tarefa.Descricao,
                tarefa.DataCriacao,
                tarefa.DataConclusao,
                tarefa.Status
            ));
            await _context.SaveChangesAsync();
        }

        public async Task<Tarefa?> BuscarTarefaPorId(int Id)
        {
            var entity = await _context.Tarefas
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == Id);

            if (entity == null) return null;

            return Tarefa.Criar(entity.Id, entity.Titulo, entity.Descricao, entity.Status, entity.DataConclusao, entity.DataCriacao);
        }

        public async Task AtualizarStatus(Tarefa tarefa)
        {
            var entity = new TarefaEntity(
                tarefa.Codigo ?? 0,
                tarefa.Titulo,
                tarefa.Descricao,
                tarefa.DataCriacao,
                tarefa.DataConclusao,
                tarefa.Status
            );

            _context.Tarefas.Attach(entity); 
            _context.Entry(entity).Property(e => e.Status).IsModified = true;
            _context.Entry(entity).Property(e => e.DataConclusao).IsModified = true;
            
            await this._context.SaveChangesAsync();
        }
    }
}
