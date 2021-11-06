using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenFinal.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public ICollection<Nota> Notas { get; set; }
        public ICollection<UsuarioNota> UsuarioNotas { get; set; }
    }
}
