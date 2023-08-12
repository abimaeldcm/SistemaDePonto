using Microsoft.AspNetCore.Mvc;
using PontoMVC.Models;
using PontoMVC.Repositorio;

namespace PontoMVC.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public LoginController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Logar(LoginModel usuario)
        {
            UsuarioModel usuarioDB = await _usuarioRepositorio.BuscarPorLoginSenha(usuario);
            if (usuarioDB != default) 
            { 
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
