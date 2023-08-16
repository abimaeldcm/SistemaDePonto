using Microsoft.AspNetCore.Mvc;
using PontoMVC.Filters;
using PontoMVC.Models;
using PontoMVC.Repositorio;

namespace PontoMVC.Controllers
{
    [PaginaUsuarioLogado]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
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
        [HttpPost]
        public async Task<IActionResult> Editar(UsuarioModel usuario)
        {
            var usuarios = await _usuarioRepositorio.AlterarUsario(usuario);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> AlterarSenha (string Email)
        {
            UsuarioModel usuario = await _usuarioRepositorio.BuscarPorEmail(Email);
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
