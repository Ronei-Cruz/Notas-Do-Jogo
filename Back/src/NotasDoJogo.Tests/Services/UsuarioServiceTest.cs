using AutoMapper;
using Moq;
using NotasDoJogo.Domain.Models;
using NotasDoJogo.Persistence.Services;
using Xunit;

namespace NotasDoJogo.Tests.Services
{
    public class UsuarioServiceTest
    {

        /*private readonly UsuarioService usuarioService;
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
        public async Task AddUsuarioAsyncTest()
        {
            // Arrange
            mockGeralPersist.Setup(p => p.Add(It.IsAny<Usuario>()));
            mockGeralPersist.Setup(p => p.SaveChangesAsync()).ReturnsAsync(true);

            mockUsuarioPersist.Setup(p => p.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((int id) => new Usuario { Id = id });

            mockMapper.Setup(m => m.Map<Usuario>(It.IsAny<UsuarioDto>())).Returns(new Usuario());
            mockMapper.Setup(m => m.Map<UsuarioDto>(It.IsAny<Usuario>())).Returns(new UsuarioDto());

            // Act
            var result = await usuarioService.AddUsuarioAsync(It.IsAny<UsuarioDto>());

            // Assert
            Assert.NotNull(result);
            
            mockUsuarioPersist.Verify(p => p.GetByIdAsync(It.IsAny<int>()), Times.Once);
            mockMapper.Verify(m => m.Map<UsuarioDto>(It.IsAny<Usuario>()), Times.Once);
        }

        [Fact]
        public async Task GetUsuarioByIdAsyncTest()
        {
            // Arrange
            int usuarioId = 1;
            mockUsuarioPersist.Setup(p => p.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(It.IsAny<Usuario>());

            mockMapper.Setup(m => m.Map<UsuarioDto>(It.IsAny<Usuario>())).Returns(new UsuarioDto { 
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
            mockMapper.Verify(m => m.Map<UsuarioDto>(It.IsAny<Usuario>()), Times.Once);
        }

        [Fact]
        public async Task GetUsuariosAsync_ReturnsListOfUsuarioDtoTest()
        {
            // Arrange
            mockUsuarioPersist.Setup(p => p.GetAllAsync()).ReturnsAsync(It.IsAny<List<Usuario>>());

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

        [Fact]
        public async Task UpdateUsuarioAsync_ExistingUsuario_RetunsUpdatedUsuarioDtoTest()
        {
            // Arrange
            int usuarioId = 1;
            var usuarioDto = new UsuarioDto { Id = usuarioId, Nome = "Novo Nome", Email = "novoemail@teste.com" };
            var existingUsuario = new Usuario { Id = usuarioId, Nome = "Nome Antigo", Email = "emailantigo@teste.com" };

            mockUsuarioPersist.Setup(p => p.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(existingUsuario);

            mockGeralPersist.Setup(p => p.SaveChangesAsync()).ReturnsAsync(true);

            mockMapper.Setup(m => m.Map(usuarioDto, existingUsuario)).Returns(existingUsuario);
            mockMapper.Setup(m => m.Map<UsuarioDto>(existingUsuario)).Returns(usuarioDto);

            // Act
            var result = await usuarioService.UpdateUsuarioAsync(usuarioId, usuarioDto);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(usuarioId, result.Id);
            Assert.Equal(usuarioDto.Nome, result.Nome);
            Assert.Equal(usuarioDto.Email, result.Email);

            mockUsuarioPersist.Verify(p => p.GetByIdAsync(It.IsAny<int>()), Times.Exactly(2));
            mockGeralPersist.Verify(p => p.Update(existingUsuario), Times.Once);
            mockGeralPersist.Verify(p => p.SaveChangesAsync(), Times.Once);
            mockMapper.Verify(m => m.Map(usuarioDto, existingUsuario), Times.Once);
        }

        [Fact]
        public async Task DeleteUsuarioTest()
        {
            // Arrange
            mockGeralPersist.Setup(p => p.Delete(It.IsAny<Usuario>()));
            mockGeralPersist.Setup(p => p.SaveChangesAsync()).ReturnsAsync(true);

            mockUsuarioPersist.Setup(p => p.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(new Usuario { Id = It.IsAny<int>() });

            // Act
            var result = await usuarioService.DeleteUsuarioAsync(It.IsAny<int>());

            // Assert
            Assert.True(result);
            mockUsuarioPersist.Verify(p => p.GetByIdAsync(It.IsAny<int>()), Times.Once);
            mockGeralPersist.Verify(p => p.Delete(It.IsAny<Usuario>()), Times.Once);
            mockGeralPersist.Verify(p => p.SaveChangesAsync(), Times.Once);
        }*/
    }
}