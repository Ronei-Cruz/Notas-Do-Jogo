using NotasDoJogo.Domain.Models;

namespace NotasDoJogo.Persistence.Contracts
{
    public interface INotaPersist
    {
        Task<List<Nota>> GetNotasByJogadorId(int jogadorId);
        Task<List<Nota>> GetNotasByUsuarioId(int usuarioId);
        Task<double> GetMediaNotasByJogadorId(int jogadorId);

    }
}