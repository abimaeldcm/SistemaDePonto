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
        private readonly IUsuarioLoginRepositorio _usuarioLoginRepositorio;



        public LoginController(IUsuarioRepositorio usuarioRepositorio, ISessao session, IUsuarioLoginRepositorio usuarioLoginRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _session = session;
            _usuarioLoginRepositorio = usuarioLoginRepositorio;
        }
        public IActionResult Index()
        {
            try
            {
                if (_session.BuscarSessaoDoUsuario() != null)
                {
                    TempData["MensagemSucesso"] = "Seja bem vindo! Você já está logado!";
                    return RedirectToAction("Index", "Home");
                }

                return View();

            }
            catch
            {
                return View();
            }            
                       
        }
        [HttpPost]
        public async Task<IActionResult> Logar(LoginModel usuario)
        {
            try
            {
                UsuarioModel usuarioDB = _usuarioRepositorio.BuscarPorLoginSenha(usuario);
                if (usuarioDB != null) 
                { 
                    _session.CriarSessaoDoUsuario(usuarioDB);
                    return RedirectToAction("Index", "Home");
                }
                TempData["MensagemErro"] = "Login ou senha estão incorretos";

                return View("Index");
            }
            catch 
            {
                TempData["MensagemErro"] = "Um erro ocorreu ao logar. Tente novamente";
                return View("Index");
            }
        }
        public IActionResult PrimeiroLogin()
        {
            return View();
            
        }        
        public IActionResult PrimeiroLoginSenha(string email)
        {
            var usuarioExiste = _usuarioRepositorio.BuscarPorEmail(email);
            if (usuarioExiste != null)
            {
                _usuarioLoginRepositorio.CriarSenha(email);
                TempData["MensagemSucessoEnvio"] = "Encaminhamos para o e-mail informado uma nova senha. Após entrar no sistema, acessa a página de alterar senha para colocar uma senha nova.";
                return View("Index");
            }
            else 
            {
                TempData["MensagemErro"] = "Não encontramos o e-mail informado. Verifique as informações ou entre em contato com o seu administrador.";
                return View("PrimeiroLogin"); 
            }
            
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
