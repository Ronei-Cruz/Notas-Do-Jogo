using Microsoft.EntityFrameworkCore;
using NotasDoJogo.Domain.Models;
using NotasDoJogo.Persistence.Contexts;
using NotasDoJogo.Persistence.Contracts;

namespace NotasDoJogo.Persistence
{
    public class UsuarioPersist : IUsuarioPersist
    {
        private readonly NJContext _context;

        public UsuarioPersist(NJContext context)
        {
            _context = context;
        }

        public async Task<List<Usuario>> GetAllAsync()
        {
            return await _context.Usuarios.ToListAsync();
        }
        public async Task<Usuario> GetByIdAsync(int id)
        {
            return await _context.Usuarios.FindAsync(id);
        }

    }
}