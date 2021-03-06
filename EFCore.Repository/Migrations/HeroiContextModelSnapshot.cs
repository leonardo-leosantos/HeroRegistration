﻿// <auto-generated />
using System;
using EFCore.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EFCore.Repository.Migrations
{
    [DbContext(typeof(HeroiContext))]
    partial class HeroiContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EFCore.Domain.Arma", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("IdHeroi")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("IdHeroi");

                    b.ToTable("Armas");
                });

            modelBuilder.Entity("EFCore.Domain.Batalha", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DtFim")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DtInicio")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Batalhas");
                });

            modelBuilder.Entity("EFCore.Domain.Heroi", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Herois");
                });

            modelBuilder.Entity("EFCore.Domain.HeroiBatalha", b =>
                {
                    b.Property<Guid>("IdHeroi")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdBatalha")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("IdHeroi", "IdBatalha");

                    b.HasIndex("IdBatalha");

                    b.ToTable("HeroisBatalhas");
                });

            modelBuilder.Entity("EFCore.Domain.IdentidadeSecreta", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdHeroi")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("NomeReal")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdHeroi")
                        .IsUnique();

                    b.ToTable("IdentidadesSecretas");
                });

            modelBuilder.Entity("EFCore.Domain.Arma", b =>
                {
                    b.HasOne("EFCore.Domain.Heroi", null)
                        .WithMany("Armas")
                        .HasForeignKey("IdHeroi")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EFCore.Domain.HeroiBatalha", b =>
                {
                    b.HasOne("EFCore.Domain.Batalha", "Batalha")
                        .WithMany("HeroiBatalhas")
                        .HasForeignKey("IdBatalha")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EFCore.Domain.Heroi", "Heroi")
                        .WithMany("HeroiBatalhas")
                        .HasForeignKey("IdHeroi")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EFCore.Domain.IdentidadeSecreta", b =>
                {
                    b.HasOne("EFCore.Domain.Heroi", "Heroi")
                        .WithOne("Identidade")
                        .HasForeignKey("EFCore.Domain.IdentidadeSecreta", "IdHeroi")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
