using LeiaMais.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LeiaMais.DAO
{
    public class UsuarioDAO
    {
        private LeiaMaisContext context;
        public UsuarioDAO(LeiaMaisContext context)
        {
            this.context = context;
        }
       
       
        public IList<Usuario> Lista()
        {
            return context.Usuarios.ToList();
        }

        public Usuario Busca(int id)
        {
            return context.Usuarios.FirstOrDefault(u => u.Id == id);
        }
    }
}