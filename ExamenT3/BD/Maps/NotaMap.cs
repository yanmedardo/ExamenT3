using ExamenT3.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenT3.BD.Maps
{
    public class NotaMap : IEntityTypeConfiguration<Nota>
    {
        public void Configure(EntityTypeBuilder<Nota> builder)
        {
            builder.ToTable("Notas");
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Creador).WithMany(x => x.Notas).HasForeignKey(x => x.CreadorId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
