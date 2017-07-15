using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LeiaMais.Entidades
{
    public class UsuarioContato
    {
        public int Id { get; set; }
        public int ContatoId { get; set; }
        public virtual Contato Contatos { get; set; }
        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}