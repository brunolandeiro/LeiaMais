using LeiaMais.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LeiaMais.Entidades
{
    public class Livro
    {
        public int Id { get; set; }
        
        [Required]
        public string Nome { get; set; }

        public string Autor { get; set; }
        
        [Required]
        public decimal Valor { get; set; }

        public string Descricao { get; set; }

        public int CategoriaId { get; set; }

        
        public virtual Categoria Categoria { get; set; }

        public int UsuarioId { get; set; }

        public virtual Usuario Usuario { get; set; }

        public string url { get; set; }

        public int CurtidaId { get; set; }
        public IList<Curtida> Quantidade { get; set; }   

    }
}