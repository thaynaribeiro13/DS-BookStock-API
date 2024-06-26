﻿// <auto-generated />
using BookStock.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DS.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240429001119_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BookStock.Models.Livro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Autor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gênero")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RegistroLivro")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("TB_LIVROS", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Autor = "Emily Trunko",
                            Gênero = "Drama",
                            Nome = "Últimas Mensagens Recebidas",
                            RegistroLivro = 0
                        },
                        new
                        {
                            Id = 2,
                            Autor = "Taylor Jenkins Reid",
                            Gênero = "Romance",
                            Nome = "Os Sete Maridos de Evelyn Hugo",
                            RegistroLivro = 0
                        },
                        new
                        {
                            Id = 3,
                            Autor = "C. C. Hunter",
                            Gênero = "Romance",
                            Nome = "Eu e Esse Meu Coração",
                            RegistroLivro = 0
                        },
                        new
                        {
                            Id = 4,
                            Autor = "Suzanne Collins",
                            Gênero = "Distopia Adolescente",
                            Nome = "Jogos Vorazes",
                            RegistroLivro = 0
                        },
                        new
                        {
                            Id = 5,
                            Autor = "V. E. Schwab",
                            Gênero = "Fantasia",
                            Nome = "A Sociedade Invisível de Addie LaRue",
                            RegistroLivro = 0
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
