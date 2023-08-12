using PontoMVC.Models;

namespace PontoMVC.Repositorio
{
    public interface IUsuarioRepositorio
    {
        Task<bool> Criar(UsuarioModel usuario);
        UsuarioModel UsuarioPorId(int id);
        Task<List<UsuarioModel>> TodosUsuarios();
        Task<UsuarioModel> AlterarUsario(UsuarioModel usuario);
        Task<bool> Apagar(int id);
        Task<UsuarioModel> BuscarPorEmail(string email);
        Task<bool> AlterarSenha(UsuarioModel usuario);
        Task<UsuarioModel> BuscarPorLoginSenha(LoginModel logar);
    }
}
