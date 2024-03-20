﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using colecaohq.Data.Context;

namespace colecaohq.Data.Migrations
{
    [DbContext(typeof(MeuDbContext))]
    partial class MeuDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("colecaohq.Business.Models.Editora", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("NomeEditora")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Editora");
                });

            modelBuilder.Entity("colecaohq.Business.Models.EquipePerssonagem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DescricaoEquipePerssonagem")
                        .HasColumnType("varchar(MAX)");

                    b.Property<string>("NomeEquipePerssonagem")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.ToTable("EquipePerssonagem");
                });

            modelBuilder.Entity("colecaohq.Business.Models.HqPerssonagem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("EquipePerssonagemId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TituloHqId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("EquipePerssonagemId");

                    b.HasIndex("TituloHqId");

                    b.ToTable("HqPerssonagem");
                });

            modelBuilder.Entity("colecaohq.Business.Models.TituloHQ", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AnoLancamento")
                        .HasColumnType("varchar(4)");

                    b.Property<string>("EdicoesPossuidas")
                        .HasColumnType("varchar(200)");

                    b.Property<Guid>("EditoraId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Sinopse")
                        .HasColumnType("varchar(MAX)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("TipoPublicacao")
                        .HasColumnType("int");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("TituloOriginal")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("TotalEdicoes")
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("EditoraId");

                    b.ToTable("TituloHQ");
                });

            modelBuilder.Entity("colecaohq.Business.Models.HqPerssonagem", b =>
                {
                    b.HasOne("colecaohq.Business.Models.EquipePerssonagem", "EquipePerssonagem")
                        .WithMany("HqPerssonagens")
                        .HasForeignKey("EquipePerssonagemId")
                        .IsRequired();

                    b.HasOne("colecaohq.Business.Models.TituloHQ", "TituloHQ")
                        .WithMany("HqPerssonagems")
                        .HasForeignKey("TituloHqId")
                        .IsRequired();
                });

            modelBuilder.Entity("colecaohq.Business.Models.TituloHQ", b =>
                {
                    b.HasOne("colecaohq.Business.Models.Editora", "Editora")
                        .WithMany("TituloHQs")
                        .HasForeignKey("EditoraId")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}