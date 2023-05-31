using Microsoft.EntityFrameworkCore;
using NotasDoJogo.Domain.Models;
using NotasDoJogo.Persistence.Contexts;
using NotasDoJogo.Persistence.Contracts;

namespace NotasDoJogo.Persistence.Repository
{
    public class PartidaPersist : IPartidaPersist
    {
        private readonly NJContext _context;

        public PartidaPersist(NJContext context)
        {
            _context = context;
        }

        public async Task<List<Partida>> GetAllAsync()
        {
            return await _context.Partidas.ToListAsync();
        }

        public async Task<Partida> GetByIdAsync(int id)
        {
            return await _context.Partidas.FindAsync(id);
        }
    }
}