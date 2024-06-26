using BookStock.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStock.Models.Enuns;
using BookStock.Utils;

namespace BookStock.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Livro> TB_LIVROS { get; set; }
        public DbSet<Usuario> TB_USUARIOS { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Livro>().ToTable("TB_LIVROS");
            modelBuilder.Entity<Usuario>().ToTable("TB_USUARIOS");

            /*
            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.listaLivro)
                .WithOne(e => e.Usuario)
                .HasForeignKey(e => e.UsuarioId)
                .IsRequired(false);
            */
            
            modelBuilder.Entity<Livro>().HasData
            (
                new Livro() { Id = 1, Nome = "Últimas Mensagens Recebidas", Gênero = "Drama", Autor = "Emily Trunko", UsuarioId=1},
                new Livro() { Id = 2, Nome = "Os Sete Maridos de Evelyn Hugo", Gênero = "Romance", Autor = "Taylor Jenkins Reid", UsuarioId=1},
                new Livro() { Id = 3, Nome = "Eu e Esse Meu Coração", Gênero = "Romance", Autor = "C. C. Hunter", UsuarioId=1},
                new Livro() { Id = 4, Nome = "Jogos Vorazes", Gênero = "Distopia Adolescente", Autor = "Suzanne Collins", UsuarioId=1},
                new Livro() { Id = 5, Nome = "A Sociedade Invisível de Addie LaRue", Gênero = "Fantasia", Autor = "V. E. Schwab", UsuarioId=1}
            );

            Usuario user = new Usuario();
            Criptografia.CriarPasswordHash("123456", out byte[] hash, out byte[] salt);
            user.Id = 1;
            user.Username = "UsuarioAdmin";
            user.PasswordHash = hash;
            user.PasswordSalt = salt;
            user.Nome = "Admin";
            user.Email = "seuEmail@gmail.com";

            modelBuilder.Entity<Usuario>().HasData(user);
            modelBuilder.Entity<Usuario>().Property(u => u.Nome).HasDefaultValue("Comprador");
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<string>().HaveColumnType("varchar").HaveMaxLength(200);
        }
    }
}