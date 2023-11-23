using AutoMapper;
using NotasDoJogo.Application.Dtos;
using NotasDoJogo.Domain.Models;
using NotasDoJogo.Application.Commands.Response;

namespace NotasDoJogo.Application.Helpers
{
    public class NJProfile : Profile
    {
        public NJProfile()
        {
            CreateMap<Usuario, UsuarioDto>().ReverseMap();
            CreateMap<Jogador, JogadorResponse>();
            CreateMap<Nota, NotaDto>().ReverseMap();
            CreateMap<Partida, PartidaDto>().ReverseMap();
        }
    }
}