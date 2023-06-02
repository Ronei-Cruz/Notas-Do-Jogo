using NotasDoJogo.Domain.Models;

namespace NotasDoJogo.Persistence.Contracts
{
    public interface INotaPersist
    {
        Task<Nota> GetByIdAsync(int id);
        Task<List<Nota>> GetAllAsync();
        Task<List<Nota>> GetNotasPartidaIdByJogadorIdAsync(int jogadorId, int partidaId);
        Task<List<Nota>> GetNotasByUsuarioIdAsync(int usuarioId);
        Task<List<Nota>> GetNotasByPartidaIdAsync(int partidaId);
        Task<int> GetNotaCountByJogadorIdAsync(int jogadorId);

    }
}