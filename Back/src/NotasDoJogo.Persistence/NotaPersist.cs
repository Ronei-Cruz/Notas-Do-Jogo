using NotasDoJogo.Domain.Models;
using NotasDoJogo.Persistence.Contexts;
using NotasDoJogo.Persistence.Contracts;

namespace NotasDoJogo.Persistence
{
    public class NotaPersist : INotaPersist
    {
        private readonly NJContext _context;
        public NotaPersist(NJContext context)
        {
            _context = context;
        }

        public Task<double> GetMediaNotasByJogadorId(int jogadorId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Nota>> GetNotasByJogadorId(int jogadorId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Nota>> GetNotasByUsuarioId(int usuarioId)
        {
            throw new NotImplementedException();
        }
    }
}