﻿using MediatR;
using NotasDoJogo.Application.Contracts;
using NotasDoJogo.Application.Handlers.Jogador;
using NotasDoJogo.Application.Handlers.Usuario;
using NotasDoJogo.Application.Handlers.Partida;
using NotasDoJogo.Persistence.Interfaces;
using NotasDoJogo.Persistence.Repository;
using NotasDoJogo.Persistence.Services;
using NotasDoJogo.Application.Handlers.Nota;

namespace NotasDoJogo.API.ConfigDependencies
{
    public static class ServiceExtensions
    {
        public static void AddApplicationDependencies(this IServiceCollection services)
        {
            #region MEDIATOR
            services.AddMediatR
            (
                typeof(Program).Assembly,

                // JOGADOR
                typeof(AdicionarJogadorHandler).Assembly, 
                typeof(VisualizarJogadoresHandler).Assembly,
                typeof(PerfilJogadorHandler).Assembly,
                typeof(EditarPerfilJogadorHandler).Assembly,
                typeof(DeletarPerfilJogadorHandler).Assembly,

                // USUÁRIO
                typeof(AdicionarUsuarioHandler).Assembly,
                typeof(VisualizarUsuariosHandler).Assembly,
                typeof(PerfilUsuarioHandler).Assembly,
                typeof(EditarPerfilUsuarioHandler).Assembly,
                typeof(DeletarPerfilUsuarioHandler).Assembly,

                // PARTIDA
                typeof(AdicionarPartidaHandler).Assembly,
                typeof(VisualizarPartidasHandler).Assembly,
                typeof(InformacoesPartidaHandler).Assembly,
                typeof(EditarInformacoesPartidaHandler).Assembly,
                typeof(DeletarPartidaHandler).Assembly,

                // NOTA
                typeof(AdicionarNotaHandler).Assembly,
                typeof(BuscarNotasDoJogadorPorPartidaHandler).Assembly,
                typeof(MediaJogadorPorPartidaHandler).Assembly,
                typeof(NotaMediaDaPartidaHandler).Assembly,
                typeof(NotasDoUsuarioHandler).Assembly,
                typeof(VisualizarNotaPorIdHandler).Assembly
            );
            #endregion

            #region PERSIST
            services.AddScoped<IGeralPersist, GeralPersist>();
            #endregion

            #region SERVICES
            services.AddScoped<IJogadorService, JogadorService>();
            services.AddScoped<IPartidaService, PartidaService>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<INotaService, NotaService>();
            #endregion
        }
    }
}
