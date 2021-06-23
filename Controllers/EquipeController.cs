using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoEplayers.Models;

namespace ProjetoEplayers.Controllers
{
    [Route("Equipe")]
    public class EquipeController : Controller
    {
        Equipe equipemodel = new Equipe();
        [Route("Listar")]

        public IActionResult Index()
        {
            ViewBag.Equipes = equipemodel.LerTodas();
            return View();
        }

        [Route("Cadastrar")]
        public IActionResult Cadastrar(IFormCollection form)
        {
            Equipe novaEquipe = new Equipe();
            novaEquipe.IdEquipe = Int32.Parse(form["IdEquipe"]);
            novaEquipe.Nome = form["Nome"];
            novaEquipe.Imagem = form["Imagem"];

            equipemodel.Criar(novaEquipe);
            ViewBag.Equipes = equipemodel.LerTodas();
            return LocalRedirect("~/Equipe/Listar");
        }
    }
}