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
    public class CategoriaController : Controller
    {
        
        public CategoriaDAO categoriaDao;
        
        public CategoriaController(CategoriaDAO categoriaDao)
        {
            this.categoriaDao = categoriaDao;
        }

        public ActionResult Form()
        {
            return View();
        }
        
        public ActionResult Adiciona(Categoria categoria)
        {
            
            categoriaDao.Adiciona(categoria);
            return RedirectToAction("Form");
        }

         public ActionResult Index()
        {
            return View();
        }
    }
}