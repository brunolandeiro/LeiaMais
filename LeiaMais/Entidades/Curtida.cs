using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LeiaMais.Entidades
{
    public class Curtida
    {
        public int Id { get; set; }

        public int UsuarioId { get; set; }

        public virtual Usuario  Usuario { get; set; }

        public int LivroId { get; set; }

        public virtual Livro Livro { get; set; }

        //public int Quantidade { get; set; }
    }
}