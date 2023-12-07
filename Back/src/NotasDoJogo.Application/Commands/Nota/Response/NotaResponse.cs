using System.Text.Json.Serialization;

namespace NotasDoJogo.Application.Commands.Nota.Response
{
    public class NotaResponse : ApiResponse
    {
        public int Id { get; set; }
        [JsonIgnore]
        public int JogadorId { get; set; }
        public string NomeJogador { get; set; }
        [JsonIgnore]
        public int UsuarioId { get; set; } 
        public string NomeUsuario { get; set; }
        [JsonIgnore]
        public int PartidaId { get; set; }
        public string Jogo { get; set; }
        public int Valor { get; set; }
        [JsonIgnore]
        public decimal Media { get; set; }
    }
}
