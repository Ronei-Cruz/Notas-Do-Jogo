using AutoMapper;
using Moq;
using NotasDoJogo.Application.Dtos;
using NotasDoJogo.Domain.Models;
using NotasDoJogo.Persistence.Contracts;
using NotasDoJogo.Persistence.Services;
using Xunit;

namespace NotasDoJogo.Tests.Services
{
    public class NotaServiceTest
    {
        private readonly NotaService notaService;
        private readonly Mock<IGeralPersist> mockGeralPersist;
        private readonly Mock<INotaPersist> mockNotaPersist;
        private readonly Mock<IMapper> mockMapper;
        public NotaServiceTest()
        {
            mockGeralPersist = new Mock<IGeralPersist>();
            mockNotaPersist = new Mock<INotaPersist>();
            mockMapper = new Mock<IMapper>();

            notaService = new NotaService(mockGeralPersist.Object, mockNotaPersist.Object, mockMapper.Object);
        }

        [Fact]
        public async Task AddNotaAsyncTest()
        {
            // Arrange
            mockGeralPersist.Setup(g => g.Add(It.IsAny<Nota>()));
            mockGeralPersist.Setup(g => g.SaveChangesAsync()).ReturnsAsync(true);

            mockNotaPersist.Setup(n => n.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(( ) => new Nota { Id = It.IsAny<int>() });

            mockMapper.Setup(m => m.Map<Nota>(It.IsAny<NotaDto>())).Returns(new Nota());
            mockMapper.Setup(m => m.Map<NotaDto>(It.IsAny<Nota>())).Returns(new NotaDto());

            // Act
            var result = await notaService.AddNotaAsync(It.IsAny<NotaDto>());

            // Assert
            Assert.NotNull(result);

            mockNotaPersist.Verify(n => n.GetByIdAsync(It.IsAny<int>()), Times.Once);
            mockMapper.Verify(m => m.Map<NotaDto>(It.IsAny<Nota>()), Times.Once);
        }

        [Fact]
        public async Task GetNotaByIdAsyncTest()
        {
            // Arrange
            int notaId = 1;
            mockNotaPersist.Setup(n => n.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(It.IsAny<Nota>());
            mockMapper.Setup(m => m.Map<NotaDto>(It.IsAny<Nota>())).Returns(() => new NotaDto { 
                Id = notaId,
                JogadorId = 2,
                UsuarioId = 4,
                PartidaId = 2,
                Valor = 8
            });

            // Act
            var result = await notaService.GetNotaByIdAsync(notaId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(notaId, result.Id);
            Assert.Equal(2, result.JogadorId);
            Assert.Equal(4, result.UsuarioId);
            Assert.Equal(2, result.PartidaId);
            Assert.Equal(8, result.Valor);

            mockNotaPersist.Verify(n => n.GetByIdAsync(It.IsAny<int>()), Times.Once);
            mockMapper.Verify(m => m.Map<NotaDto>(It.IsAny<Nota>()), Times.Once);
        }

        [Fact]
        public async Task GetNotasAsync_ReturnListOfNotaDtoTest()
        {
            // Arrange
            mockNotaPersist.Setup(n => n.GetAllAsync()).ReturnsAsync(It.IsAny<List<Nota>>());

            mockMapper.Setup(m => m.Map<List<NotaDto>>(It.IsAny<List<Nota>>())).Returns(new List<NotaDto>
            {
                new NotaDto {Id = 1, JogadorId = 2, UsuarioId = 3, PartidaId = 4, Valor = 7 },
                new NotaDto {Id = 2, JogadorId = 2, UsuarioId = 2, PartidaId = 4, Valor = 5 },
                new NotaDto {Id = 3, JogadorId = 2, UsuarioId = 5, PartidaId = 4, Valor = 8 }
            });

            // Act
            var result = await notaService.GetNotasAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(3, result.Count);

            mockNotaPersist.Verify(n => n.GetAllAsync(), Times.Once);
            mockMapper.Verify(m => m.Map<List<NotaDto>>(It.IsAny<List<Nota>>()), Times.Once);
        }

        [Fact]
        public async Task GetNotasByUsuarioIdAsync_ReturnListOfNotasOfUsuarioIdTest()
        {
            // Arrange
            int usuarioId = 1;
            var notas = new List<Nota>
            {
                new Nota {Id = 1, JogadorId = 3, UsuarioId = usuarioId, PartidaId = 1, Valor = 7 },
                new Nota {Id = 2, JogadorId = 2, UsuarioId = 2, PartidaId = 1, Valor = 5 },
                new Nota {Id = 3, JogadorId = 4, UsuarioId = usuarioId, PartidaId = 2, Valor = 8 }
            };

            mockNotaPersist.Setup(n => n.GetNotasByUsuarioIdAsync(usuarioId)).ReturnsAsync(notas);
            mockMapper.Setup(m => m.Map<List<NotaDto>>(notas)).Returns(new List<NotaDto>
            {
                new NotaDto {Id = 1, JogadorId = 3, UsuarioId = usuarioId, PartidaId = 1, Valor = 7 },
                new NotaDto {Id = 3, JogadorId = 4, UsuarioId = usuarioId, PartidaId = 2, Valor = 8 }
            });

            // Act
            var result = await notaService.GetNotasByUsuarioIdAsync(usuarioId);

            // Assert
            Assert.NotNull(result);
            mockNotaPersist.Verify(n => n.GetNotasByUsuarioIdAsync(usuarioId), Times.Once);
            mockMapper.Verify(m => m.Map<List<NotaDto>>(It.IsAny<List<Nota>>()), Times.Once);
        }
        
        [Fact]
        public async Task GetNotasPartidaIdByJogadorIdAsyncTest()
        {
            // Arrange
            int jogadorId = 2;
            int partidaId = 1;
            var notas = new List<Nota>
            {
                new Nota {Id = 1, JogadorId = jogadorId, UsuarioId = 3, PartidaId = partidaId, Valor = 7 },
                new Nota {Id = 2, JogadorId = 1, UsuarioId = 2, PartidaId = partidaId, Valor = 5 },
                new Nota {Id = 3, JogadorId = jogadorId, UsuarioId = 5, PartidaId = partidaId, Valor = 8 }
            };

            mockNotaPersist.Setup(n => n.GetNotasPartidaIdByJogadorIdAsync(jogadorId, partidaId)).ReturnsAsync(notas);
            mockMapper.Setup(m => m.Map<List<NotaDto>>(It.IsAny<List<Nota>>()))
                .Returns((List<Nota> source) => source
                    .Where(n => n.JogadorId == jogadorId && n.PartidaId == partidaId)
                    .Select(n => new NotaDto 
                    {
                        Id = n.Id, 
                        JogadorId = n.JogadorId, 
                        UsuarioId = n.UsuarioId, 
                        PartidaId = n.PartidaId, 
                        Valor = n.Valor 
                    }).ToList());
            
            // Act
            var result = await notaService.GetNotasPartidaIdByJogadorIdAsync(jogadorId, partidaId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);

            mockNotaPersist.Verify(n => n.GetNotasPartidaIdByJogadorIdAsync(jogadorId, partidaId), Times.Once);
            mockMapper.Verify(m => m.Map<List<NotaDto>>(It.IsAny<List<Nota>>()), Times.Once);
        }

        [Fact]
        public async Task GetNotaCountByJogadorIdAsyncRetunMediaJogadorIdPerPartidaIdTest()
        {
            // Arrange
            int jogadorId = 2;
            int partidaId = 1;

            var notas = new List<Nota>
            {
                new Nota {Id = 1, JogadorId = jogadorId, UsuarioId = 3, PartidaId = partidaId, Valor = 7 },
                new Nota {Id = 2, JogadorId = 4, UsuarioId = 2, PartidaId = partidaId, Valor = 5 },
                new Nota {Id = 3, JogadorId = jogadorId, UsuarioId = 5, PartidaId = partidaId, Valor = 8 }
            };

            mockNotaPersist.Setup(n => n.GetNotasPartidaIdByJogadorIdAsync(jogadorId, partidaId))
                .ReturnsAsync(notas.Where(n => n.JogadorId == jogadorId && n.PartidaId == partidaId).ToList());
            
            // Act
            var result = await notaService.GetNotaCountByJogadorIdAsync(jogadorId, partidaId);

            // Assert
            Assert.Equal(7.5, (double)result);

            mockNotaPersist.Verify(n => n.GetNotasPartidaIdByJogadorIdAsync(jogadorId, partidaId), Times.Once);
        }

        [Fact]
        public async Task GetMediaPartidaAsyncTest()
        {
            // Arrange
            int partidaId = 1;
            var notas = new List<Nota>
            {
                new Nota {Id = 1, JogadorId = 1, UsuarioId = 3, PartidaId = partidaId, Valor = 7 },
                new Nota {Id = 2, JogadorId = 4, UsuarioId = 2, PartidaId = partidaId, Valor = 6 },
                new Nota {Id = 3, JogadorId = 4, UsuarioId = 5, PartidaId = 2, Valor = 8 }
            };
        
            mockNotaPersist.Setup(n => n.GetNotasByPartidaIdAsync(partidaId))
                .ReturnsAsync(notas.Where(n => n.PartidaId == partidaId).ToList());

            // Act
            var result = await notaService.GetMediaPartidaAsync(partidaId);

            // Assert
            Assert.Equal(6.5, (double)result);

            mockNotaPersist.Verify(n => n.GetNotasByPartidaIdAsync(partidaId), Times.Once);
        }

        [Fact]
        public async Task DeleteNotaTest()
        {
            // Arrange
            mockGeralPersist.Setup(g => g.Delete(It.IsAny<Nota>()));
            mockGeralPersist.Setup(g => g.SaveChangesAsync()).ReturnsAsync(true);

            mockNotaPersist.Setup(n => n.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(new Nota { Id = It.IsAny<int>() });

            // Act
            var result = await notaService.DeleteNotaAsync(It.IsAny<int>());

            // Assert
            Assert.True(result);
            mockNotaPersist.Verify(n => n.GetByIdAsync(It.IsAny<int>()), Times.Once);
            mockGeralPersist.Verify(g => g.Delete(It.IsAny<Nota>()), Times.Once);
            mockGeralPersist.Verify(g => g.SaveChangesAsync(), Times.Once);
        }
    }
}