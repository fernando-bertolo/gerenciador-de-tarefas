using backend.src.Application.usecases.criar;
using backend.src.Application.usecases.deletar;
using backend.src.Application.usecases.listar;
using backend.src.Application.UseCases.Atualizar;
using backend.src.Application.UseCases.Atualizar.Status;
using backend.src.Application.UseCases.Atualizar.Tarefa;
using backend.src.WebApi.DTOs;
using backend.src.WebApi.Mappers;
using backend.src.WebApi.Presenters;
using Microsoft.AspNetCore.Mvc;
using Name;

namespace backend.src.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TarefaController : ControllerBase
    {
        private readonly ICriarTarefaUseCase _criarTarefaUseCase;
        private readonly IListarTarefasUseCase _listarTarefasUseCase;
        private readonly IDeletarTarefaPorIdUseCase _deletarTarefaPorIdUseCase;
        private readonly IAtualizarStatusUseCase _atualizarStatusUseCase;
        private readonly IAtualizarTarefaUseCase _atualizarTarefaUseCase;

        public TarefaController(
            ICriarTarefaUseCase criarTarefaUseCase,
            IListarTarefasUseCase listarTarefasUseCase,
            IDeletarTarefaPorIdUseCase deletarTarefaPorIdUseCase,
            IAtualizarStatusUseCase atualizarStatusUseCase,
            IAtualizarTarefaUseCase atualizarTarefaUseCase
        )
        {
            _criarTarefaUseCase = criarTarefaUseCase;
            _listarTarefasUseCase = listarTarefasUseCase;
            _deletarTarefaPorIdUseCase = deletarTarefaPorIdUseCase;
            _atualizarStatusUseCase = atualizarStatusUseCase;
            _atualizarTarefaUseCase = atualizarTarefaUseCase;
        }


        [HttpPost]
        public IActionResult CriarTarefa(
            [FromBody] CriaTarefaDTO tarefaDTO
        )
        {
            this._criarTarefaUseCase.Execute(TarefaMapper.ToCriarTarefaInput(tarefaDTO));
            return Created();
        }

        [HttpGet]
        public IActionResult ListarTarefas()
        {
            var tarefas = this._listarTarefasUseCase.Execute();
            return Ok(TarefaPresenter.ToTarefaResponseDTO(tarefas.Result));
        }


        [HttpPatch("{id}/status")]
        public async Task<IActionResult> AtualizarStatus(
            int id,
            [FromBody] AtualizarStatusDTO dto
        )
        {
            await this._atualizarStatusUseCase.Execute(id, TarefaMapper.ToAtualizarStatusInput(dto));
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarTarefa(
            int id,
            [FromBody] AtualizarTarefaDTO dto)
        {
            await this._atualizarTarefaUseCase.Execute(id, TarefaMapper.ToAtualizarTarefaInput(dto));
            return Ok();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoverTarefaPorId(int id)
        {
            await this._deletarTarefaPorIdUseCase.Execute(id);
            return Ok();
        }
    }
}
