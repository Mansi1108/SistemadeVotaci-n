using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace API_Votos.Models;

public partial class VotosContext : DbContext
{
    public VotosContext()
    {
    }

    public VotosContext(DbContextOptions<VotosContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CandidatosPresidenciale> CandidatosPresidenciales { get; set; }

    public virtual DbSet<Votosp> Votosps { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        {

            IConfigurationRoot configuration = new ConfigurationBuilder()

            .SetBasePath(Directory.GetCurrentDirectory())

                        .AddJsonFile("appsettings.json")

                        .Build();

            var connectionString = configuration.GetConnectionString("ConectionDB");

            optionsBuilder.UseMySQL(connectionString);

        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CandidatosPresidenciale>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("candidatos_presidenciales");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DepartamentoNacimiento)
                .HasMaxLength(100)
                .HasColumnName("departamento_nacimiento");
            entity.Property(e => e.Edad).HasColumnName("edad");
            entity.Property(e => e.FechaIngresoPartido)
                .HasColumnType("timestamp")
                .HasColumnName("fecha_ingreso_partido");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("fecha_registro");
            entity.Property(e => e.FotoUrl)
                .HasMaxLength(200)
                .HasColumnName("foto_url");
            entity.Property(e => e.Nacionalidad)
                .HasMaxLength(100)
                .HasColumnName("nacionalidad");
            entity.Property(e => e.NoDpi)
                .HasMaxLength(15)
                .HasColumnName("no_dpi");
            entity.Property(e => e.NombreCompleto)
                .HasMaxLength(100)
                .HasColumnName("nombre_completo");
            entity.Property(e => e.PartidoPolitico)
                .HasMaxLength(50)
                .HasColumnName("partido_politico");
        });

        modelBuilder.Entity<Votosp>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("votosp");

            entity.HasIndex(e => e.IdCandidato, "id_candidato");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdCandidato).HasColumnName("id_candidato");
            entity.Property(e => e.NoDpi)
                .HasMaxLength(15)
                .HasColumnName("no_dpi");

            entity.HasOne(d => d.IdCandidatoNavigation).WithMany(p => p.Votosps)
                .HasForeignKey(d => d.IdCandidato)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("votosp_ibfk_1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
