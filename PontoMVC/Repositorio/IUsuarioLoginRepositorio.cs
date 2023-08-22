using PontoMVC.Models;

namespace PontoMVC.Repositorio
{
    public interface IUsuarioLoginRepositorio
    {
        Task<bool> CriarSenha(string email);
        Task<bool> Recuperar(string email);
    }
}
