using NotasDoJogo.Domain.Models;

namespace NotasDoJogo.Persistence.Contracts
{
    public interface IPartidaPersist
    {
        Task<Partida> GetByIdAsync(int id);
        Task<List<Partida>> GetAllAsync();
    }
}