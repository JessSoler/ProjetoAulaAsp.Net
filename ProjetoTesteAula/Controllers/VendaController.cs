using ProjetoTesteAula.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoTesteAula.Controllers
{
    public class VendaController : Controller
    {
        // GET: Venda
        public ActionResult Index()
        {
            AulaEntities2 banco = new AulaEntities2();
            var vendas = banco.Vendas.ToList();
            return View(vendas);
        }
        public ActionResult Details(int id)
        {
            //estancia a classe do banco
            AulaEntities2 banco = new AulaEntities2();

            var venda = banco.Vendas
                .Where(x => x.ID == id).SingleOrDefault();

            return View(venda);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            AulaEntities2 banco = new AulaEntities2();
            var venda = banco.Vendas
                .Where(x => x.ID == id).SingleOrDefault();

            banco.Vendas.Remove(venda);
            banco.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Venda venda)
        {

            AulaEntities2 banco = new AulaEntities2();
            banco.Vendas.Add(venda);

            banco.SaveChanges();

            return RedirectToAction("Details", new { id = venda.ID });
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {

            AulaEntities2 banco = new AulaEntities2();

            var venda = banco.Vendas.Where(
                w => w.ID == id).SingleOrDefault();

            return View(venda);
        }

        [HttpPost]
        public ActionResult Edit(Venda venda)
        {

            AulaEntities2 banco = new AulaEntities2();

            var VendaNoBanco = banco.Vendas.Where(
                w => w.ID == venda.ID).SingleOrDefault();

            VendaNoBanco.IDCliente = venda.IDCliente;
            VendaNoBanco.Data = venda.Data;

            banco.SaveChanges();

            return RedirectToAction("Details", new { id = venda.ID });
        }
    }
}