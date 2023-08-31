using System;
using System.Collections.Generic;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Context;

public partial class ColegioContext : DbContext
{
    public ColegioContext()
    {
    }

    public ColegioContext(DbContextOptions<ColegioContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Alumno> Alumnos { get; set; }

    public virtual DbSet<AlumnoGrado> AlumnoGrados { get; set; }

    public virtual DbSet<Grado> Grados { get; set; }

    public virtual DbSet<Login> Logins { get; set; }

    public virtual DbSet<Profesor> Profesores { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-GI1V5TE;Database=colegio;Trust Server Certificate=True;User Id=userapp;Password=userapp;MultipleActiveResultSets=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Alumno>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__alumno__3213E83F8CE70C95");

            entity.ToTable("alumno");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("apellidos");
            entity.Property(e => e.FechaNacimiento)
                .HasColumnType("date")
                .HasColumnName("fechaNacimiento");
            entity.Property(e => e.Genero)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("genero");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<AlumnoGrado>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__alumnoGr__3213E83FF5BA859F");

            entity.ToTable("alumnoGrado");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AlumnoId).HasColumnName("alumnoId");
            entity.Property(e => e.GradoId).HasColumnName("gradoId");
            entity.Property(e => e.Seccion)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("seccion");

            entity.HasOne(d => d.Alumno).WithMany(p => p.AlumnoGrados)
                .HasForeignKey(d => d.AlumnoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__alumnoGra__alumn__3E52440B");

            entity.HasOne(d => d.Grado).WithMany(p => p.AlumnoGrados)
                .HasForeignKey(d => d.GradoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__alumnoGra__grado__3F466844");
        });

        modelBuilder.Entity<Grado>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__grado__3213E83FACA2CCE4");

            entity.ToTable("grado");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.ProfesorId).HasColumnName("profesorId");

            entity.HasOne(d => d.Profesor).WithMany(p => p.Grados)
                .HasForeignKey(d => d.ProfesorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__grado__profesorI__3B75D760");
        });

        modelBuilder.Entity<Login>(entity =>
        {
            entity.HasKey(e => e.Usuario).HasName("PK__login__9AFF8FC77289D56C");

            entity.ToTable("login");

            entity.Property(e => e.Usuario)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("usuario");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Pass)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("pass");
            entity.Property(e => e.ProfesorId).HasColumnName("profesorId");

            entity.HasOne(d => d.Profesor).WithMany(p => p.Logins)
                .HasForeignKey(d => d.ProfesorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__login__email__49C3F6B7");
        });

        modelBuilder.Entity<Profesor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__profesor__3213E83F5AD843F1");

            entity.ToTable("profesor");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("apellidos");
            entity.Property(e => e.Genero)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("genero");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
