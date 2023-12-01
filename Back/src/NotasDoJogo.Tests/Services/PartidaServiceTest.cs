using AutoMapper;
using Moq;
using NotasDoJogo.Application.Dtos;
using NotasDoJogo.Domain.Models;
using NotasDoJogo.Persistence.Contracts;
using Xunit;
using NotasDoJogo.Persistence.Services;

namespace NotasDoJogo.Tests.Services
{
    public class PartidaServiceTest
    {
        /*private readonly PartidaService partidaService;
        private readonly Mock<IGeralPersist> mockGeralPersist;
        private readonly Mock<IPartidaPersist> mockPartidaPersist;
        private readonly Mock<IMapper> mockMapper;

        public PartidaServiceTest()
        {
            mockGeralPersist = new Mock<IGeralPersist>();
            mockPartidaPersist = new Mock<IPartidaPersist>();
            mockMapper = new Mock<IMapper>();

            partidaService = new PartidaService(mockGeralPersist.Object, mockPartidaPersist.Object, mockMapper.Object);
        }

        [Fact]
        public async Task AddPartidaAsyncTest()
        {
            // Arrange
            mockGeralPersist.Setup(g => g.Add(It.IsAny<Partida>()));
            mockGeralPersist.Setup(g => g.SaveChangesAsync()).ReturnsAsync(true);

            mockPartidaPersist.Setup(p => p.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((int id) => new Partida { Id = id });

            mockMapper.Setup(m => m.Map<Partida>(It.IsAny<PartidaDto>())).Returns(new Partida());
            mockMapper.Setup(m => m.Map<PartidaDto>(It.IsAny<Partida>())).Returns(new PartidaDto());

            // Act
            var result = await partidaService.AddPartidaAsync(It.IsAny<PartidaDto>());

            // Assert
            Assert.NotNull(result);

            mockPartidaPersist.Verify(p => p.GetByIdAsync(It.IsAny<int>()), Times.Once);
            mockMapper.Verify(m => m.Map<PartidaDto>(It.IsAny<Partida>()), Times.Once);
        }

        [Fact]
        public async Task GetPartidaByIdAsyncTest()
        {
            // Arrange
            int partidaId = 1;
            TimeSpan tolerance = TimeSpan.FromSeconds(1);
            mockPartidaPersist.Setup(p => p.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(It.IsAny<Partida>());
            mockMapper.Setup(m => m.Map<PartidaDto>(It.IsAny<Partida>())).Returns(() => new PartidaDto
            {
                Id = 1,
                Jogo = "Santos x Palmeiras",
                Data = DateTime.Now,
            });

            // Act
            var result = await partidaService.GetPartidaByIdAsync(partidaId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(partidaId, result.Id);
            Assert.Equal("Santos x Palmeiras", result.Jogo);
            Assert.True((DateTime.Now - result.Data) <= tolerance);

            mockPartidaPersist.Verify(p => p.GetByIdAsync(It.IsAny<int>()), Times.Once);
            mockMapper.Verify(m => m.Map<PartidaDto>(It.IsAny<Partida>()), Times.Once);
        }

        [Fact]
        public async Task GetPartidasAsync_ReturnListOfPartidaTest()
        {
            // Arrange
            mockPartidaPersist.Setup(p => p.GetAllAsync()).ReturnsAsync(It.IsAny<List<Partida>>());

            mockMapper.Setup(m => m.Map<List<PartidaDto>>(It.IsAny<List<Partida>>())).Returns(new List<PartidaDto>
            { 
                new PartidaDto { Id = 1, Jogo = "Santos x Palmeiras", Data = DateTime.Now },
                new PartidaDto { Id = 2, Jogo = "Santos x Bahia", Data = DateTime.Now },
                new PartidaDto { Id = 3, Jogo = "Bragantino x Santos", Data = DateTime.Now }
            });

            // Act
            var result = await partidaService.GetPartidasAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(3, result.Count);
            mockPartidaPersist.Verify(p => p.GetAllAsync(), Times.Once);
            mockMapper.Verify(m => m.Map<List<PartidaDto>>(It.IsAny<List<Partida>>()), Times.Once);
        }

        [Fact]
        public async Task UpdatePartidaAsync_ExixtingPartida_ReturnUpdatePartidaTest()
        {
            // Arrange
            TimeSpan tolerance = TimeSpan.FromSeconds(1);
            var partidaId = 1;
            var partidaDto = new PartidaDto { Id = partidaId, Jogo = "Santos x Palmeiras", Data = DateTime.Now };
            var existingPartida = new Partida { Id = partidaId, Jogo = "Bragantino x Santos", Data = DateTime.Now };

            mockPartidaPersist.Setup(p => p.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(existingPartida);
            mockGeralPersist.Setup(g => g.SaveChangesAsync()).ReturnsAsync(true);

            mockMapper.Setup(m => m.Map(partidaDto, existingPartida)).Returns(existingPartida);
            mockMapper.Setup(m => m.Map<PartidaDto>(existingPartida)).Returns(partidaDto);

            // Act
            var result = await partidaService.UpdatePartidaAsync(partidaId, partidaDto);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(partidaId, result.Id);
            Assert.Equal(partidaDto.Jogo, result.Jogo);
            Assert.True((partidaDto.Data - result.Data) <= tolerance);

            mockPartidaPersist.Verify(p => p.GetByIdAsync(It.IsAny<int>()), Times.Exactly(2));
            mockGeralPersist.Verify(g => g.Update(existingPartida), Times.Once);
            mockGeralPersist.Verify(g => g.SaveChangesAsync(), Times.Once);
            mockMapper.Verify(m => m.Map(partidaDto, existingPartida), Times.Once);
        }

        [Fact]
        public async Task DeletarPartidaTest()
        {
            // Arrange
            mockGeralPersist.Setup(g => g.Delete(It.IsAny<Partida>()));
            mockGeralPersist.Setup(g => g.SaveChangesAsync()).ReturnsAsync(true);

            mockPartidaPersist.Setup(p => p.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(new Partida { Id = It.IsAny<int>() });

            // Act
            var result = await partidaService.DeletePartidaAsync(It.IsAny<int>());

            // Assert
            Assert.True(result);
            mockPartidaPersist.Verify(p => p.GetByIdAsync(It.IsAny<int>()), Times.Once);
            mockGeralPersist.Verify(g => g.Delete(It.IsAny<Partida>()), Times.Once);
            mockGeralPersist.Verify(g => g.SaveChangesAsync(), Times.Once);
        }*/
    }
}