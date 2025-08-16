using backend.src.Application.usecases.criar;
using backend.src.Application.usecases.deletar;
using backend.src.Application.usecases.listar;
using backend.src.WebApi.DTOs;
using backend.src.WebApi.Mappers;
using backend.src.WebApi.Presenters;
using Microsoft.AspNetCore.Mvc;

namespace backend.src.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TarefaController : ControllerBase
    {
        private readonly ICriarTarefaUseCase _criarTarefaUseCase;
        private readonly IListarTarefasUseCase _listarTarefasUseCase;
        private readonly IDeletarTarefaPorIdUseCase _deletarTarefaPorIdUseCase;

        public TarefaController(
            ICriarTarefaUseCase criarTarefaUseCase,
            IListarTarefasUseCase listarTarefasUseCase,
            IDeletarTarefaPorIdUseCase deletarTarefaPorIdUseCase
        )
        {
            _criarTarefaUseCase = criarTarefaUseCase;
            _listarTarefasUseCase = listarTarefasUseCase;
            _deletarTarefaPorIdUseCase = deletarTarefaPorIdUseCase;
        }


        [HttpPost]
        public IActionResult CriarTarefa(
            [FromBody] CriaTarefaDTO tarefaDTO
        )
        {
            this._criarTarefaUseCase.Execute(TarefaMapper.ToCriarTarefaInput(tarefaDTO));
            return Ok(tarefaDTO);
        }

        [HttpGet]
        public IActionResult ListarTarefas()
        {
            var tarefas = this._listarTarefasUseCase.Execute();
            return Ok(TarefaPresenter.ToTarefaResponseDTO(tarefas.Result));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoverTarefaPorId(int id)
        {
            await this._deletarTarefaPorIdUseCase.Execute(id);
            return Ok();
        }
    }
}
