using NotasDoJogo.Application.Dtos;

namespace NotasDoJogo.Application.Contracts
{
    public interface IJogadorService
    {
        Task<JogadorDTO> GetJogadorByIdAsync(int jogadorId);
        Task<List<JogadorDTO>> GetJogadoresAsync();
        Task<JogadorDTO> AddJogadorAsync(JogadorDTO jogador);
        Task UpdateJogadorAsync(JogadorDTO jogador);
        Task <bool>DeleteJogadorAsync(int jogadorId);
        
    }
}