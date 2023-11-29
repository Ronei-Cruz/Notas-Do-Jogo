using Microsoft.EntityFrameworkCore;
using NotasDoJogo.Domain.Models;
using NotasDoJogo.Persistence.Contexts;
using NotasDoJogo.Persistence.Contracts;

namespace NotasDoJogo.Persistence.Repository
{
    public class JogadorPersist : IJogadorPersist
    {
        private readonly NJContext _context;

        public JogadorPersist(NJContext context)
        {
            _context = context;
        }

        public async Task<List<Jogador>> GetAllAsync()
        {
            return await _context.Jogadores.ToListAsync();
        }

        public async Task<Jogador> GetByIdAsync(int id)
        {
            return await _context.Jogadores.FindAsync(id);
        }
    }
}