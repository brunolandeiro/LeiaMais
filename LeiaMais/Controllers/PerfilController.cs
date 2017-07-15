using LeiaMais.DAO;
using LeiaMais.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeiaMais.Controllers
{
    [Authorize]
    public class PerfilController : Controller
    {
        // GET: Perfil
        private LivroDAO livroDao;
        private UsuarioDAO usuarioDao;
        private CategoriaDAO categoriaDao;
        private UsuarioContatoDAO ucDao;
        private LeiaMaisContext context;
        public PerfilController(LivroDAO livroDao, UsuarioDAO usuarioDao, CategoriaDAO categoriaDao, UsuarioContatoDAO ucDao, LeiaMaisContext context)
        {
            this.livroDao = livroDao;
            this.usuarioDao = usuarioDao;
            this.categoriaDao = categoriaDao;
            this.ucDao = ucDao;
            this.context = context;
        }
        [Route("Perfil/{id}", Name = "Perfil")]
        public ActionResult Index(int id)
        {
            ViewBag.Perfil = usuarioDao.Busca(id);
            bool verifica = ucDao.Verifica(id);
            ViewBag.VerificaContato = verifica;
            IList<Livro> livro = livroDao.BuscaLivroPorUsuario(id);
            ViewBag.livro = livro;
            return View();
        }

    }
}