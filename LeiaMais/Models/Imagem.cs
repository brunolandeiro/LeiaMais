using LeiaMais.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LeiaMais.Models
{
    public class Imagem
    {
        
            public int IDArquivo { get; set; }
            public string Nome { get; set; }
            public int Tamanho { get; set; }
            public string Tipo { get; set; }
            public string Caminho { get; set; }
            public int LivroId { get; set; }
            public Livro Livro { get; set; }
    }
}