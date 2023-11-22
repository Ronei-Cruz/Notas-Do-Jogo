using NotasDoJogo.Application.Commands.Request;
using NotasDoJogo.Application.Commands.Response;
using NotasDoJogo.Application.Dtos;

namespace NotasDoJogo.Application.Contracts
{
    public interface IJogadorService
    {
        Task<JogadorResponse> GetJogadorByIdAsync(int jogadorId);
        Task<List<JogadorResponse>> GetJogadoresAsync();
        Task<JogadorResponse> AddJogadorAsync(JogadorRequest request);
        Task<JogadorResponse> UpdateJogadorAsync(int id, JogadorRequest jogador);
        Task <bool>DeleteJogadorAsync(int jogadorId);
        
    }
}