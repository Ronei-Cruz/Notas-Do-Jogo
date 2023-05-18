using NotasDoJogo.Domain.Models;
using NotasDoJogo.Persistence.Contexts;
using NotasDoJogo.Persistence.Contracts;

namespace NotasDoJogo.Persistence
{
    public class PartidaPersist : IPartidaPersist
    {
        private readonly NJContext _context;

        public PartidaPersist(NJContext context)
        {
            _context = context;
        }

        public Task<List<Partida>> GetPartidasByJogadorId(int jogadorId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Partida>> GetPartidasByUsuarioId(int usuarioId)
        {
            throw new NotImplementedException();
        }
    }
}