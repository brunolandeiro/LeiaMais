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
    [Authorize]
    public class CurtidaController : Controller
    {
        private CurtidaDAO curtidaDao;
        public CurtidaController(CurtidaDAO curtidaDao)
        {
            this.curtidaDao = curtidaDao;
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Adicionar(int livroId)
        {
            Curtida curtida = new Curtida();
            curtida.LivroId = livroId;
            curtida.UsuarioId = WebSecurity.CurrentUserId;
            curtidaDao.Adiciona(curtida);
            return RedirectToAction("Detalhes", "Livro", new { livroId = livroId });
        }
        public ActionResult Remover(int livroId)
        {
            
            curtidaDao.Remover(livroId);
            return RedirectToAction("Detalhes", "Livro", new { livroId = livroId });
        }

      
    }
}