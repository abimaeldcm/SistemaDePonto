using Microsoft.AspNetCore.Mvc;
using PontoMVC.Helper;
using PontoMVC.Models;
using PontoMVC.Repositorio;

namespace PontoMVC.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly ISessao _session;

        public LoginController(IUsuarioRepositorio usuarioRepositorio, ISessao session)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _session = session; 
        }
        public IActionResult Index()
        {
            if (_session.BuscarSessaoDoUsuario() != null)
            {
                TempData["MensagemSucesso"] = "Seja bem vindo! Você já está logado!";
                return RedirectToAction("Index", "Home");
            }

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Logar(LoginModel usuario)
        {
            UsuarioModel usuarioDB = await _usuarioRepositorio.BuscarPorLoginSenha(usuario);
            if (usuarioDB != null) 
            { 
                _session.CriarSessaoDoUsuario(usuarioDB);
                return RedirectToAction("Index", "Home");
            }
            TempData["MensagemErro"] = "Login ou senha estão incorretos";
            return View("Index");
            
            
        }
        public IActionResult PrimeiroLogin()
        {
            return View();
        }
        public IActionResult Recuperacao()
        {
            return View();
        }
        
        public IActionResult ValidacaoSenha()
        {
            return View();
        }
    }
}
