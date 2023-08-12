using Microsoft.AspNetCore.Mvc;
using PontoMVC.Models;
using PontoMVC.Repositorio;

namespace PontoMVC.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public async Task<IActionResult> Index()
        {
            var usuarios = await _usuarioRepositorio.TodosUsuarios();
            return View(usuarios);
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
                TempData["MensagemSucesso"] = "Marcação usuário excluído com sucesso!";
            }
            else
            {
                TempData["MensagemErro"] = "Tivemos um problema ao excluido o usuário!";
            }
            return RedirectToAction("Index");
        }
    }
}
