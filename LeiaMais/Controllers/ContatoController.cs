using LeiaMais.DAO;
using LeiaMais.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;

namespace LeiaMais.Controllers
{
    public class ContatoController : Controller
    {
        private UsuarioDAO usuarioDao;
        private UsuarioContatoDAO ucDao;
        private ContatoDAO contatoDao;
        public ContatoController(UsuarioDAO usuarioDao, UsuarioContatoDAO ucDao, ContatoDAO contatoDao)
        {
            this.usuarioDao = usuarioDao;
            this.ucDao = ucDao;
            this.contatoDao = contatoDao;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Adiciona(int contatoId)
        {
            var Uid = WebSecurity.CurrentUserId;
            Usuario usuario = usuarioDao.Busca(Uid);
            Usuario cont = usuarioDao.Busca(contatoId);
            Contato contato = new Contato();
            contato.Usuario = cont;

            contatoDao.Adiciona(contato);

            UsuarioContato uc = new UsuarioContato();
            uc.Usuario = usuario;
            uc.Contatos = contato;

            ucDao.Adiciona(uc);

            return RedirectToAction("Index", "Home");
        }
        public ActionResult Remover(int id)
        {
            ucDao.Remover(id);
            return RedirectToAction("Index", "Home");
        }
    }
}