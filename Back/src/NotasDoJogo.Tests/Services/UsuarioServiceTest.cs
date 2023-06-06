using AutoMapper;
using Moq;
using NotasDoJogo.Application.Dtos;
using NotasDoJogo.Application.Services;
using NotasDoJogo.Domain.Models;
using NotasDoJogo.Persistence.Contracts;
using Xunit;

namespace NotasDoJogo.Tests.Services
{
    public class UsuarioServiceTest
    {

        private readonly UsuarioService usuarioService;
        private readonly Mock<IGeralPersist> mockGeralPersist;
        private readonly Mock<IUsuarioPersist> mockUsuarioPersist;
        private readonly Mock<IMapper> mockMapper;

        public UsuarioServiceTest()
        {
            mockGeralPersist = new Mock<IGeralPersist>();
            mockUsuarioPersist = new Mock<IUsuarioPersist>();
            mockMapper = new Mock<IMapper>();

            usuarioService = new UsuarioService(mockGeralPersist.Object, mockUsuarioPersist.Object, mockMapper.Object);
        }

        [Fact]
        public async Task AddUsuarioTestAsync()
        {
            // Arrange
            var usuarioDto = new UsuarioDto
            {
                Id = 1,
                Nome = "Noronha Love",
                Email = "noronhalove@teste.com"
            };

            mockGeralPersist.Setup(p => p.Add(It.IsAny<Usuario>()));
            mockGeralPersist.Setup(p => p.SaveChangesAsync()).ReturnsAsync(true);

            mockUsuarioPersist.Setup(p => p.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((int id) => new Usuario { Id = id });

            mockMapper.Setup(m => m.Map<Usuario>(It.IsAny<UsuarioDto>())).Returns(new Usuario());
            mockMapper.Setup(m => m.Map<UsuarioDto>(It.IsAny<Usuario>())).Returns(new UsuarioDto());

            // Act
            var result = await usuarioService.AddUsuarioAsync(usuarioDto);

            // Assert
            Assert.NotNull(result);
            
            mockUsuarioPersist.Verify(p => p.GetByIdAsync(It.IsAny<int>()), Times.Once);
            mockMapper.Verify(m => m.Map<UsuarioDto>(It.IsAny<Usuario>()), Times.Once);
        }

        [Fact]
        public async Task GetUsuarioByIdTestAsync()
        {
            // Arrange
            int usuarioId = 1;
            var usuarioRetorno = new Usuario { Id = usuarioId, Nome = "Noronha Love", Email = "noronhalove@teste.com" };

            mockUsuarioPersist.Setup(p => p.GetByIdAsync(usuarioId)).ReturnsAsync(usuarioRetorno);

            mockMapper.Setup(m => m.Map<UsuarioDto>(usuarioRetorno)).Returns(new UsuarioDto { 
                Id = usuarioId, 
                Nome = "Noronha Love",
                Email = "noronhalove@teste.com" 
            });

            // Act
            var result = await usuarioService.GetUsuarioByIdAsync(usuarioId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(usuarioId, result.Id);
            Assert.Equal("Noronha Love", result.Nome);
            Assert.Equal("noronhalove@teste.com", result.Email);
            mockUsuarioPersist.Verify(p => p.GetByIdAsync(usuarioId), Times.Once);
            mockMapper.Verify(m => m.Map<UsuarioDto>(usuarioRetorno), Times.Once);
        }

        [Fact]
        public async Task GetUsuariosAsync_ReturnsListOfUsuarioDto()
        {
            // Arrange
            var usuarios = new List<Usuario>
            {
                new Usuario { Id = 1, Nome = "Usuário 1", Email = "usuario1@teste.com" },
                new Usuario { Id = 2, Nome = "Usuário 2", Email = "usuario2@teste.com" },
                new Usuario { Id = 3, Nome = "Usuário 3", Email = "usuario3@teste.com" }
            };

            mockUsuarioPersist.Setup(p => p.GetAllAsync()).ReturnsAsync(usuarios);

            mockMapper.Setup(m => m.Map<List<UsuarioDto>>(It.IsAny<List<Usuario>>())).Returns(new List<UsuarioDto>
            {
                new UsuarioDto { Id = 1, Nome = "Usuário 1", Email = "usuario1@teste.com" },
                new UsuarioDto { Id = 2, Nome = "Usuário 2", Email = "usuario2@teste.com" },
                new UsuarioDto { Id = 3, Nome = "Usuário 3", Email = "usuario3@teste.com" }
            });

            // Act
            var result = await usuarioService.GetUsuariosAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(3, result.Count);
            mockUsuarioPersist.Verify(p => p.GetAllAsync(), Times.Once);
            mockMapper.Verify(m => m.Map<List<UsuarioDto>>(It.IsAny<List<Usuario>>()), Times.Once); 
        }
    }
}