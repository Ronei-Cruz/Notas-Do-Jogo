using NotasDoJogo.Domain.Models;

namespace NotasDoJogo.Persistence.Contracts
{
    public interface IPartidaPersist
    {
        Task<List<Partida>> GetPartidasByJogadorId(int jogadorId);
        Task<List<Partida>> GetPartidasByUsuarioId(int usuarioId);
    }
}