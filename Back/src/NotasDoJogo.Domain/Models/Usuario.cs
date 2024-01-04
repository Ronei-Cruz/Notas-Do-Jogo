using NotasDoJogo.Domain.Enum;

namespace NotasDoJogo.Domain.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public PerfilEnum Perfil { get; set; } = PerfilEnum.Torcedor;
        public List<Nota> Notas { get; set; }
    }
}