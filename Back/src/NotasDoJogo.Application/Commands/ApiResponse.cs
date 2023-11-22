namespace NotasDoJogo.Application.Commands
{
    public class ApiResponse
    {
        public bool Sucesso { get; set; } = true;
        public object Dados { get; set; }
        public string MensagemErro { get; set; }
        public int StatusCode { get; set; } = 200;
    }
}