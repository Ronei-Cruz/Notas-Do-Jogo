namespace NotasDoJogo.Application.Dtos
{
    public class PartidaDTO
    {
        public int Id { get; set; }
        public List<NotaDTO> Notas { get; set; }
        public ICollection<PartidaNotaDTO> PartidasNotas { get; set; }
    }
}