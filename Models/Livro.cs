using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStock.Models.Enuns;

namespace BookStock.Models
{
    public class Livro
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Gênero { get; set; } = string.Empty;
        public string Autor { get; set; } = string.Empty;
        public RegistroLivroEnum RegistroLivro { get; set; }
        public int? UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }
    }
}    
