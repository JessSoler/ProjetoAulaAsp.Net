using ProjetoTesteAula.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoTesteAula.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            AulaEntities2 banco = new AulaEntities2();
            var clientes = banco.Clientes.ToList();
            return View(clientes);
        }
        [HttpGet]
        public ActionResult Details(int id)
        {

            AulaEntities2 banco = new AulaEntities2();

            var cliente = banco.Clientes
                .Where(x => x.ID == id).SingleOrDefault();

            return View(cliente);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            AulaEntities2 banco = new AulaEntities2();
            var cliente = banco.Clientes
                .Where(x => x.ID == id).SingleOrDefault();

            banco.Clientes.Remove(cliente);

            banco.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Create()
        {
            AulaEntities2 banco = new AulaEntities2();
            var cidades = banco.Cidades.ToList();
            var lista = new List<SelectListItem>();
            foreach (var cid in cidades)
            {
                lista.Add(new SelectListItem
                {
                    Value = cid.ID.ToString(),
                    Text = cid.Nome
                });
            }

            ViewBag.IDCidade = lista;

            return View();
        }

        [HttpPost]
        public ActionResult Create(Cliente cliente)
        {
            AulaEntities2 banco = new AulaEntities2();
            banco.Clientes.Add(cliente);

            banco.SaveChanges();

            return RedirectToAction("Details", new { id = cliente.ID });
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
   
            AulaEntities2 banco = new AulaEntities2();

            var cliente = banco.Clientes.Where(
                w => w.ID == id).SingleOrDefault();

            var cidades = banco.Cidades.ToList();
            var lista = new List<SelectListItem>();
            foreach (var cid in cidades)
            {
                lista.Add(new SelectListItem
                {
                    Value = cid.ID.ToString(),
                    Text = cid.Nome,
                    Selected = cid.ID == cliente.IDCidade
                });
            }

            ViewBag.IDCidade = lista;

            return View(cliente);
        }

        [HttpPost]
        public ActionResult Edit(Cliente cliente)
        {

            AulaEntities2 banco = new AulaEntities2();

            var clienteNoBanco = banco.Clientes.Where(
                w => w.ID == cliente.ID).SingleOrDefault();

            //altera os dados para o que veio 
            clienteNoBanco.IDCidade = cliente.IDCidade;
            clienteNoBanco.Nome = cliente.Nome;
            clienteNoBanco.DataNascimento = cliente.DataNascimento;
            clienteNoBanco.Sexo = cliente.Sexo;
            clienteNoBanco.Ativo = cliente.Ativo;


            banco.SaveChanges();

            return RedirectToAction("Details", new { id = cliente.ID });
        }

    }
}