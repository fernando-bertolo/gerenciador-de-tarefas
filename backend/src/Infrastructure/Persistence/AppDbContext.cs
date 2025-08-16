using Microsoft.EntityFrameworkCore;
using backend.src.Infrastructure.Persistence.Entities;

namespace backend.src.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<TarefaEntity> Tarefas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TarefaEntity>(entity =>
            {
                entity.HasKey(t => t.Id);

                entity.Property(t => t.Titulo)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(t => t.DataCriacao)
                      .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(t => t.Status)
                      .HasConversion<int>(); // Mapeia enum para int
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
