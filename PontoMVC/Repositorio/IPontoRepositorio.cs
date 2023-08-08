using PontoMVC.Data;
using PontoMVC.Models;

namespace PontoMVC.Repositorio
{
    public interface IPontoRepositorio
    {
        PontoModel BaterPonto(PontoModel bater);
        UsuarioModel Usuario();
        IQueryable<PontoModel> Marcacoes();
    }
}
