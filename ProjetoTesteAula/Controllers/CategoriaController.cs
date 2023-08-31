using ProjetoTesteAula.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoTesteAula.Controllers
{
    public class CategoriaController : Controller
    {
        // GET: Cidade
        [HttpGet]
        public ActionResult Index()
        {
            var categorias = new AulaEntities2().Categorias.ToList();
            return View(categorias);
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            //estancia a classe do banco
            AulaEntities2 banco = new AulaEntities2();

            var categoria = banco.Categorias
                .Where(x => x.ID == id).SingleOrDefault();

            return View(categoria);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            AulaEntities2 banco = new AulaEntities2();
            var categoria = banco.Categorias
                .Where(x => x.ID == id).SingleOrDefault();

            banco.Categorias.Remove(categoria);
            banco.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Categoria categoria)
        {

            AulaEntities2 banco = new AulaEntities2();
            banco.Categorias.Add(categoria);

            banco.SaveChanges();

            return RedirectToAction("Details", new { id = categoria.ID });
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {

            AulaEntities2 banco = new AulaEntities2();

            var categoria = banco.Categorias.Where(
                w => w.ID == id).SingleOrDefault();

            return View(categoria);
        }

        [HttpPost]
        public ActionResult Edit(Categoria categoria)
        {

            AulaEntities2 banco = new AulaEntities2();

            var categoriaNoBanco = banco.Categorias.Where(
                w => w.ID == categoria.ID).SingleOrDefault();

            categoriaNoBanco.Nome = categoria.Nome;

            banco.SaveChanges();

            return RedirectToAction("Details", new { id = categoria.ID });
        }

    }
}
