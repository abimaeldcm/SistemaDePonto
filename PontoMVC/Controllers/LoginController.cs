using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
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
        private readonly IEmailService  _emailService;
        private readonly VerificadorCodigoService   _VerificadorDeCodigoService;

        public LoginController(IUsuarioRepositorio usuarioRepositorio, ISessao session, 
                                IUsuarioLoginRepositorio usuarioLoginRepositorio, 
                                IEmailService emailService, VerificadorCodigoService verificadorCodigoService)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _session = session;
            _usuarioLoginRepositorio = usuarioLoginRepositorio;
            _emailService = emailService;
            _VerificadorDeCodigoService = verificadorCodigoService;
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
        public IActionResult EsqueciSenha()
        {
            return View("PrimeiroLogin");
        }

        public IActionResult PrimeiroLogin()
        {
            return View();
            
        }
        [HttpPost]
        public IActionResult PrimeiroLogin(string email)
        {
            var usuarioExiste = _usuarioRepositorio.BuscarPorEmail(email);
            if (usuarioExiste != null)
            {
                int codigo = _VerificadorDeCodigoService.GerarCodigo();

                _emailService.SendEmailAsync(email, 
                    "Código de Recuperação", 
                $"Seu código de recuperação é: {codigo} \n Código válido por 10 minutos." );

                _VerificadorDeCodigoService.GuardarEmailCache(email);

                TempData["MensagemSucessoEnvio"] = "Encaminhamos um código de recuperação para o seu e-mail";
                return RedirectToAction("ConfirmacaoCodigo");
            }
            else 
            {
                TempData["MensagemEmailNaoEncontrado"] = "Não encontramos o e-mail informado. Verifique as informações ou entre em contato com o seu administrador.";
                return View("PrimeiroLogin"); 
            }
            
        }
        public IActionResult ConfirmacaoCodigo()
        {

            return View();
        }
        [HttpPost]
        public IActionResult ConfirmacaoCodigo(string codigo)
        {
            var codigoIgual = _VerificadorDeCodigoService.ValidarCodigoEnviado(codigo);

            if (codigoIgual)
            {
                return RedirectToAction("AlterarSenha");
            }

            TempData["CodigoIncorreto"] = "O código informado não corresponde ao enviado para o seu e-mail. Tente novamente.";

            return View();
        }
        
        public IActionResult AlterarSenha()
        {

            return View();
        }
        [HttpPost]
        public IActionResult AlterarSenha(string NovaSenha, string ConfirmarNovaSenha)
        {
            if (NovaSenha != ConfirmarNovaSenha)
            {
                ModelState.AddModelError("ConfirmarNovaSenha", "As senhas não correspondem.");
                return View();
            }

            var email = _VerificadorDeCodigoService.RecuperarEmailCache();

            if(email == null)
            {
                //colocar a excessão aqui
                return View();
            }

            UsuarioModel Usuario = _usuarioRepositorio.BuscarPorEmail(email);
            Usuario.Senha = BCrypt.Net.BCrypt.HashPassword(NovaSenha);

            _usuarioRepositorio.AlterarSenha(Usuario);

            TempData["SenhaAlterada"] = "Sua senha foi alterada com sucesso!";

            return RedirectToAction("Index", "Login");
        }

        

    }
}
