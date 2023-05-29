namespace NotasDoJogo.Domain.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public List<Nota> Notas { get; set; }

        // NL574743715BR
    }
}