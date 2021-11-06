using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenFinal.Models
{
    public class UsuarioNota
    {
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public int NotaId { get; set; }
        public Nota Nota { get; set; }
    }
}
