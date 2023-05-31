using NotasDoJogo.Application.Dtos;

namespace NotasDoJogo.Application.Contracts
{
    public interface INotaService
    {
        Task<NotaDTO> AddNotaAsync(NotaDTO nota);
        Task<NotaDTO> GetNotaByIdAsync(int notaId);
        Task<List<NotaDTO>> GetNotasAsync();
        Task<List<NotaDTO>> GetNotasByJogadorIdAsync(int jogadorId, int partidaId);
        Task<List<NotaDTO>> GetNotasByUsuarioIdAsync(int usuarioId);
        Task<decimal> GetMediaPartidaAsync(int partidaId);
        Task<decimal> GetNotaCountByJogadorIdAsync(int jogadorId, int partidaId);
        Task <bool>DeleteNotaAsync(int notaId);
    }
}