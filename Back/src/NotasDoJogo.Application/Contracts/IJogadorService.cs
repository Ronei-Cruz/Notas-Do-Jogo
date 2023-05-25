using NotasDoJogo.Application.Dtos;

namespace NotasDoJogo.Application.Contracts
{
    public interface IJogadorService
    {
        Task<JogadorDTO> GetJogadorByIdAsync(int jogadorId);
        Task<List<JogadorDTO>> GetJogadoresAsync();
        Task<JogadorDTO> AddJogadorAsync(JogadorDTO jogador);
        Task<JogadorDTO> UpdateJogadorAsync(int id, JogadorDTO jogador);
        Task <bool>DeleteJogadorAsync(int jogadorId);
        
    }
}