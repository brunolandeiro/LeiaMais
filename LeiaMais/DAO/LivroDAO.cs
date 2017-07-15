using LeiaMais.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LeiaMais.DAO
{
    public class LivroDAO
    {
        private LeiaMaisContext context;
        public LivroDAO(LeiaMaisContext context)
        {
            this.context = context;
        }

        public void Adiciona(Livro livro)
        {
            context.Livros.Add(livro);
            context.SaveChanges();
        }
        public IList<Livro> Lista()
        {
            
            return context.Livros.ToList();
        }
        public IList<Livro> Busca(int? livro, decimal? valorMinimo, decimal? valorMaximo, int? categoria, int? usuario )
        {
            IQueryable<Livro> resultado = context.Livros;
            if (livro.HasValue)
            {
                resultado = resultado.Where(m => m.Id == livro);
            }
            if (valorMinimo.HasValue)
            {
                resultado = resultado.Where(m => m.Valor >= valorMinimo);
            }
            if (valorMaximo.HasValue)
            {
                resultado = resultado.Where(m => m.Valor <= valorMaximo);
            }
            if (categoria.HasValue)
            {
                resultado = resultado.Where(m => m.CategoriaId == categoria);
            }
            if (usuario.HasValue)
            {
                resultado = resultado.Where(m => m.UsuarioId == usuario);
            }

            resultado = resultado.OrderByDescending(m => m.Id);
            return resultado.ToList();
        }

        public IList<Livro> BuscaLogado(int id)
        {
            IQueryable<Livro> resultado = context.Livros;
            resultado = resultado.Where(l => l.UsuarioId == id);
            return resultado.ToList();
        }

        public void Remover(int id)
        {
            CurtidaDAO cdao = new CurtidaDAO(context);
            cdao.RemoveCurtidas(id);
            
            Livro livro = context.Livros.FirstOrDefault(l => l.Id == id);
            
            context.Livros.Remove(livro);
            context.SaveChanges();
        }

        internal IList<Livro> BuscaLivroPorUsuario(int id)
        {
            IQueryable<Livro> resultado = context.Livros;
            resultado = resultado.Where(l => l.UsuarioId == id);
            return resultado.ToList(); 
        }

        public Livro BuscaPorId(int id)
        {
            return context.Livros.FirstOrDefault(l => l.Id == id);

        }
    }
}