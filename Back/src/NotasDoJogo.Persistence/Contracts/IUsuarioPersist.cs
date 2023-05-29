using NotasDoJogo.Domain.Models;

namespace NotasDoJogo.Persistence.Contracts
{
    public interface IUsuarioPersist
    {
        Task<Usuario> GetByIdAsync(int id);
        Task<List<Usuario>> GetAllAsync();
    }
}