using Microsoft.AspNetCore.Mvc;
using PontoMVC.Filters;
using PontoMVC.Helper;
using PontoMVC.Models;
using PontoMVC.Repositorio;
using System.Collections;

namespace PontoMVC.Controllers
{
    [PaginaUsuarioLogado]
    public class PontoController : Controller
    {

        private readonly IPontoRepositorio _pontoRepositorio;
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly ISessao _sessao;

        public PontoController(IPontoRepositorio pontoRepositorio, IUsuarioRepositorio usuarioRepositorio,ISessao sessao)
        {
            _pontoRepositorio = pontoRepositorio;
            _usuarioRepositorio = usuarioRepositorio;
            _sessao = sessao;
        }
        public IActionResult Index()
        {
            var usuario = _sessao.BuscarSessaoDoUsuario();
            if (usuario != null)
            {
                TempData["Usuario"] = usuario.Nome;
            }
            
            return View("Index");
        }

        [HttpPost]
        public IActionResult Bater(PontoModel ponto)
        {
            try
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
            catch (System.Exception erro)
            {

                TempData["MensagemErro"] = "Ops!! Não conseguimos realizar a marcação o ponto, tente novamente! Destalhes do erro:" + erro.Message;
                return RedirectToAction("Index"); ;
            }

        }

        public IActionResult HistoricoMarcacao() 
        {
            try
            {
                List<PontoModel> marcacoes = _pontoRepositorio.Marcacoes().ToList(); ;

                return View(marcacoes);
            }
            catch (Exception erro)
            {

                TempData["MensagemErro"] = "Ops!! As informações estã indisponiveis no momento, tente novamente! Destalhes:" + erro.Message;
                return RedirectToAction("Index", "Home"); ;
            }
            
        }
    }
}
