using LeiaMais.Entidades;
using LeiaMais.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMatrix.WebData;

namespace LeiaMais.DAO
{
    public class CurtidaDAO
    {
        private LeiaMaisContext context;
        public CurtidaDAO(LeiaMaisContext context)
        {
            this.context = context;
        }

        public bool Verifica(int livroId)
        {
            var Uid = WebSecurity.CurrentUserId;
             Curtida c = context.Curtidas.FirstOrDefault(u => u.UsuarioId == Uid && u.LivroId == livroId);

            if (c == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void Adiciona(Curtida curtida)
        {
            context.Curtidas.Add(curtida);
            context.SaveChanges();
        }

        public void Remover(int livroId)
        {
            var id = WebSecurity.CurrentUserId;
            Curtida curtida = context.Curtidas.FirstOrDefault(c => c.UsuarioId == id && c.LivroId == livroId);

            context.Curtidas.Remove(curtida);
            context.SaveChanges();
        }

        public int Conta(int livroId)
        {
            IQueryable<Curtida> resultado = context.Curtidas;
            resultado = resultado.Where(l => l.LivroId == livroId);
            int cont = 0;
            foreach (var c in resultado)
            {
                cont = cont + 1;
            }
            return cont;
        }
        public void RemoveCurtidas(int id)
        {
            IQueryable<Curtida> resultado = context.Curtidas;
            resultado = resultado.Where(l => l.LivroId == id);
            
            foreach (var c in resultado)
            {
                context.Curtidas.Remove(c);
            }
            
        }
    }
}