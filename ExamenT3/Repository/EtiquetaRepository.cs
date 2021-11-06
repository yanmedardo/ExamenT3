using ExamenFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenFinal.Repository
{
    public interface IEtiquetaRepository
    {
        public ICollection<Etiqueta> Listar();
        public void Registrar(Etiqueta etiqueta);
    }

    public class EtiquetaRepository : IEtiquetaRepository
    {
        private AppNotasContext context;

        public EtiquetaRepository(AppNotasContext context)
        {
            this.context = context;
        }

        public ICollection<Etiqueta> Listar()
        {
            return context.Etiquetas.ToList();
        }

        public void Registrar(Etiqueta etiqueta)
        {
            context.Add(etiqueta);
            context.SaveChanges();
        }
    }
}
