using ProjetoTesteAula.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoTesteAula.Controllers
{
    public class CidadeController : Controller
    {
        // GET: Cidade
        [HttpGet]
        public ActionResult Index()
        {
            var cidades = new AulaEntities2().Cidades.ToList();   
            return View(cidades);
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            //estancia a classe do banco
            AulaEntities2 banco = new AulaEntities2();

            var cidade = banco.Cidades
                .Where(x => x.ID == id).SingleOrDefault();

            return View(cidade);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            AulaEntities2 banco = new AulaEntities2();
            var cidade = banco.Cidades
                .Where(x => x.ID == id).SingleOrDefault();

            banco.Cidades.Remove(cidade);
            banco.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Cidade cidade)
        {

            AulaEntities2 banco = new AulaEntities2();
            banco.Cidades.Add(cidade);

            banco.SaveChanges();

            return RedirectToAction("Details", new { id = cidade.ID });
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {

            AulaEntities2 banco = new AulaEntities2();

            var cidade = banco.Cidades.Where(
                w => w.ID == id).SingleOrDefault();

            return View(cidade);
        }

        [HttpPost]
        public ActionResult Edit(Cidade cidade)
        {

            AulaEntities2 banco = new AulaEntities2();

            var cidadeNoBanco = banco.Cidades.Where(
                w => w.ID == cidade.ID).SingleOrDefault();

            cidadeNoBanco.UF = cidade.UF;
            cidadeNoBanco.Nome = cidade.Nome;

            banco.SaveChanges();

            return RedirectToAction("Details", new { id = cidade.ID });
        }

    }
}