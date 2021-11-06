using ExamenT3.BD.Maps;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenT3.Models
{
    public class AppNotasContext: DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Etiqueta> Etiquetas { get; set; }
        public DbSet<Nota> Notas { get; set; }
        public DbSet<EtiquetaNota> EtiquetaNotas { get; set; }
        public DbSet<UsuarioNota> UsuarioNotas { get; set; }

        public AppNotasContext(DbContextOptions<AppNotasContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new EtiquetaMap());
            modelBuilder.ApplyConfiguration(new NotaMap());

            modelBuilder.ApplyConfiguration(new EtiquetaNotaMap());
            modelBuilder.ApplyConfiguration(new UsuarioNotaMap());
        }
    }
}
