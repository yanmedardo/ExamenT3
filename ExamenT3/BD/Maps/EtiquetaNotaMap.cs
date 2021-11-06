using ExamenT3.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenT3.BD.Maps
{
    public class EtiquetaNotaMap : IEntityTypeConfiguration<EtiquetaNota>
    {
        public void Configure(EntityTypeBuilder<EtiquetaNota> builder)
        {
            builder.ToTable("EtiquetaNotas");
            builder.HasKey(x => new { x.EtiquetaId, x.NotaId });

            builder.HasOne(x => x.Etiqueta).WithMany(x => x.EtiquetaNotas).HasForeignKey(x => x.EtiquetaId);
            builder.HasOne(x => x.Nota).WithMany(x => x.EtiquetaNotas).HasForeignKey(x => x.NotaId);
        }
    }
}
