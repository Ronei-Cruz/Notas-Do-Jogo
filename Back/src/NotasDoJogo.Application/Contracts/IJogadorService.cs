using NotasDoJogo.Application.Dtos;

namespace NotasDoJogo.Application.Contracts
{
    public interface IJogadorService
    {
        Task<JogadorDto> GetJogadorByIdAsync(int jogadorId);
        Task<List<JogadorDto>> GetJogadoresAsync();
        Task<JogadorDto> AddJogadorAsync(JogadorDto jogador);
        Task<JogadorDto> UpdateJogadorAsync(int id, JogadorDto jogador);
        Task <bool>DeleteJogadorAsync(int jogadorId);
        
    }
}