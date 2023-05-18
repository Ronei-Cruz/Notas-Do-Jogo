using NotasDoJogo.Domain.Models;
using NotasDoJogo.Persistence.Contexts;
using NotasDoJogo.Persistence.Contracts;

namespace NotasDoJogo.Persistence
{
    public class JogadorPersist : IJogadorPersist
    {
        private readonly NJContext _context;

        public JogadorPersist(NJContext context)
        {
            _context = context;
        }

        public Task<List<Jogador>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Jogador> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}