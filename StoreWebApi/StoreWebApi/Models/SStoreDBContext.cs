using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace StoreWebApi.Models
{
    public partial class SStoreDBContext : DbContext
    {
        public SStoreDBContext()
        {
        }

        public SStoreDBContext(DbContextOptions<SStoreDBContext> options)
            : base(options)
        {
        }


        public virtual DbSet<Ciudad> Ciudad { get; set; }
        public virtual DbSet<Clima> Clima { get; set; }
        public virtual DbSet<Noticia> Noticia { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Server= DESKTOP-PIB9MC0\\SQLEXPRESS;Database= SStoreDB;Integrated Security=SSPI");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ciudad>(entity =>
            {
                entity.Property(e => e.CiudadId).HasColumnName("Ciudad_id");

                entity.Property(e => e.CiudadNombre)
                    .IsRequired()
                    .HasColumnName("CIudad_Nombre")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Clima>(entity =>
            {
                entity.HasIndex(e => e.ClimaId)
                    .HasName("IX_Clima");

                entity.Property(e => e.ClimaId).HasColumnName("Clima_Id");

                entity.Property(e => e.CiudadId).HasColumnName("Ciudad_Id");

                entity.Property(e => e.ClimaCubreNube).HasColumnName("Clima_Cubre_Nube");

                entity.Property(e => e.ClimaDescripcion)
                    .IsRequired()
                    .HasColumnName("Clima_Descripcion")
                    .HasMaxLength(100);

                entity.Property(e => e.ClimaDirViento)
                    .IsRequired()
                    .HasColumnName("Clima_Dir_Viento")
                    .HasMaxLength(10);

                entity.Property(e => e.ClimaGradoViento).HasColumnName("Clima_Grado_Viento");

                entity.Property(e => e.ClimaHumedad).HasColumnName("Clima_Humedad");

                entity.Property(e => e.ClimaMaxmo).HasColumnName("Clima_Maxmo");

                entity.Property(e => e.ClimaObserTiempo)
                    .HasColumnName("Clima_Obser_Tiempo")
                    .HasColumnType("datetime");

                entity.Property(e => e.ClimaPresicion).HasColumnName("Clima_Presicion");

                entity.Property(e => e.ClimaVelViento).HasColumnName("Clima_Vel_Viento");

                entity.Property(e => e.ClimaVisibilidad).HasColumnName("Clima_Visibilidad");

                //entity.HasOne(d => d.Ciudad)
                //    .WithMany(p => p.Clima)
                //    .HasForeignKey(d => d.CiudadId)
                //    .HasConstraintName("FK_Clima_Ciudad");
            });

            modelBuilder.Entity<Noticia>(entity =>
            {
                entity.Property(e => e.NoticiaId).HasColumnName("Noticia_id");

                entity.Property(e => e.ClimaId).HasColumnName("Clima_id");

                entity.Property(e => e.NoticiaAutor)
                    .IsRequired()
                    .HasColumnName("Noticia_Autor")
                    .HasMaxLength(200);

                entity.Property(e => e.NoticiaContenido)
                    .IsRequired()
                    .HasColumnName("Noticia_Contenido")
                    .HasMaxLength(200);

                entity.Property(e => e.NoticiaDescripcion)
                    .IsRequired()
                    .HasColumnName("Noticia_Descripcion")
                    .HasMaxLength(200);

                entity.Property(e => e.NoticiaFecha)
                    .HasColumnName("Noticia_Fecha")
                    .HasColumnType("datetime");

                entity.Property(e => e.NoticiaTitulo)
                    .IsRequired()
                    .HasColumnName("Noticia_Titulo")
                    .HasMaxLength(200);

                entity.Property(e => e.NoticiaUrl)
                    .IsRequired()
                    .HasColumnName("Noticia_Url")
                    .HasMaxLength(200);

                //entity.HasOne(d => d.Clima)
                //    .WithMany(p => p.Noticia)
                //    .HasForeignKey(d => d.ClimaId)
                //    .HasConstraintName("FK_Noticia_Clima");
            });
        }
    }
}
