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

        public Task<IEnumerable<Usuario>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
        public Task<Usuario> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

    }
}