using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenFinal.Models
{
    public class Nota
    {
        public int Id { get; set; }
        public int CreadorId { get; set; }
        public Usuario Creador { get; set; }
        public string Titulo { get; set; }
        public string Contenido { get; set; }
        public DateTime UltimaModificacion { get; set; }
        public ICollection<EtiquetaNota> EtiquetaNotas { get; set; }
        public ICollection<UsuarioNota> UsuarioNotas { get; set; }
    }
}
