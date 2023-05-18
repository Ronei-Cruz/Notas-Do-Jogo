using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotasDoJogo.Application.Dtos
{
    public class PartidaNotaDTO
    {
        public int PartidaId { get; set; }
        public PartidaDTO Partida { get; set; }
        public int NotaId { get; set; }
        public NotaDTO Nota { get; set; }
    }
}