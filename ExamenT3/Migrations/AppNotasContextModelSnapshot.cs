// <auto-generated />
using System;
using ExamenT3.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ExamenT3.Migrations
{
    [DbContext(typeof(AppNotasContext))]
    partial class AppNotasContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ExamenT3.Models.Etiqueta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Etiquetas");
                });

            modelBuilder.Entity("ExamenT3.Models.EtiquetaNota", b =>
                {
                    b.Property<int>("EtiquetaId")
                        .HasColumnType("int");

                    b.Property<int>("NotaId")
                        .HasColumnType("int");

                    b.HasKey("EtiquetaId", "NotaId");

                    b.HasIndex("NotaId");

                    b.ToTable("EtiquetaNotas");
                });

            modelBuilder.Entity("ExamenT3.Models.Nota", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Contenido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CreadorId")
                        .HasColumnType("int");

                    b.Property<string>("Titulo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UltimaModificacion")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CreadorId");

                    b.ToTable("Notas");
                });

            modelBuilder.Entity("ExamenT3.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("ExamenT3.Models.UsuarioNota", b =>
                {
                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.Property<int>("NotaId")
                        .HasColumnType("int");

                    b.HasKey("UsuarioId", "NotaId");

                    b.HasIndex("NotaId");

                    b.ToTable("UsuarioNotas");
                });

            modelBuilder.Entity("ExamenT3.Models.EtiquetaNota", b =>
                {
                    b.HasOne("ExamenT3.Models.Etiqueta", "Etiqueta")
                        .WithMany("EtiquetaNotas")
                        .HasForeignKey("EtiquetaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ExamenT3.Models.Nota", "Nota")
                        .WithMany("EtiquetaNotas")
                        .HasForeignKey("NotaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Etiqueta");

                    b.Navigation("Nota");
                });

            modelBuilder.Entity("ExamenT3.Models.Nota", b =>
                {
                    b.HasOne("ExamenT3.Models.Usuario", "Creador")
                        .WithMany("Notas")
                        .HasForeignKey("CreadorId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Creador");
                });

            modelBuilder.Entity("ExamenT3.Models.UsuarioNota", b =>
                {
                    b.HasOne("ExamenT3.Models.Nota", "Nota")
                        .WithMany("UsuarioNotas")
                        .HasForeignKey("NotaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ExamenT3.Models.Usuario", "Usuario")
                        .WithMany("UsuarioNotas")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Nota");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("ExamenT3.Models.Etiqueta", b =>
                {
                    b.Navigation("EtiquetaNotas");
                });

            modelBuilder.Entity("ExamenT3.Models.Nota", b =>
                {
                    b.Navigation("EtiquetaNotas");

                    b.Navigation("UsuarioNotas");
                });

            modelBuilder.Entity("ExamenT3.Models.Usuario", b =>
                {
                    b.Navigation("Notas");

                    b.Navigation("UsuarioNotas");
                });
#pragma warning restore 612, 618
        }
    }
}
