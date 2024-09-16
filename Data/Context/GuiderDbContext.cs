using System;
using System.Collections.Generic;
using GuiderTestTask.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace GuiderTestTask.Data.Context;

public partial class GuiderDbContext : DbContext
{
    public GuiderDbContext()
    {
        Database.MigrateAsync();
    }

    public GuiderDbContext(DbContextOptions<GuiderDbContext> options)
        : base(options)
    {
        Database.MigrateAsync();
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Establishment> Establishments { get; set; }

    public virtual DbSet<Tag> Tags { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;database=guider_db;uid=root;pwd=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.39-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");
            
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.HasIndex(e => e.Name);
        });

        modelBuilder.Entity<Establishment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasOne(d => d.Category).WithMany(p => p.Establishments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("establishments_ibfk_1");

            entity.HasMany(d => d.Tags).WithMany(p => p.Establishments)
                .UsingEntity<Dictionary<string, object>>(
                    "EstablishmentTag",
                    r => r.HasOne<Tag>().WithMany()
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("establishment_tags_ibfk_2"),
                    l => l.HasOne<Establishment>().WithMany()
                        .HasForeignKey("EstablishmentId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("establishment_tags_ibfk_1"),
                    j =>
                    {
                        j.HasKey("EstablishmentId", "TagId")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j.ToTable("establishment_tags");
                        j.HasIndex(new[] { "TagId" }, "tag_id");
                        j.IndexerProperty<long>("EstablishmentId").HasColumnName("establishment_id");
                        j.IndexerProperty<long>("TagId").HasColumnName("tag_id");
                    });
        });

        modelBuilder.Entity<Tag>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
