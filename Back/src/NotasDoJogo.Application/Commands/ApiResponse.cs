using System.Text.Json.Serialization;

namespace NotasDoJogo.Application.Commands
{
    public class ApiResponse
    {
        [JsonIgnore]
        public bool Sucesso { get; set; } = true;
        //public object Dados { get; set; }
        [JsonIgnore]
        public string MensagemErro { get; set; }
    }
}