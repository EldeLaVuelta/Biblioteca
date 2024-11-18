using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CRUDUSUARIOS3.Models;

public partial class SucioContext : DbContext
{
    public SucioContext()
    {
    }

    public SucioContext(DbContextOptions<SucioContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Usuarios3> Usuarios3s { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer(" Data Source=DESKTOP-I9POER9\\SQLEXPRESS;Initial Catalog=SUCIO;Integrated Security=True;Trust Server Certificate=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Usuarios3>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Usuarios__3214EC07AD874D6E");

            entity.ToTable("Usuarios3");

            entity.Property(e => e.Clave)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
