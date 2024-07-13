using System;
using System.Collections.Generic;
using Application.Interfaces;
using Domain.EntityModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Infrastructure.Persistence.MSSQL;

public partial class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<City_tbl> City_tbls { get; set; }

    public virtual DbSet<Course_tbl> Course_tbls { get; set; }

    public virtual DbSet<DegreeType_tbl> DegreeType_tbls { get; set; }

    public virtual DbSet<Gender_tbl> Gender_tbls { get; set; }

    public virtual DbSet<Student_tbl> Student_tbls { get; set; }

    public virtual DbSet<Subject_tbl> Subject_tbls { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:local");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<City_tbl>(entity =>
        {
            entity.ToTable("City_tbl");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Course_tbl>(entity =>
        {
            entity.ToTable("Course_tbl");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<DegreeType_tbl>(entity =>
        {
            entity.ToTable("DegreeType_tbl");

            entity.Property(e => e.Degree)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<Gender_tbl>(entity =>
        {
            entity.ToTable("Gender_tbl");

            entity.Property(e => e.GenderName)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<Student_tbl>(entity =>
        {
            entity.ToTable("Student_tbl");

            entity.Property(e => e.CityId)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Subject_tbl>(entity =>
        {
            entity.ToTable("Subject_tbl");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
