using NotasDoJogo.Application.Dtos;

namespace NotasDoJogo.Application.Contracts
{
    public interface IPartidaService
    {
        Task<PartidaDto> GetPartidaByIdAsync(int partidaId);
        Task<List<PartidaDto>> GetPartidasAsync();
        Task<PartidaDto> AddPartidaAsync(PartidaDto partida);
        Task<PartidaDto> UpdatePartidaAsync(int id, PartidaDto partida);
        Task <bool>DeletePartidaAsync(int partidaId);
    }
}