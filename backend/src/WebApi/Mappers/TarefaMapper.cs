using backend.src.Application.usecases.criar;
using backend.src.Application.UseCases.Atualizar;
using backend.src.Application.UseCases.Atualizar.Status;
using backend.src.Application.UseCases.Atualizar.Tarefa;
using backend.src.Domain.Entities;
using backend.src.Domain.Enums;
using backend.src.WebApi.DTOs;
using Name;

namespace backend.src.WebApi.Mappers
{
    public static class TarefaMapper
    {
        public static CriaTarefaDTO ToDTO(this Tarefa tarefa)
        {
            return new CriaTarefaDTO();
        }

        public static CriarTarefaInput ToCriarTarefaInput(CriaTarefaDTO tarefaDTO)
        {
            return new CriarTarefaInput()
            {
                Titulo = tarefaDTO.Titulo,
                Descricao = tarefaDTO.Descricao,
                Status = (StatusTarefa)tarefaDTO.Status,
                DataConclusao = tarefaDTO.DataConclusao
            };
        }

        public static AtualizarStatusInput ToAtualizarStatusInput(this AtualizarStatusDTO dto)
        {
            return new AtualizarStatusInput()
            {
                Status = (StatusTarefa)dto.Status,
            };
        }
        
        public static AtualizarTarefaInput ToAtualizarTarefaInput(this AtualizarTarefaDTO dto)
        {
            return new AtualizarTarefaInput()
            {
                Titulo = dto.Titulo,
                Descricao = dto.Descricao,
                Status = (StatusTarefa)dto.Status,
            };
        }
    }
}
