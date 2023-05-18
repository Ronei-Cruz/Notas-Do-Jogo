using NotasDoJogo.Domain.Models;

namespace NotasDoJogo.Persistence.Contracts
{
    public interface IJogadorPersist
    {
        Task<Jogador> GetByIdAsync(int id);
        Task<List<Jogador>> GetAllAsync();
    }
}