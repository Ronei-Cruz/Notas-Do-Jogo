using Microsoft.AspNetCore.Mvc;
using Moq;
using NotasDoJogo.API.Controllers;
using NotasDoJogo.Domain.Models;
using Xunit;

namespace NotasDoJogo.Tests.Controllers
{
    public class UsuarioControllerTest
    {
        /*private readonly Mock<IUsuarioService> mockUsuarioService;
        private readonly UsuarioController usuarioController;

        public UsuarioControllerTest()
        {
            mockUsuarioService = new Mock<IUsuarioService>();
            usuarioController = new UsuarioController(mockUsuarioService.Object);
        }

        [Fact]
        public async Task AddUsuario_ReturnsCreatedResult()
        {
            // Arrange
            var usuarioDto = new UsuarioDto{ Id = 1, Nome = "Noronha Love", Email = "noronhalove@teste.com"  };
            var usuario = new Usuario { Id = usuarioDto.Id, Nome = usuarioDto.Nome, Email = usuarioDto.Email, Notas = null };

            mockUsuarioService.Setup(u => u.AddUsuarioAsync(It.IsAny<UsuarioDto>()))
                 .ReturnsAsync(usuarioDto);

            // Act
            var result = await usuarioController.AddUsuario(It.IsAny<UsuarioDto>());

            // Assert
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
            Assert.Equal(nameof(usuarioController.GetUsuarioById), createdAtActionResult.ActionName);
            Assert.Equal(usuario.Id, createdAtActionResult.RouteValues["id"]);
            Assert.Equal(usuarioDto, createdAtActionResult.Value);
        }

        [Fact]
        public async Task GetAllUsuarios_ReturnListUsuarios()
        {
            // Arrange
            var usuarios = new List<UsuarioDto>
            {
                new UsuarioDto { Id = 1, Nome = "Usuário 1", Email = "usuario1@teste.com" },
                new UsuarioDto { Id = 2, Nome = "Usuário 2", Email = "usuario2@teste.com" },
                new UsuarioDto { Id = 3, Nome = "Usuário 3", Email = "usuario3@teste.com" }
            };

            mockUsuarioService.Setup(u => u.GetUsuariosAsync()).ReturnsAsync(usuarios);

            // Act
            var result = await usuarioController.GetAllUsuarios();

            // Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(result);
            var returnedUsuarios = Assert.IsAssignableFrom<List<UsuarioDto>>(okObjectResult.Value);
            Assert.Equal(usuarios.Count, returnedUsuarios.Count);
            Assert.Equal(usuarios, returnedUsuarios);
        }*/
    }
}