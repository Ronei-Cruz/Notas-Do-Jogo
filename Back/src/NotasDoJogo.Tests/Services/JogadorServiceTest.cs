using AutoMapper;
using Moq;
using NotasDoJogo.Application.Dtos;
using NotasDoJogo.Application.Services;
using NotasDoJogo.Domain.Models;
using NotasDoJogo.Persistence.Contracts;
using Xunit;

namespace NotasDoJogo.Tests.Services
{
    public class JogadorServiceTest
    {
        private readonly JogadorService jogadorService;
        private readonly Mock<IGeralPersist> mockGeralPersist;
        private readonly Mock<IJogadorPersist> mockJogadorPersist;
        private readonly Mock<IMapper> mockMapper;
        public JogadorServiceTest()
        {
            mockGeralPersist = new Mock<IGeralPersist>();
            mockJogadorPersist = new Mock<IJogadorPersist>();
            mockMapper = new Mock<IMapper>();

            jogadorService = new JogadorService(mockGeralPersist.Object, mockJogadorPersist.Object, mockMapper.Object);
        }

        [Fact]
        public async Task AddJogadorAsyncTest()
        {
            // Arrange
            mockGeralPersist.Setup(p => p.Add(It.IsAny<Jogador>()));
            mockGeralPersist.Setup(p => p.SaveChangesAsync()).ReturnsAsync(true);

            mockJogadorPersist.Setup(p => p.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((int id) => new Jogador { Id = id });

            mockMapper.Setup(m => m.Map<Jogador>(It.IsAny<JogadorDto>())).Returns(new Jogador());
            mockMapper.Setup(m => m.Map<JogadorDto>(It.IsAny<Jogador>())).Returns(new JogadorDto());

            // Act
            var result = await jogadorService.AddJogadorAsync(It.IsAny<JogadorDto>());

            // Assert
            Assert.NotNull(result);

            mockJogadorPersist.Verify(p => p.GetByIdAsync(It.IsAny<int>()), Times.Once);
            mockMapper.Verify(m => m.Map<JogadorDto>(It.IsAny<Jogador>()), Times.Once);
        }

        [Fact]
        public async Task GetJogadorByIdAsyncTest()
        {
            // Arrange
            int jogadorId = 1;
            mockJogadorPersist.Setup(p => p.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(It.IsAny<Jogador>());
            mockMapper.Setup(m => m.Map<JogadorDto>(It.IsAny<Jogador>())).Returns(() => new JogadorDto { 
                Id = jogadorId, 
                Nome = "Neymar", 
                Posicao = "Atacante", 
                Idade = 31 
            });

            // Act
            var result = await jogadorService.GetJogadorByIdAsync(jogadorId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(jogadorId, result.Id);
            Assert.Equal("Neymar", result.Nome);
            Assert.Equal("Atacante", result.Posicao);
            Assert.Equal(31, result.Idade);

            mockJogadorPersist.Verify(p => p.GetByIdAsync(It.IsAny<int>()), Times.Once);
            mockMapper.Verify(m => m.Map<JogadorDto>(It.IsAny<Jogador>()), Times.Once);
        }

        [Fact]
        public async Task GetJogadorsAsync_RetunsListOfJogadorDtoTest()
        {
            // Arrange
            mockJogadorPersist.Setup(j => j.GetAllAsync()).ReturnsAsync(It.IsAny<List<Jogador>>());

            mockMapper.Setup(m => m.Map<List<JogadorDto>>(It.IsAny<List<Jogador>>())).Returns(new List<JogadorDto>
            {
                new JogadorDto { Id = 1, Nome = "Neymar", Posicao = "Atacante", Idade = 32 },
                new JogadorDto { Id = 2, Nome = "Messi", Posicao = "Atacante", Idade = 36 },
                new JogadorDto { Id = 3, Nome = "Buffon", Posicao = "Goleiro", Idade = 70 }
            });

            // Act
            var result = await jogadorService.GetJogadoresAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(3, result.Count);
            mockJogadorPersist.Verify(j => j.GetAllAsync(), Times.Once);
            mockMapper.Verify(m => m.Map<List<JogadorDto>>(It.IsAny<List<Jogador>>()), Times.Once);
        }

        [Fact]
        public async Task UpdateJogadorAsync_ExixtingJogador_ReturnUpdateJogadorTest()
        {
            // Arrange
            int jogadorId = 1;
            var jogadorDto = new JogadorDto { Id = jogadorId, Nome = "Neymar", Posicao = "Atacante", Idade = 32 };
            var existingJogador = new Jogador { Id = jogadorId, Nome = "Messi", Posicao = "Atacante", Idade = 36 };

            mockJogadorPersist.Setup(j => j.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(existingJogador);
            mockGeralPersist.Setup(g => g.SaveChangesAsync()).ReturnsAsync(true);

            mockMapper.Setup(m => m.Map(jogadorDto, existingJogador)).Returns(existingJogador);
            mockMapper.Setup(m => m.Map<JogadorDto>(existingJogador)).Returns(jogadorDto);

            // Act
            var result = await jogadorService.UpdateJogadorAsync(jogadorId, jogadorDto);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(jogadorId, result.Id);
            Assert.Equal(jogadorDto.Nome, result.Nome);
            Assert.Equal(jogadorDto.Posicao, result.Posicao);
            Assert.Equal(jogadorDto.Idade, result.Idade);

            mockJogadorPersist.Verify(j => j.GetByIdAsync(It.IsAny<int>()), Times.Exactly(2));
            mockGeralPersist.Verify(g => g.Update(existingJogador), Times.Once);
            mockGeralPersist.Verify(g => g.SaveChangesAsync(), Times.Once);
            mockMapper.Verify(m => m.Map(jogadorDto, existingJogador), Times.Once);
        }

        [Fact]
        public async Task DeleteJogadorTest()
        {
            // Arrange
            mockGeralPersist.Setup(p => p.Delete(It.IsAny<Jogador>()));
            mockGeralPersist.Setup(p => p.SaveChangesAsync()).ReturnsAsync(true);

            mockJogadorPersist.Setup(p => p.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(new Jogador { Id = It.IsAny<int>() });

            // Act
            var result = await jogadorService.DeleteJogadorAsync(It.IsAny<int>());

            // Assert
            Assert.True(result);
            mockJogadorPersist.Verify(p => p.GetByIdAsync(It.IsAny<int>()), Times.Once);
            mockGeralPersist.Verify(p => p.Delete(It.IsAny<Jogador>()), Times.Once);
            mockGeralPersist.Verify(p => p.SaveChangesAsync(), Times.Once);
        }
    }
}