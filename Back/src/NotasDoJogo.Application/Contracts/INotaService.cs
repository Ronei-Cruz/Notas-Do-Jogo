using NotasDoJogo.Application.Dtos;

namespace NotasDoJogo.Application.Contracts
{
    public interface INotaService
    {
        Task<NotaDto> AddNotaAsync(NotaDto nota);
        Task<NotaDto> GetNotaByIdAsync(int notaId);
        Task<List<NotaDto>> GetNotasAsync();
        Task<List<NotaDto>> GetNotasPartidaIdByJogadorIdAsync(int jogadorId, int partidaId);
        Task<List<NotaDto>> GetNotasByUsuarioIdAsync(int usuarioId);
        Task<decimal> GetMediaPartidaAsync(int partidaId);
        Task<decimal> GetNotaCountByJogadorIdAsync(int jogadorId, int partidaId);
        Task <bool>DeleteNotaAsync(int notaId);
    }
}