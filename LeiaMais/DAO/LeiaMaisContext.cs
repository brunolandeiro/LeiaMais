using LeiaMais.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LeiaMais.DAO
{
    public class LeiaMaisContext :DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Livro> Livros { get; set; }

        public DbSet<Categoria> Categorias { get; set; }

        public DbSet<Contato> Contato { get; set; }

        public DbSet<UsuarioContato> UsuarioContatos { get; set; }

        public DbSet<Curtida> Curtidas { get; set; }


        protected override void OnModelCreating(DbModelBuilder builder)
        {
            builder.Entity<Livro>().HasRequired(l => l.Usuario);
            builder.Entity<Livro>().HasRequired(l => l.Categoria);
            builder.Entity<UsuarioContato>().HasKey(uc => new { uc.Id });
            builder.Entity<Curtida>().HasKey(c => new { c.Id });
            
            /*builder.Entity<Contato>()
            .HasOptional<Usuario>(s => s.Usuario)
            .WithMany()
            .WillCascadeOnDelete(false);*/
            
        }

        
    }
}