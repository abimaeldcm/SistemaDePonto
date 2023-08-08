using Microsoft.AspNetCore.Mvc;
using PontoMVC.Models;
using PontoMVC.Repositorio;
using System.Collections;

namespace PontoMVC.Controllers
{
    public class PontoController : Controller
    {

        private readonly IPontoRepositorio _pontoRepositorio;
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public PontoController(IPontoRepositorio pontoRepositorio, IUsuarioRepositorio usuarioRepositorio)
        {
            _pontoRepositorio = pontoRepositorio;
            _usuarioRepositorio = usuarioRepositorio;
        }
        [HttpPost]
        public IActionResult Bater(PontoModel ponto)
        {
            if (ponto.TipoBatida == 0)
            {
                TempData["MensagemErro"] = "Selecione um tipo de marcação";
            }
            else
            {
                ponto.Usuario = _pontoRepositorio.Usuario();
                _pontoRepositorio.BaterPonto(ponto);
                TempData["MensagemSucesso"] = "Marcação incluida com sucesso!";
            }
            return RedirectToAction("Index", "Home");                  
        }

        public IActionResult HistoricoMarcacao() 
        {
            List<PontoModel> marcacoes = _pontoRepositorio.Marcacoes().ToList(); ;

            return View(marcacoes);
        }
    }
}
