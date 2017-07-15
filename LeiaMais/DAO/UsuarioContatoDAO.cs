using LeiaMais.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMatrix.WebData;

namespace LeiaMais.DAO
{
    public class UsuarioContatoDAO
    {
        private LeiaMaisContext context;
        public UsuarioContatoDAO(LeiaMaisContext context)
        {
            this.context = context;
        }

        public void Adiciona(UsuarioContato uc)
        {
            context.UsuarioContatos.Add(uc);
            context.SaveChanges();
        }

        public IList<UsuarioContato> Busca(int id)
        {
            IQueryable<UsuarioContato> resultado = context.UsuarioContatos;
            resultado = resultado.Where(c => c.UsuarioId == id);
            return resultado.ToList();
        }

        public void Remover(int id)
        {
            UsuarioContato uc = context.UsuarioContatos.FirstOrDefault(u => u.Contatos.Id == id);

            context.UsuarioContatos.Remove(uc);
            context.SaveChanges();
        }

        public bool Verifica(int id)
        {
            var Uid = WebSecurity.CurrentUserId;
            UsuarioContato uc = context.UsuarioContatos.FirstOrDefault(u => u.UsuarioId == Uid && u.Contatos.UsuarioId == id);
            
            if (uc == null)
            {
                return false;
            }
            else
            {
                return true;
            }
              
        }
    }
}