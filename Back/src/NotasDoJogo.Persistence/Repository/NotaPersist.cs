using Microsoft.EntityFrameworkCore;
using NotasDoJogo.Domain.Models;
using NotasDoJogo.Persistence.Contexts;
using NotasDoJogo.Persistence.Contracts;

namespace NotasDoJogo.Persistence.Repository
{
    public class NotaPersist : INotaPersist
    {
        private readonly NJContext _context;
        public NotaPersist(NJContext context)
        {
            _context = context;
        }

        public async Task<List<Nota>> GetAllAsync()
        {
            return await _context.Notas.ToListAsync();
        }

        public async Task<Nota> GetByIdAsync(int id)
        {
            return await _context.Notas.FindAsync(id);
        }

        public async Task<List<Nota>> GetNotasByJogadorIdAsync(int jogadorId, int partidaId) 
        {
            return await _context.Notas.Where(n => n.JogadorId == jogadorId && n.PartidaId == partidaId).ToListAsync();
        }

        public async Task<List<Nota>> GetNotasByUsuarioIdAsync(int usuarioId)
        {
            return await _context.Notas.Where(n => n.UsuarioId == usuarioId).ToListAsync();
        }

        public async Task<List<Nota>> GetNotasByPartidaIdAsync(int partidaId)
        {
            return await _context.Notas.Where(n => n.PartidaId == partidaId).ToListAsync();
        }

        public async Task<int> GetNotaCountByJogadorIdAsync(int jogadorId)
        {
            return await _context.Notas.CountAsync(n => n.JogadorId == jogadorId);
        }
    }
}