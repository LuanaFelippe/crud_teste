using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRUD_Teste.Models;

namespace CRUD_Teste.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Salvar(FormCollection frm)
        {
            Usuario u = new Usuario();
            u.Nome = frm["nome"];
            u.CPF = frm["cpf"];
            u.Telefone = frm["telefone"];

            Conexao c = new Conexao();
            c.Inserir(u);

            return View("Index");
        }

        public ActionResult Alterar(FormCollection frm)
        {
            Usuario u = new Usuario();
            u.id = Convert.ToInt64(frm["id"]);
            u.Nome = frm["nome"];
            u.CPF = frm["cpf"];
            u.Telefone = frm["telefone"];

            Conexao c = new Conexao();
            c.Atualizar(u);

            return View();
        }

        public ActionResult Excluir(FormCollection frm)
        {
            Usuario u = new Usuario();

            u.id = Convert.ToInt64(frm["id"]);

            Conexao c = new Conexao();
            c.Excluir(u);

            return View();
        }
    }
}