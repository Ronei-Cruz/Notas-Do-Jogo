using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotasDoJogo.Domain.Models
{
    public class PartidaNota
    {
        public int PartidaId { get; set; }
        public Partida Partida { get; set; }
        public int NotaId { get; set; }
        public Nota Nota { get; set; }
    }
    
}