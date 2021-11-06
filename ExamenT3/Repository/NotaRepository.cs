using ExamenFinal.Models;
using ExamenFinal.Service;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenFinal.Repository
{
    public interface INotaRepository
    {
        public ICollection<Nota> Listar(string buscar, int etiqueta);
        public Nota ObtenerPorId(int id);
        public void Registrar(Nota nota);
        public void AsignarEtiquetas(Nota nota, int[] etiquetasId);
        public void Editar(int id, Nota nota);
        public void Eliminar(int id);
        public void Compartir(int id, int[] usuariosId);
        public ICollection<Nota> ListarCompartidasConmigo();
    }

    public class NotaRepository : INotaRepository
    {
        private AppNotasContext context;
        private ICookieAuthService cookie;

        public NotaRepository(AppNotasContext context, ICookieAuthService cookie)
        {
            this.context = context;
            this.cookie = cookie;
        }

        public void Compartir(int id, int[] usuariosId)
        {
            var usuariosNotas = context.UsuarioNotas.Where(x => x.NotaId == id);
            context.UsuarioNotas.RemoveRange(usuariosNotas);
            context.SaveChanges();

            foreach (var usuarioId in usuariosId)
            {
                context.UsuarioNotas.Add(new UsuarioNota { UsuarioId = usuarioId, NotaId = id });
            }
            context.SaveChanges();
        }

        public void Editar(int id, Nota nota)
        {
            var notaBd = ObtenerPorId(id);
            notaBd.Titulo = nota.Titulo;
            notaBd.Contenido = nota.Contenido;
            notaBd.UltimaModificacion = DateTime.Now;
            context.SaveChanges();
        }

        public void Eliminar(int id)
        {
            var nota = context.Notas.Where(x => x.Id == id).First();
            context.Notas.Remove(nota);
            context.SaveChanges();
        }

        public ICollection<Nota> Listar(string buscar, int etiqueta)
        {
            var user = cookie.GetUserLogged();

            if (etiqueta > 0)
            {
                var etiquetaNotas = context.EtiquetaNotas.Include(x => x.Nota).Where(x => x.EtiquetaId == etiqueta).ToList();
                var notas = new List<Nota>();

                foreach (var etiquetaNota in etiquetaNotas)
                {
                    var nota = etiquetaNota.Nota;
                    if (nota.CreadorId == user.Id)
                    {
                        notas.Add(etiquetaNota.Nota);
                    }
                }

                return notas;
            }

            if (buscar != "")
            {
                return context.Notas.Where(x => x.CreadorId == user.Id).Where(x => x.Titulo.Contains(buscar) || x.Contenido.Contains(buscar)).ToList();
            }
            return context.Notas.Where(x => x.CreadorId == user.Id).ToList();
        }

        public ICollection<Nota> ListarCompartidasConmigo()
        {
            var user = cookie.GetUserLogged();
            var compartidos = context.UsuarioNotas.Include(x => x.Nota).Where(x => x.UsuarioId == user.Id).ToList();
            var notas = new List<Nota>();
            foreach (var compartido in compartidos)
            {
                notas.Add(compartido.Nota);
            }
            return notas;
        }

        public void Registrar(Nota nota)
        {
            nota.CreadorId = cookie.GetUserLogged().Id;
            nota.UltimaModificacion = DateTime.Now;
            context.Notas.Add(nota);
            context.SaveChanges();
        }

        public Nota ObtenerPorId(int id)
        {
            return context.Notas.Where(x => x.Id == id).Include(x => x.EtiquetaNotas).ThenInclude(x => x.Etiqueta).First();
        }

        public void AsignarEtiquetas(Nota nota, int[] etiquetasId)
        {
            var etiquetasNotas = context.EtiquetaNotas.Where(x => x.NotaId == nota.Id);
            context.EtiquetaNotas.RemoveRange(etiquetasNotas);
            context.SaveChanges();

            foreach (int etiquetaId in etiquetasId)
            {
                context.EtiquetaNotas.Add(new EtiquetaNota { 
                    EtiquetaId = etiquetaId,
                    NotaId = nota.Id
                });
            }
            context.SaveChanges();
        }
    }
}
