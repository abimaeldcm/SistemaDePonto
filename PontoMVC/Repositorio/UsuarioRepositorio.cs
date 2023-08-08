using PontoMVC.Data;
using PontoMVC.Models;

namespace PontoMVC.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly BancoContext _bancoContext;

        public UsuarioRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public string Usuario()
        {
            return _bancoContext.Usuarios.FirstOrDefault(u => u.Id == 1).Nome;
        }
    }
}
