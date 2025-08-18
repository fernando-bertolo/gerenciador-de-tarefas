using backend.src.Application.usecases.criar;
using backend.src.Application.usecases.deletar;
using backend.src.Application.usecases.listar;
using backend.src.Application.UseCases.Atualizar;
using backend.src.Application.UseCases.Atualizar.Status;
using backend.src.Application.UseCases.Atualizar.Tarefa;
using backend.src.Domain.Gateways;
using backend.src.Infrastructure.Persistence;
using backend.src.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseUrls("http://0.0.0.0:5228");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers(options =>
{
    options.Filters.Add<ApiResponseFilter>();
    options.Filters.Add<GlobalExceptionFilter>();
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var EnableFrontend = "_enableFrontend";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: EnableFrontend,
    policy =>
    {
        policy.WithOrigins("http://localhost:3000", "http://host.docker.internal:3000")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

builder.Services.AddScoped<ICriarTarefaUseCase, CriarTarefaUseCaseImpl>();
builder.Services.AddScoped<IListarTarefasUseCase, ListarTarefasUseCaseImpl>();
builder.Services.AddScoped<IDeletarTarefaPorIdUseCase, DeletarTarefaPorIdUseCaseImpl>();
builder.Services.AddScoped<IAtualizarStatusUseCase, AtualizarStatusUseCaseImpl>();
builder.Services.AddScoped<IAtualizarTarefaUseCase, AtualizarTarefaUseCaseImpl>();
builder.Services.AddScoped<ITarefaGateway, TarefaGatewayImpl>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.Database.Migrate();
}

app.UseCors(EnableFrontend);
app.UseRouting();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Task Manager API V1");
    c.RoutePrefix = string.Empty;
});

app.MapControllers();

app.Run();
