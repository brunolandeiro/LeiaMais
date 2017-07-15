using LeiaMais.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LeiaMais.DAO
{
    public class ContatoDAO
    {
        private LeiaMaisContext context;
        public ContatoDAO(LeiaMaisContext context)
        {
            this.context = context;
        }

        public Contato Busca(int id)
        {
            return context.Contato.FirstOrDefault(c => c.Id == id);
        }

        public void Adiciona(Contato contato)
        {
            context.Contato.Add(contato);
            context.SaveChanges();
        }
    }
}