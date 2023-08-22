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
        UsuarioModel BuscarPorEmail(string email);
        Task<bool> AlterarSenha(UsuarioModel usuario);
        UsuarioModel BuscarPorLoginSenha(LoginModel logar);
        List<PontoModel> MarcacoesId(int id);
    }
}
