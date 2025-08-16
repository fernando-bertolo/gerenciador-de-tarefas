using backend.src.Application.usecases.criar;
using backend.src.WebApi.DTOs;
using backend.src.WebApi.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace backend.src.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TarefaController : ControllerBase
    {
        private readonly ICriarTarefaUseCase _criarTarefaUseCase;

        public TarefaController(ICriarTarefaUseCase criarTarefaUseCase)
        {
            _criarTarefaUseCase = criarTarefaUseCase;
        }


        [HttpPost]
        public IActionResult CriarTarefa(
            [FromBody] CriaTarefaDTO tarefaDTO
        )
        {
            this._criarTarefaUseCase.Execute(TarefaMapper.ToCriarTarefaInput(tarefaDTO));
            return Ok(tarefaDTO);
        }
    }
}
