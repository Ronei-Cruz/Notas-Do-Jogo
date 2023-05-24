using NotasDoJogo.Application.Dtos;

namespace NotasDoJogo.Application.Contracts
{
    public interface IJogadorService
    {
        Task<JogadorDTO> GetJogadorPorIdAsync(int jogadorId);
        Task<List<JogadorDTO>> GetJogadoresAsync();
        Task<JogadorDTO> AddJogadorAsync(JogadorDTO jogador);
        Task UpdateJogadorAsync(JogadorDTO jogador);
        Task DeleteJogadorAsync(int jogadorId);
        Task CalcularMediaJogadorAsync(int jogadorId);
    }
}