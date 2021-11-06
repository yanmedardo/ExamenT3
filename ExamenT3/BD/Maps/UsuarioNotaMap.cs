using ExamenT3.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenT3.BD.Maps
{
    public class UsuarioNotaMap : IEntityTypeConfiguration<UsuarioNota>
    {
        public void Configure(EntityTypeBuilder<UsuarioNota> builder)
        {
            builder.ToTable("UsuarioNotas");
            builder.HasKey(x => new { x.UsuarioId, x.NotaId });

            builder.HasOne(x => x.Usuario).WithMany(x => x.UsuarioNotas).HasForeignKey(x => x.UsuarioId);
            builder.HasOne(x => x.Nota).WithMany(x => x.UsuarioNotas).HasForeignKey(x => x.NotaId);
        }
    }
}
