using LeiaMais.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LeiaMais.DAO
{
    public class CategoriaDAO
    {
        private LeiaMaisContext context;
        public CategoriaDAO(LeiaMaisContext context)
        {
            this.context = context;
        }

        public void Adiciona(Categoria categoria)
        {
            context.Categorias.Add(categoria);
            context.SaveChanges();
        }
        public IList<Categoria> Lista()
        {
            return context.Categorias.ToList();
        }
    }
}