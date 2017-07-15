using LeiaMais.DAO;
using LeiaMais.Entidades;
using LeiaMais.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;

namespace LeiaMais.Controllers
{
    [Authorize]
    public class LivroController : Controller
    {
        // GET: Livro
        private LivroDAO livroDao;
        private UsuarioDAO usuarioDao;
        private CategoriaDAO categoriaDao;
        private UsuarioContatoDAO ucDao;
        private CurtidaDAO curtidaDao;
        private LeiaMaisContext context;
        public LivroController(LivroDAO livroDao, UsuarioDAO usuarioDao, CategoriaDAO categoriaDao, UsuarioContatoDAO ucDao, LeiaMaisContext context, CurtidaDAO curtidaDao)
        {
            this.livroDao = livroDao;
            this.usuarioDao = usuarioDao;
            this.categoriaDao = categoriaDao;
            this.ucDao = ucDao;
            this.curtidaDao = curtidaDao;
            this.context = context;
        }

        public ActionResult Form()
        {


            ViewBag.Categorias = categoriaDao.Lista();

            ViewBag.Id = WebSecurity.CurrentUserId;

            return View();
        }

        public ActionResult Adiciona(Livro livro)
        {
            
            int arquivosSalvos = 0;
            for (int i = 0; i < Request.Files.Count; i++)
            {
                HttpPostedFileBase arquivo = Request.Files[i];

                //Suas validações ......

                //Salva o arquivo
                if (arquivo.ContentLength > 0)
                {
                    var uploadPath = Server.MapPath("~/Content/Uploads");
                    string caminhoArquivo = Path.Combine(@uploadPath, Path.GetFileName(arquivo.FileName));

                    arquivo.SaveAs(caminhoArquivo);
                    arquivosSalvos++;
                    livro.url = arquivo.FileName;
                }
            }

            
            livroDao.Adiciona(livro);
            return RedirectToAction("Busca");
        }
        public ActionResult Index()
        {

            return RedirectToAction("Busca");
        }

        public ActionResult Busca(BuscaLivrosModel model)
        {
            var id = WebSecurity.CurrentUserId;
            model.UsuarioContatos = ucDao.Busca(id);
            model.Categorias = categoriaDao.Lista();
            
            model.Livros = livroDao.Busca(model.LivroId, model.ValorMinimo, model.ValorMaximo,
                                    model.CategoriaId, model.UsuarioId );

            
            return View(model);
        }

        public ActionResult Detalhes(int livroId)
        {
            Livro livro = livroDao.BuscaPorId(livroId);
            ViewBag.Livro = livro;
            bool verifica = curtidaDao.Verifica(livroId);
            ViewBag.VerificaCurtida = verifica;
            int cont = curtidaDao.Conta(livroId);
            ViewBag.Curtidas = cont;
            return View();
        }
        

        

        
        
    }
}