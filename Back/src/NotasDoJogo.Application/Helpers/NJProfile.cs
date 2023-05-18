using AutoMapper;
using NotasDoJogo.Application.Dtos;
using NotasDoJogo.Domain.Models;

namespace NotasDoJogo.Application.Helpers
{
    public class NJProfile : Profile
    {
        public NJProfile()
        {
            CreateMap<Usuario, UsuarioDTO>().ReverseMap();
            CreateMap<Jogador, JogadorDTO>().ReverseMap();
            CreateMap<Nota, NotaDTO>().ReverseMap();
            CreateMap<Partida, PartidaDTO>().ReverseMap();
        }
    }
}