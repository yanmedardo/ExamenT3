using ExamenFinal.Models;
using ExamenFinal.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ExamenFinal.Repository
{
    public interface IUsuarioRepository
    {
        public void Registrar(string username, string password);
        public Usuario FindUser(string username, string password);
        public Usuario UserLogged(Claim claim);
        public ICollection<Usuario> Listar();
    }

    public class UsuarioRepository : IUsuarioRepository
    {

        private AppNotasContext _context;

        public UsuarioRepository(AppNotasContext context)
        {
            _context = context;
        }

        public Usuario FindUser(string username, string password)
        {
            var user = _context.Usuarios.FirstOrDefault(o => o.Username == username && o.Password == password);
            return user;
        }

        public void Registrar(string username, string password)
        {
            var user = new Usuario { Username = username, Password = password };
            _context.Usuarios.Add(user);
            _context.SaveChanges();
        }

        public Usuario UserLogged(Claim claim)
        {
            var user = _context.Usuarios.FirstOrDefault(o => o.Username == claim.Value);
            return user;
        }

        public ICollection<Usuario> Listar()
        {
            return _context.Usuarios.ToList();
        }
    }
}
