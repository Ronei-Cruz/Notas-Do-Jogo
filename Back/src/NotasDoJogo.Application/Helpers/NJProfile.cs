using AutoMapper;
using NotasDoJogo.Domain.Models;
using NotasDoJogo.Application.Commands.Jogador.Request;
using NotasDoJogo.Application.Commands.Jogador.Response;
using NotasDoJogo.Application.Commands.Usuario.Response;
using NotasDoJogo.Application.Commands.Usuario.Request;
using NotasDoJogo.Application.Commands.Partida.Request;
using NotasDoJogo.Application.Commands.Partida.Response;
using NotasDoJogo.Application.Commands.Nota.Response;
using NotasDoJogo.Application.Commands.Nota.Request;

namespace NotasDoJogo.Application.Helpers
{
    public class NJProfile : Profile
    {
        public NJProfile()
        {
            CreateMap<Jogador, JogadorResponse>();
            CreateMap<JogadorRequest, Jogador>();
            CreateMap<Usuario, UsuarioResponse>();
            CreateMap<UsuarioRequest, Usuario>();
            CreateMap<Partida, PartidaResponse>();
            CreateMap<PartidaRequest, Partida>();
            CreateMap<Nota, NotaResponse>()
                .ForMember(dest => dest.NomeJogador, opt => opt.MapFrom(src => src.Jogador.Nome))
                .ForMember(dest => dest.NomeUsuario, opt => opt.MapFrom(src => src.Usuario.Nome))
                .ForMember(dest => dest.Jogo, opt => opt.MapFrom(src => src.Partida.Jogo));
            CreateMap<NotaRequest,  Nota>();
        }
    }
}