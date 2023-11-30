using System.Text.Json.Serialization;

namespace NotasDoJogo.Application.Commands
{
    public class ApiResponse
    {
        [JsonIgnore]
        public bool Sucesso { get; set; } = true;
        [JsonIgnore]
        public string Mensagem { get; set; }
    }
}