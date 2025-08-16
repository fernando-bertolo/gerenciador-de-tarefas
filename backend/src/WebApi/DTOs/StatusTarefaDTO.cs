using System.Text.Json.Serialization;

namespace backend.src.WebApi.DTOs
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum StatusTarefaDTO
    {
        Pendente,
        EmProgresso,
        Concluida
    }
}