﻿// <auto-generated />
using GuiderTestTask.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GuiderTestTasj.Migrations
{
    [DbContext(typeof(GuiderDbContext))]
    [Migration("20240916164913_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseCollation("utf8mb4_0900_ai_ci")
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.HasCharSet(modelBuilder, "utf8mb4");
            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("EstablishmentTag", b =>
                {
                    b.Property<long>("EstablishmentId")
                        .HasColumnType("bigint")
                        .HasColumnName("establishment_id");

                    b.Property<long>("TagId")
                        .HasColumnType("bigint")
                        .HasColumnName("tag_id");

                    b.HasKey("EstablishmentId", "TagId")
                        .HasName("PRIMARY")
                        .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                    b.HasIndex(new[] { "TagId" }, "tag_id");

                    b.ToTable("establishment_tags", (string)null);
                });

            modelBuilder.Entity("GuiderTestTask.Data.Entities.Category", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Description")
                        .HasMaxLength(2000)
                        .HasColumnType("varchar(2000)")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex("Name");

                    b.ToTable("categories");
                });

            modelBuilder.Entity("GuiderTestTask.Data.Entities.Establishment", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(400)
                        .HasColumnType("varchar(400)")
                        .HasColumnName("address");

                    b.Property<long>("CategoryId")
                        .HasColumnType("bigint")
                        .HasColumnName("categoryId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("varchar(120)")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "Address" }, "address_idx")
                        .IsUnique();

                    b.HasIndex(new[] { "CategoryId" }, "category_idx");

                    b.ToTable("establishments");
                });

            modelBuilder.Entity("GuiderTestTask.Data.Entities.Tag", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(600)
                        .HasColumnType("varchar(600)")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("varchar(40)")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.ToTable("tags");
                });

            modelBuilder.Entity("EstablishmentTag", b =>
                {
                    b.HasOne("GuiderTestTask.Data.Entities.Establishment", null)
                        .WithMany()
                        .HasForeignKey("EstablishmentId")
                        .IsRequired()
                        .HasConstraintName("establishment_tags_ibfk_1");

                    b.HasOne("GuiderTestTask.Data.Entities.Tag", null)
                        .WithMany()
                        .HasForeignKey("TagId")
                        .IsRequired()
                        .HasConstraintName("establishment_tags_ibfk_2");
                });

            modelBuilder.Entity("GuiderTestTask.Data.Entities.Establishment", b =>
                {
                    b.HasOne("GuiderTestTask.Data.Entities.Category", "Category")
                        .WithMany("Establishments")
                        .HasForeignKey("CategoryId")
                        .IsRequired()
                        .HasConstraintName("establishments_ibfk_1");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("GuiderTestTask.Data.Entities.Category", b =>
                {
                    b.Navigation("Establishments");
                });
#pragma warning restore 612, 618
        }
    }
}
