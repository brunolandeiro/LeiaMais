using LeiaMais.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LeiaMais.Models
{
    public class BuscaLivrosModel
    {
        public decimal? ValorMinimo { get; set; }

        public decimal? ValorMaximo { get; set; }

        public int? CategoriaId { get; set; }

        public IList<Categoria> Categorias { get; set; }

        public int? UsuarioId { get; set; }

        public int? LivroId { get; set; }

        public IList<Livro> Livros { get; set; }

        public IList<UsuarioContato> UsuarioContatos { get; set; }
    }
}