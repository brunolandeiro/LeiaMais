using LeiaMais.DAO;
using LeiaMais.Entidades;
using LeiaMais.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebMatrix.WebData;

namespace LeiaMais.Controllers
{
    public class HomeController : Controller
    {
        private UsuarioDAO usuarioDao;
        private LivroDAO livroDao;
        private UsuarioContatoDAO ucDao;
        public HomeController(UsuarioDAO usuarioDao, LivroDAO livroDao, UsuarioContatoDAO ucDao)
        {
            this.usuarioDao = usuarioDao;
            this.livroDao = livroDao;
            this.ucDao = ucDao;
        }

        public ActionResult Index()
        {
            var id = WebSecurity.CurrentUserId;
            Usuario usuario = usuarioDao.Busca(id);
            ViewBag.Usuario = usuario;

            IList<UsuarioContato> uc = ucDao.Busca(id);
            ViewBag.contato = uc;

            IList<Livro> livro = livroDao.BuscaLogado(id);
            ViewBag.livro = livro;
            return View();
        }

        public ActionResult Adiciona(UsuarioModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    WebSecurity.CreateUserAndAccount(model.Email, model.Senha,
                        new { Nome = model.Nome });
                    ViewBag.Sucesso = "CADASTRO REALIZADO COM SUCESSO";
                    
                    return View("Index");
                }
                catch (MembershipCreateUserException e)
                {
                    ModelState.AddModelError("usuario.Invalido", e.Message);
                    return View("Index", model);
                }
            }
            else
            {
                return View("Index", model);
            }
        }

        public ActionResult Autentica(String login, String senha)
        {
            if (WebSecurity.Login(login, senha))
            {
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("login.Invalido", "Login invalido");
                return View("Index");
            }
        }

        public ActionResult Logout()
        {
            WebSecurity.Logout();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Remover(int id)
        {
            livroDao.Remover(id);
            return RedirectToAction("Index", "Home");
        }
    }
}