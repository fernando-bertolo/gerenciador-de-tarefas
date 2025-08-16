using backend.src.Application.usecases.criar;
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

        public TarefaController(
            ICriarTarefaUseCase criarTarefaUseCase,
            IListarTarefasUseCase listarTarefasUseCase
        )
        {
            _criarTarefaUseCase = criarTarefaUseCase;
            _listarTarefasUseCase = listarTarefasUseCase;
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
    }
}
