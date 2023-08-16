using Microsoft.AspNetCore.Mvc;
using PontoMVC.Filters;
using PontoMVC.Helper;
using PontoMVC.Models;
using System.Diagnostics;

namespace PontoMVC.Controllers
{
    [PaginaUsuarioLogado]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISessao _sessao;

        public HomeController(ILogger<HomeController> logger, ISessao sessao)
        {
            _logger = logger;
            _sessao = sessao;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Sair()
        {
            try
            {
                _sessao.RemoverSessaoUsuario();
                return RedirectToAction("Index","Login");
            }
            catch (Exception erro)
            {

                TempData["MensagemErro"] = "Ops!! Não conseguimos realizar o Logoff! Destalhes:" + erro.Message;
                return RedirectToAction("Index"); ;
            }
            
        }
    }
}