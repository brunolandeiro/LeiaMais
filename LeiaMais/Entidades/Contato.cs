using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LeiaMais.Entidades
{
    public class Contato
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }
        public IList<UsuarioContato> UsuarioContato { get; set; }
       
    }
}