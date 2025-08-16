using backend.src.Application.usecases.criar;
using backend.src.Application.usecases.deletar;
using backend.src.Application.usecases.listar;
using backend.src.Application.UseCases.Atualizar;
using backend.src.Domain.Gateways;
using backend.src.Infrastructure.Persistence;
using backend.src.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers(options =>
{
    options.Filters.Add<GlobalExceptionFilter>();
});
builder.Services.AddScoped<ICriarTarefaUseCase, CriarTarefaUseCaseImpl>();
builder.Services.AddScoped<IListarTarefasUseCase, ListarTarefasUseCaseImpl>();
builder.Services.AddScoped<IDeletarTarefaPorIdUseCase, DeletarTarefaPorIdUseCaseImpl>();
builder.Services.AddScoped<IAtualizarStatusUseCase, AtualizarStatusUseCaseImpl>();
builder.Services.AddScoped<ITarefaGateway, TarefaGatewayImpl>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.Database.Migrate();
}

app.MapControllers();

app.Run();
