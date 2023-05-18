namespace NotasDoJogo.Application.Dtos
{
    public class UsuarioDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public List<NotaDTO> Notas { get; set; }
    }
}