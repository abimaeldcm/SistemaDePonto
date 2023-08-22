using Microsoft.AspNetCore.Mvc;
using PontoMVC.Filters;
using PontoMVC.Helper;
using PontoMVC.Models;
using PontoMVC.Repositorio;

namespace PontoMVC.Controllers
{
    [PaginaUsuarioLogado]
    [PaginaUsuarioAdm]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly ISessao _sessao;

        public UsuarioController(IUsuarioRepositorio usuarioRepositorio, ISessao sessao)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _sessao = sessao;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var usuarios = await _usuarioRepositorio.TodosUsuarios();
                if (usuarios.Any())
                { 
                    return View(usuarios);
                }
                else
                {
                    TempData["MensagemErro"] = "Ops!! Não conseguimos localizar nenhum usuário! Adicione um usuário";
                    return RedirectToAction("TelaCriar");
                }               
                
            }
            catch (Exception)
            {

                TempData["MensagemErro"] = "Ops!! Não conseguimos localizar nenhum usuário! Adicione um usuário";
                return RedirectToAction("TelaCriar");
            }
            
        }
        
        public IActionResult TelaCriar()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Criar(UsuarioModel usuario)
        {
            await _usuarioRepositorio.Criar(usuario);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> TelaEditar(int id)
        {
            UsuarioModel usuario =  _usuarioRepositorio.UsuarioPorId(id);
            return View(usuario);
        }
        public IActionResult MarcacoesUsuario(int id)
        {
            var Marcacoes =  _usuarioRepositorio.MarcacoesId(id);
            return View(Marcacoes);
        }
        [HttpPost]
        public async Task<IActionResult> Editar(UsuarioModel usuario)
        {
            var usuarios = await _usuarioRepositorio.AlterarUsario(usuario);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> AlterarSenha (string Email)
        {
            UsuarioModel usuario = _usuarioRepositorio.BuscarPorEmail(Email);
            await _usuarioRepositorio.AlterarSenha(usuario);

            return  RedirectToAction("Index", "Login");
        }
        public async Task<IActionResult> Detalhes(int id)
        {
            UsuarioModel usuario =  _usuarioRepositorio.UsuarioPorId(id);
            return View(usuario);
        }
        
        public IActionResult TelaApagar(int id)
        {
            UsuarioModel usuario =  _usuarioRepositorio.UsuarioPorId(id);
            return View(usuario);
        }
        public async Task<IActionResult> Apagar(int id)
        {
            if (await _usuarioRepositorio.Apagar(id))
            {
                TempData["MensagemSucesso"] = "Usuário excluído com sucesso!";
            }
            else
            {
                TempData["MensagemErro"] = "Tivemos um problema ao excluido o usuário!";
            }
            return RedirectToAction("Index");
        }
    }
}
