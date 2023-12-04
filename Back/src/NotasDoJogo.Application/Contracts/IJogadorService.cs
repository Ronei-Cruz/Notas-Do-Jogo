using NotasDoJogo.Application.Commands.Jogador.Request;
using NotasDoJogo.Application.Commands.Jogador.Response;

namespace NotasDoJogo.Application.Contracts
{
    public interface IJogadorService
    {
        Task<JogadorResponse> GetJogadorByIdAsync(int id);
        Task<List<JogadorResponse>> GetJogadoresAsync();
        Task<JogadorResponse> AddJogadorAsync(JogadorRequest request);
        Task<JogadorResponse> EditarJogadorAsync(int id, JogadorRequest jogador);
        Task <JogadorResponse>DeleteJogadorAsync(int id);
        
    }
}